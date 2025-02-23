using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccessLayer.Models
{
    public class Product
    {
        public int Id { get; set; }          // Mahsulotning unikal identifikatori
        public string Name { get; set; }     // Mahsulot nomi
        public decimal Price { get; set; }   // Mahsulot narxi
        public int Stock { get; set; }       // Mahsulotning mavjudligi

        // Buyurtmalar uchun (ixtiyoriy)
        public ICollection<Order> Orders { get; set; }
    }
}
