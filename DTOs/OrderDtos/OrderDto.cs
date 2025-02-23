using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DataAccessLayer.Models;

namespace DTOs.OrderDtos
{
    public class OrderDto
    {
        public int Id { get; set; }          // Buyurtmaning unikal identifikatori
        public int CustomerId { get; set; }  // Buyurtma qilingan mijozning identifikatori
        public int ProductId { get; set; }   // Buyurtma qilingan mahsulotning identifikatori
        public DateTime OrderDate { get; set; } // Buyurtma berilgan sana
        //public Customer Customer { get; set; }
        //public Product Product { get; set; }
    }
}
