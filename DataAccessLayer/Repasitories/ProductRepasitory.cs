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
    public class ProductRepasitory : Repasitory<Product>, IProductRepasitory
    {
        public ProductRepasitory(AppDbContext appDbContext) : base(appDbContext)
        {

        }
    }
}
