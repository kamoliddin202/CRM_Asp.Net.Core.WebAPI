using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AutoMapper;
using BusinessLogicLayer.Helpers;
using BusinessLogicLayer.IServices;
using DataAccessLayer.IRepasitories;
using DataAccessLayer.Models;
using DTOs.ProductDtos;

namespace BusinessLogicLayer.Services
{
    public class ProductService : IProductService
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;

        public ProductService(IUnitOfWork unitOfWork, 
                            IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }
        public async Task AddProductAsync(AddProductDto productDto)
        {
            if (productDto == null)
            {
                throw new ArgumentNullException("xatolik " + nameof(productDto));
            }
            var product = _mapper.Map<Product>(productDto);
            await _unitOfWork.productInterface.AddAsync(product);
            await _unitOfWork.SaveChangesAsync();
        }

        public async Task DeleteProductAsync(int id)
        {
            var porudct = await _unitOfWork.productInterface.GetByIdAsync(id);
            if (porudct == null)
            {
                throw new KeyNotFoundException($"Product with Id {id} not found !");
            }
            await _unitOfWork.productInterface.DeleteAsync(id);
            await _unitOfWork.SaveChangesAsync();
        }

        public async Task<IEnumerable<ProductDto>> GetAllProductsAsync()
        {
            var products = await _unitOfWork.productInterface.GetAllAsync();
            return products.Select(c => _mapper.Map<ProductDto>(c)).ToList();
        }

        public async Task<ProductDto> GetProductByIdAsync(int id)
        {
            var product = await _unitOfWork.productInterface.GetByIdAsync(id);
            if (product == null)
            {
                throw new KeyNotFoundException($"Product with Id {id} not found !");
            }
            return _mapper.Map<ProductDto>(product);
        }

        public async Task UpdateProductAsync(UpdateProductDto productDto)
        {
            var product = await _unitOfWork.productInterface.GetByIdAsync(productDto.Id);
            if (product == null)
            {
                throw new KeyNotFoundException($"Product with Id {productDto.Id} not found !");
            }
            _mapper.Map(productDto, product);
            await _unitOfWork.productInterface.UpdateAsync(product);
            await _unitOfWork.SaveChangesAsync();
        }
    }
}
