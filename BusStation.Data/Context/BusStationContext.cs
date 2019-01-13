using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.Entity;
using BusStation.Data.Entities;


namespace BusStation.Data.Context
{
    public class BusStationContext : DbContext
    {
        static BusStationContext()
        {
            Database.SetInitializer<BusStationContext>(new BusStationtInitializer());
        }
        public BusStationContext(string connectionString) : base(connectionString)
        {

        }

        public DbSet<BusStop> BusStops { get; set; }
        public DbSet<Order> Orders { get; set; }
        public DbSet<Route> Routes { get; set; }
        public DbSet<RouteStop> RouteStops { get; set; }
        public DbSet<StatusOrder> StatusOrders { get; set; }
        public DbSet<TimeTable> TimeTables { get; set; }
        public DbSet<TypeStop> TypeStops { get; set; }
        public DbSet<User> Users { get; set; }
    }
}
