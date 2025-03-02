using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DataAccessLayer.Data;
using DataAccessLayer.IRepasitories;
using DataAccessLayer.Models;

namespace DataAccessLayer.Repasitories
{
    public class ContactHistoryRepasitory : Repasitory<ContactHistory>, IContactHistoryInterface
    {
        public ContactHistoryRepasitory(AppDbContext appDbContext) : base(appDbContext)
        {
        }
    }
}
