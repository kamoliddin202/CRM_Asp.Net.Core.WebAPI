using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DataAccessLayer.Data;
using DataAccessLayer.Models;

namespace DataAccessLayer.Repasitories
{
    public class CustomerRepasitory : Repasitory<Customer>
    {
        public CustomerRepasitory(AppDbContext appDbContext) : base(appDbContext)
        {
        }
    }
}
