using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DataAccessLayer.Models;

namespace DTOs.OrderDtos
{
    public class UpdateOrderDto
    {
        public int Id { get; set; }
        public int CustomerId { get; set; }  // Buyurtma qilingan mijozning identifikatori
        public int ProductId { get; set; }   // Buyurtma qilingan mahsulotning identifikatori
        public DateTime OrderDate { get; set; } // Buyurtma berilgan sana

    }
}
