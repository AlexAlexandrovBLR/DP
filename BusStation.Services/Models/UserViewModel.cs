using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusStation.Services.Models
{
    public class UserViewModel
    {
        public int Id { get; set; }
        [Display(Name = "Имя")]
        public string FirstName { get; set; }
        [Display(Name = "Фамилия")]
        public string LastName { get; set; }
        [Display(Name = "E-mail")]
        public string Email { get; set; }
        [Display(Name = "Дата рождения")]
        public DateTime? DateOfBirth { get; set; }
        [Display(Name = "Категория")]
        public string RoleName { get; set; }
        [Display(Name = "Город")]
        public string City { get; set; }
        [Display(Name = "Адрес")]
        public string Address { get; set; }
        [Display(Name = "Индекс")]
        public string ZipCode { get; set; }
        [Display(Name = "Телефон")]
        public string Phone { get; set; }
    }
}
