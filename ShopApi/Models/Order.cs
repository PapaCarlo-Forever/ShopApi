namespace ShopApi.Models
{
    public class Order
    {
        public int Id { get; set; } 
        
        public double Price { get; set; }
        public List<Book> Books { get; set; }
        public string DataTime { get; set; }
    }
}
