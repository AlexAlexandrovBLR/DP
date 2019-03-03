using System.Net;
using System.Web.Mvc;
using System.Web.Security;
using BusStation.Data.Entities;
using BusStation.Services.Interfaces;
using BusStation.Services.Models;
using Microsoft.AspNet.Identity;

namespace WebUI.Controllers
{
    public class AccountController : Controller
    {
        private readonly IAccountService _accountService;

        public AccountController(IAccountService accountService)
        {
            _accountService = accountService;
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Register(RegisterViewModel model)
        {
            if (ModelState.IsValid)
            {
                bool checkUser = _accountService.CheckUser(model.Email);

                if (checkUser)
                {
                    PasswordHasher hasher=new PasswordHasher();
                    model.Password = hasher.HashPassword(model.Password);

                    if (_accountService.RegisterNewUser(model))
                    {
                        return View("RegisterSuccessed");
                    }
                }
                else
                {
                    ModelState.AddModelError("", "Пользователь с таким e-mail уже существует!");
                }

            }

            return View(model);
        }

        public ActionResult Register()
        {
            return View();
        }

        [HttpGet]
        //[ValidateAntiForgeryToken]
        public ActionResult LogOff()
        {
            FormsAuthentication.SignOut();
            return RedirectToAction("Index", "Home");
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Login(LoginViewModel model)
        {
            if (ModelState.IsValid)
            {
                bool checkUser = _accountService.CheckUser(model.Email);
                
                if (!checkUser)
                {
                    PasswordHasher hasher = new PasswordHasher();
                    string hashedPassword = _accountService.GetHashedPassword(model);

                    var verifyPassword = hasher.VerifyHashedPassword(hashedPassword, model.Password) == PasswordVerificationResult.Success;

                    if (verifyPassword)
                    {
                        FormsAuthentication.SetAuthCookie(model.Email, model.RememberMe);

                        return RedirectToAction("Index", "Home");
                    }

                    ModelState.AddModelError("", "Неверный пароль!");
                }
                else
                {
                    return RedirectToAction("UserNotFound", "Account");
                }
            }
            return PartialView("_Login", model);
        }

        public ActionResult UserNotFound()
        {
            return View();
        }

        [HttpGet]
        public ActionResult UserInfo()
        {
            var t = Roles.Enabled;

            UserViewModel model=null;
            if (Request.IsAuthenticated)
            {
                string userName = User.Identity.GetUserName();
                model = _accountService.GetUserInfo(userName);
            }

            return View(model ?? new UserViewModel());
        }

        [HttpPost]
        public ActionResult SaveUserInfo(UserViewModel model)
        {
            var result = _accountService.SaveUserInfo(model);

            

            if (result.Successed)
            {
                return PartialView("_SaveUserInfoResultOk");
            }

            ViewBag.ErrorMessage = result.Message;

            return PartialView("_SaveUserInfoResultError");
        }



    }
    }