using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusStation.Services.Models
{
    public class SaveBusStopsViewModel
    {
        public List<string> SuccessSaved { get; set; } = new List<string>();
        public List<string> FailSaved { get; set; } =new List<string>();
    }
}
