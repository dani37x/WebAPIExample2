using System.ComponentModel.DataAnnotations.Schema;
using WebAPIExample2.Models;

namespace WebAPIExample2.DTO
{
    public class OrderDTO
    {
        public int OrderId { get; set; }
        public DateTime Date { get; set; } = DateTime.UtcNow;
        public ICollection<int> ServicesIds { get; set; } = new List<int>();
        public int UserId { get; set; } = 1;
    }
}
