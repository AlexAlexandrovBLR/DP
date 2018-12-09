using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.Entity;
using BusStation.Data.Entities;


namespace BusStation.Data.Context
{
    public class ModelContext : System.Data.Entity.DbContext
    {
        static ModelContext()
        {
            Database.SetInitializer<ModelContext>(new ModelContentInitializer());
        }
        public ModelContext(string connectionString) : base(connectionString)
        {

        }
        public DbSet<BusStops> BusStopses { get; set; }
        public DbSet<Customers> Customerses { get; set; }
        public DbSet<Flights> Flightses { get; set; }
        public DbSet<Orders> Orderses { get; set; }
        public DbSet<Tickets> Ticketses { get; set; }

    }
}
