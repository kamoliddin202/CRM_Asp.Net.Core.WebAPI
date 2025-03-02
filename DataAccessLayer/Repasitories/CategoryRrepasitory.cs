using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DataAccessLayer.Data;
using DataAccessLayer.IRepasitories;
using DataAccessLayer.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;

namespace DataAccessLayer.Repasitories
{
    public class CategoryRrepasitory : Repasitory<Category>, ICategoryRepasitory
    {
        public CategoryRrepasitory(AppDbContext appDbContext) : base(appDbContext)
        {

        }

        public async Task<Category?> GetCategoryWithProductsAsync(int? cateogryId)
        {
            return await _appDbContext.Categories.Include(c => c.Products)
                            .FirstOrDefaultAsync(c => c.Id == cateogryId);
        }
    }
}
