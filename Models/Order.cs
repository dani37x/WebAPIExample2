using System.ComponentModel.DataAnnotations.Schema;

namespace WebAPIExample2.Models
{
    public class Order
    {
        public int OrderId { get; set; }
        public DateTime Date { get; set; } = DateTime.Now;
        public bool Complaint { get; set; } = false;
        public ICollection<ServiceOrder> ServiceOrders { get; set; } = new List<ServiceOrder>();
        public int UserId { get; set; }

        [ForeignKey("UserId")]
        public User User { get; set; }
    }
}
