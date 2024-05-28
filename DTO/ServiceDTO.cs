using WebAPIExample2.Models;

namespace WebAPIExample2.DTO
{
    public class ServiceDTO
    {
        public int ServiceId { get; set; }
        public string Name { get; set; } = " ";
        public string Description { get; set; } = " ";
        public float Price { get; set; } = 0;
    }
}
