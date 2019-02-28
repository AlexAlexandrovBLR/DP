using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusStation.Services.Models
{
    public class BuyTicketViewModel: TimeTableViewModel
    {
        [Required(ErrorMessage = "Поле обязательно!")]
        [StringLength(50, MinimumLength = 3, ErrorMessage = "Длина строки должна быть от 3 до 50 символов")]
        [DisplayName("Фамилия")]
        public string FirstName { get; set; }

        [Required(ErrorMessage = "Поле обязательно!")]
        [StringLength(50, MinimumLength = 3, ErrorMessage = "Длина строки должна быть от 3 до 50 символов")]
        [DisplayName("Имя")]
        public string LastName { get; set; }

        [Required(ErrorMessage = "Поле обязательно!")]
        [StringLength(50, MinimumLength = 9, ErrorMessage = "Длина строки должна быть 9 символов")]
        [DisplayName("Серия и номер паспорта")]
        public string PassportNumber { get; set; }

        [Required(ErrorMessage = "Поле обязательно!")]
        [StringLength(50, MinimumLength = 16, ErrorMessage = "Длина строки должна быть 16 символов")]
        [DisplayName("Номер карты")]
        public string CardNumber { get; set; }

        [Required(ErrorMessage = "Поле обязательно!")]
        [StringLength(50, MinimumLength = 5, ErrorMessage = "Длина строки должна быть 5 символов")]
        [DisplayName("Срок действия")]
        public string ValidityPeriod { get; set; }

        [Required(ErrorMessage = "Поле обязательно!")]
        [StringLength(3, MinimumLength = 3, ErrorMessage = "Длина строки должна быть 3 символа")]
        [DisplayName("CVV")]
        public string Cvv { get; set; }
    }
}
