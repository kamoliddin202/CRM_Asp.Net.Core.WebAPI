using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DataAccessLayer.Models;

namespace DTOs.ProductDtos
{
    public class AddProductDto
    {       
        public string Name { get; set; }     // Mahsulot nomi
        public decimal Price { get; set; }   // Mahsulot narxi
        public int Stock { get; set; }       // Mahsulotning mavjudligi
    }
}
