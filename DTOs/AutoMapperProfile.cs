using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AutoMapper;
using DataAccessLayer.Models;
using DTOs.CategoryDtos;
using DTOs.ContactHistoryDtos;
using DTOs.CustomerDtos;
using DTOs.OrderDtos;
using DTOs.ProductDtos;

namespace DTOs
{
    public class AutoMapperProfile : Profile
    {
        public AutoMapperProfile()
        {
            CreateMap<Product, ProductDto>();
            CreateMap<AddProductDto, Product>();
            CreateMap<UpdateProductDto, Product>()
                .ForMember(dest => dest.Id, src => src.Ignore());

            CreateMap<Order, OrderDto>();
            CreateMap<AddOrderDto, Order>();
            CreateMap<UpdateOrderDto, Order>()
                    .ForMember(dest => dest.Id, opt => opt.Ignore());

            CreateMap<Customer, CustomerDto>();
            CreateMap<AddCustomerDto, Customer>();
            CreateMap<UpdateCustomerDto, Customer>()
                        .ForMember(dest => dest.Id, opt => opt.Ignore());

            CreateMap<ContactHistory, ContactHistoryDto>();
            CreateMap<AddContactHistoryDto, ContactHistory>();
            CreateMap<UpdateContactHistoryDto, ContactHistory>()
                    .ForMember(dest => dest.Id, src => src.Ignore());

            CreateMap<Category, CategoryDTo>();
            CreateMap<AddCategoryDto, Category>();
            CreateMap<UpdateCategoryDto, Category>()
                    .ForMember(dest => dest.Id, src => src.Ignore());
                
        }
    }
}
