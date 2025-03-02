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
using DTOs.ContactHistoryDtos;

namespace BusinessLogicLayer.Services
{
    public class ContactHistoryService : IContactHistoryService
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;

        public ContactHistoryService(IUnitOfWork unitOfWork,
                                    IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }
        public async Task AddContactHistoryAsync(AddContactHistoryDto addContactHistoryDto)
        {
            var mapped = _mapper.Map<ContactHistory>(addContactHistoryDto);
            await _unitOfWork.contactHistoryInterface.AddAsync(mapped);
            await _unitOfWork.SaveChangesAsync();
        }

        public async Task DeleteContactHistoryAsync(int id)
        {
            var contact = await _unitOfWork.contactHistoryInterface.GetByIdAsync(id);
            if (contact == null)
            {
                throw new ArgumentNullException(nameof(contact));
            }
            await _unitOfWork.contactHistoryInterface.DeleteAsync(id);
            await _unitOfWork.SaveChangesAsync();
        }

        public async Task<IEnumerable<ContactHistoryDto>> GetAllContactHistoriesAsync()
        {
            var contactHistories = await _unitOfWork.contactHistoryInterface.GetAllAsync();
            return contactHistories.Select(c => _mapper.Map<ContactHistoryDto>(c));
        }

        public async Task<ContactHistoryDto> GetContactHistoryByIdAsync(int id)
        {
            var contactHistory = await _unitOfWork.contactHistoryInterface.GetByIdAsync(id);
            if (contactHistory == null)
            {
                throw new ArgumentNullException(nameof(contactHistory));
            }
            return _mapper.Map<ContactHistoryDto>(contactHistory);
        }

        public async Task UpdateContactHistoryAsync(UpdateContactHistoryDto updateContactHistoryDto)
        {
            var contactHistory = await _unitOfWork.contactHistoryInterface.GetByIdAsync(updateContactHistoryDto.Id);
            if (contactHistory == null)
            {
                throw new ArgumentNullException(nameof(contactHistory));
            }
            _mapper.Map(updateContactHistoryDto, contactHistory);
            await _unitOfWork.contactHistoryInterface.UpdateAsync(contactHistory);
            await _unitOfWork.SaveChangesAsync();
        }
    }
}
