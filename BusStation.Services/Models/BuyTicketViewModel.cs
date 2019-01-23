using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusStation.Services.Models
{
    public class BuyTicketViewModel: TimeTableViewModel
    {
        [DisplayName("Фамилия")]
        public string FirstName { get; set; }
        [DisplayName("Имя")]
        public string LastName { get; set; }
        [DisplayName("Серия и номер паспорта")]
        public string PassportNumber { get; set; }
        [DisplayName("Номер карты")]
        public string CardNumber { get; set; }
        [DisplayName("Срок действия")]
        public string ValidityPeriod { get; set; }
        [DisplayName("CVV")]
        public string Cvv { get; set; }
    }
}
