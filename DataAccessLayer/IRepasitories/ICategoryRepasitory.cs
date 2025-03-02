using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DataAccessLayer.Models;

namespace DataAccessLayer.IRepasitories
{
    public interface ICategoryRepasitory : IRepasitory<Category>
    {
        Task<Category?> GetCategoryWithProductsAsync(int? cateogryId);
    }
}
