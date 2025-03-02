﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DataAccessLayer.Models;

namespace DTOs.ProductDtos
{
    public class AddProductDto
    {      
        [Required]
        public string Name { get; set; }     // Mahsulot nomi
        [Required]
        public decimal Price { get; set; }   // Mahsulot narxi
        [Required]
        public int Stock { get; set; }       // Mahsulotning mavjudligi
        public int CategoryId { get; set; }

    }
}
