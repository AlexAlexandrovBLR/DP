using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusStation.Data.Entities
{
    public class Customers
    {
        public int Id { get; set; }
        public  string Surname { get; set; }
        public string Name { get; set; }
        public  string Mail { get; set; }
        public  string Password { get; set; }
        public DateTime DateOfBirth { get; set; }

    }
}
