using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccessLayer.Models
{
    public class Customer
    {
        public int Id { get; set; }          // Mijozning unikal identifikatori
        public string Name { get; set; }     // Mijozning ismi
        public string Email { get; set; }    // Mijozning email manzili
        public string Phone { get; set; }     // Mijozning telefon raqami

        // Aloqa tarixi uchun (ixtiyoriy)
        public ICollection<ContactHistory> ContactHistories { get; set; }
        public ICollection<Order> Orders { get; set; }
    }
}
