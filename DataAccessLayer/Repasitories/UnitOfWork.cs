using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;
using AutoMapper;
using DataAccessLayer.Data;
using DataAccessLayer.IRepasitories;
using Microsoft.EntityFrameworkCore.Metadata;

namespace DataAccessLayer.Repasitories
{
    public class UnitOfWork : IUnitOfWork
    {
        private readonly AppDbContext appDbContext;
        private readonly IMapper mapper;

        public UnitOfWork(IContactHistoryInterface contactHistoryInterface,
                        ICustomerInterface customerInterface,
                        IOrderInterface orderInterface,
                        IProductInterface productInterface,
                        ICategoryRepasitory categoryRepasitory,
                        AppDbContext appDbContext,
                        IMapper mapper )
                        
        {
            this.contactHistoryInterface = contactHistoryInterface;
            this.customerInterface = customerInterface;
            this.orderInterface = orderInterface;
            this.productInterface = productInterface;
            CategoryRepasitory = categoryRepasitory;
            this.appDbContext = appDbContext;
            this.mapper = mapper;
        }
        public IContactHistoryInterface contactHistoryInterface { get; }

        public ICustomerInterface customerInterface { get; }

        public IOrderInterface orderInterface { get; }

        public IProductInterface productInterface { get; }

        public ICategoryRepasitory CategoryRepasitory { get; }

        public void Dispose()
        => GC.SuppressFinalize(this);

        public async Task SaveChangesAsync()
        => await appDbContext.SaveChangesAsync();
    }
}
