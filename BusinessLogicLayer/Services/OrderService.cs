using AutoMapper;
using BusinessLogicLayer.IServices;
using DataAccessLayer.IRepasitories;
using DataAccessLayer.Models;
using DTOs.OrderDtos;

namespace BusinessLogicLayer.Services
{
    public class OrderService : IOrderService
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;

        public OrderService(IUnitOfWork unitOfWork,
                            IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }
        public async Task AddOrderAsync(AddOrderDto dto)
        {
            var order = _mapper.Map<Order>(dto);
            await _unitOfWork.orderInterface.AddAsync(order);
            await _unitOfWork.SaveChangesAsync();
        }

        public async Task DeleteOrderAsync(int id)
        {
            var order = await _unitOfWork.orderInterface.GetByIdAsync(id);
            if (order == null)
            {
                throw new ArgumentNullException(nameof(id));
            }
            await _unitOfWork.orderInterface.DeleteAsync(id);
            await _unitOfWork.SaveChangesAsync();


        }

        public async Task<IEnumerable<OrderDto>> GetAllOrdersAsync()
        {
            var orders = await _unitOfWork.orderInterface.GetAllAsync();
            if (orders == null)
            {
                throw new ArgumentNullException($"{nameof(orders)}");
            }
            return orders.Select(c => _mapper.Map<OrderDto>(c)).ToList();
        }

        public async Task<OrderDto> GetOrderByIdAsync(int id)
        {
            var order = await _unitOfWork.orderInterface.GetByIdAsync(id);
            if (order == null)
            {
                throw new ArgumentNullException(nameof(order));
            }
            return _mapper.Map<OrderDto>(order);
        }

        public async Task UpdateOrderAsync(UpdateOrderDto dto)
        {
            var order = await   _unitOfWork.orderInterface.GetByIdAsync(dto.Id);
            if (order == null)
            {
                throw new ArgumentNullException(nameof(order));
            }
            _mapper.Map(dto, order);
            await _unitOfWork.orderInterface.UpdateAsync(order);
            await _unitOfWork.SaveChangesAsync();
        }
    }
}
