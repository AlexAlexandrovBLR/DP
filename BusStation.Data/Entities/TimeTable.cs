using System;
using System.Collections.Generic;

namespace BusStation.Data.Entities
{
    public class TimeTable
    {
        public int Id { get; set; }
        public int RouteId { get; set; }
        public DateTime Departure { get; set; }
        public DateTime Arrival { get; set; }
        public int Seats { get; set; }

        public virtual Route Route { get; set; }
        public virtual ICollection<User> Users { get; set; } = new List<User>();
    }
}
