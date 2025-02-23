namespace DataAccessLayer.Models
{
    public class ContactHistory
        {
            public int Id { get; set; }          // Aloqa tarixining unikal identifikatori
            public int CustomerId { get; set; }  // Aloqa qilinayotgan mijozning identifikatori
            public string Notes { get; set; }    // Aloqa haqida eslatmalar
            public DateTime ContactDate { get; set; } // Aloqa sanasi

            // Mijoz bilan bog'lanish
            public Customer Customer { get; set; }
        }
    }
