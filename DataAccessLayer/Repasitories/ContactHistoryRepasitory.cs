using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DataAccessLayer.Data;
using DataAccessLayer.Models;

namespace DataAccessLayer.Repasitories
{
    public class ContactHistoryRepasitory : Repasitory<ContactHistory>
    {
        public ContactHistoryRepasitory(AppDbContext appDbContext) : base(appDbContext)
        {
        }
    }
}
