using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DTOs.CategoryDtos;

namespace BusinessLogicLayer.IServices
{
    public interface ICategorySerivice
    {
        Task<CategoryDTo> GetCategoryWithBooksAsync(int id);
        Task<IEnumerable<CategoryDTo>> GetAllCategoriesAsync();
        Task<CategoryDTo> GetCategoryByIdAsync(int id);
        Task AddCategoryAsync(AddCategoryDto category);
        Task UpdateCategoryAsync(UpdateCategoryDto category);
        Task DelertCategoryAsync(int id);   
    }
}
