
using System;
using System.ComponentModel.DataAnnotations.Schema;

namespace BusStation.Data.Entities
{
    public class Order
    {      
        public int Id { get; set; }
        [ForeignKey("User")]
        public int UserId { get; set; }
        public string Description { get; set; }
        public DateTime OperationDate { get; set; }
        public DateTime DepartureDate { get; set; }

        public virtual User User { get; set; }
    }
}
