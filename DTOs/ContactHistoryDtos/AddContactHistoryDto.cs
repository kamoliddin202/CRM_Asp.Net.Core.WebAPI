using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DataAccessLayer.Models;

namespace DTOs.ContactHistoryDtos
{
    public class AddContactHistoryDto
    {
        public int CustomerId { get; set; }  // Aloqa qilinayotgan mijozning identifikatori
        public string Notes { get; set; }    // Aloqa haqida eslatmalar
        public DateTime ContactDate { get; set; } // Aloqa sanasi

    }
}
