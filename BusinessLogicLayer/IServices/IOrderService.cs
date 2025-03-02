using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DTOs.OrderDtos;

namespace BusinessLogicLayer.IServices
{
    public interface IOrderService
    {
        Task<IEnumerable<OrderDto>> GetAllOrdersAsync();
        Task<OrderDto> GetOrderByIdAsync(int id);
        Task AddOrderAsync(AddOrderDto dto);
        Task UpdateOrderAsync(UpdateOrderDto dto);
        Task DeleteOrderAsync(int id);
    }
}
