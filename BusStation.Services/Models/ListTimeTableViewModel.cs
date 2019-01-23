using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusStation.Services.Models
{
    public class ListTimeTableViewModel
    {
        public IEnumerable<TimeTableViewModel> TimeTableViewModels { get; set; }
        public PagingInfo PagingInfo { get; set; }
    }
}
