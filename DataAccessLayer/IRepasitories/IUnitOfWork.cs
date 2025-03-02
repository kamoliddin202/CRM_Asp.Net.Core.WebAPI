using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccessLayer.IRepasitories
{
    public interface IUnitOfWork : IDisposable
    {
        IContactHistoryInterface contactHistoryInterface { get; }
        ICustomerInterface customerInterface { get; }
        IOrderInterface orderInterface { get; }
        IProductInterface productInterface { get; }
        ICategoryRepasitory CategoryRepasitory { get; }

        Task SaveChangesAsync();
    }
}
