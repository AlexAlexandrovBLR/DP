
namespace BusStation.Data.Entities
{
    public class Order
    {      
        public int Id { get; set; }
        public int RouteId { get; set; }
        public int UserId { get; set; }
        public int StatusOrderId { get; set; }

        public virtual Route Route { get; set; }
        public virtual User User { get; set; }
        public virtual StatusOrder StatusOrder { get; set; }
    }
}
