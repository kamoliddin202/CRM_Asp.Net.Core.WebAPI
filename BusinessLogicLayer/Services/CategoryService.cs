using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AutoMapper;
using BusinessLogicLayer.IServices;
using DataAccessLayer.IRepasitories;
using DataAccessLayer.Models;
using DTOs.CategoryDtos;

namespace BusinessLogicLayer.Services
{
    public class CategoryService : ICategorySerivice
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;

        public CategoryService(IUnitOfWork unitOfWork, 
                                IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }
        public async Task AddCategoryAsync(AddCategoryDto categoryDto)
        {
            if (categoryDto == null)
            {
                throw new ArgumentNullException(nameof(categoryDto));
            }
            var mapped = _mapper.Map<Category>(categoryDto);
            await _unitOfWork.CategoryRepasitory.AddAsync(mapped);
            await _unitOfWork.SaveChangesAsync();
        }

        public async Task DelertCategoryAsync(int id)
        {
            var category = await _unitOfWork.CategoryRepasitory.GetByIdAsync(id);
            if (category == null)
            {
                throw new ArgumentNullException(nameof(category));
            }
            await _unitOfWork.CategoryRepasitory.DeleteAsync(category.Id);
            await _unitOfWork.SaveChangesAsync();
        }

        public async Task<IEnumerable<CategoryDTo>> GetAllCategoriesAsync()
        {
            var categories = await _unitOfWork.CategoryRepasitory.GetAllAsync();
            return categories.Select(c => _mapper.Map<CategoryDTo>(c));
        }

        public async Task<CategoryDTo> GetCategoryByIdAsync(int id)
        {
            var category = await _unitOfWork.CategoryRepasitory.GetByIdAsync(id);
            return _mapper.Map<CategoryDTo>(category);
        }

        public async Task UpdateCategoryAsync(UpdateCategoryDto categoryDto)
        {
            var category = await _unitOfWork.CategoryRepasitory.GetByIdAsync(categoryDto.Id);
            if (category == null)
            {
                throw new ArgumentNullException(nameof(category));
            }
            _mapper.Map(categoryDto, category);
            await _unitOfWork.CategoryRepasitory.UpdateAsync(category);
            await _unitOfWork.SaveChangesAsync();

        }

        public async Task<CategoryDTo> GetCategoryWithBooksAsync(int id)
        {
            var category = await _unitOfWork.CategoryRepasitory.GetCategoryWithProductsAsync(id);
            return _mapper.Map<CategoryDTo>(category);
        }
    }
}
