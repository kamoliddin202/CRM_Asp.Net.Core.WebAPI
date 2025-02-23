namespace DataAccessLayer.Models
{
    public class Order
    {
        public int Id { get; set; }          // Buyurtmaning unikal identifikatori
        public int CustomerId { get; set; }  // Buyurtma qilingan mijozning identifikatori
        public int ProductId { get; set; }   // Buyurtma qilingan mahsulotning identifikatori
        public DateTime OrderDate { get; set; } // Buyurtma berilgan sana

        // Mijoz va mahsulot bilan bog'lanish
        public Customer Customer { get; set; }
        public Product Product { get; set; }
    }
}
