using System.ComponentModel.DataAnnotations.Schema;

namespace WebAPIExample2.Models
{
    public class Order
    {
        public int OrderId { get; set; }
        public DateTime Date { get; set; }
        public int UserId { get; set; }

        [ForeignKey("UserId")]
        public User User { get; set; }
    }
}
