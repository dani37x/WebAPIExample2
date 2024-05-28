namespace WebAPIExample2.Models
{
    public class OrderDetail
    {
        public int OrderId { get; set; }
        public IEnumerable<int> ServicesIds { get; set;} = new List<int>();
    }
}
