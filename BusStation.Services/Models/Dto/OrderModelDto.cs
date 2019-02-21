using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusStation.Services.Models.Dto
{
    public class OrderModelDto
    {
        public string Description { get; set; }
        public DateTime OperationDate { get; set; }
        public DateTime DepartureDate { get; set; }
    }
}
