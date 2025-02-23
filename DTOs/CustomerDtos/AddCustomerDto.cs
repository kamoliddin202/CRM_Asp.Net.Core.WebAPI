using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DataAccessLayer.Models;

namespace DTOs.CustomerDtos
{
    public  class AddCustomerDto
    {       
        public string Name { get; set; }     // Mijozning ismi
        public string Email { get; set; }    // Mijozning email manzili
        public string Phone { get; set; }     // Mijozning telefon raqami

    }
}
