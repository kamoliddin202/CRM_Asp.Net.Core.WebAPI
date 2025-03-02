using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DTOs.ContactHistoryDtos;

namespace BusinessLogicLayer.IServices
{
    public  interface IContactHistoryService
    {
        Task<IEnumerable<ContactHistoryDto>> GetAllContactHistoriesAsync();
        Task<ContactHistoryDto> GetContactHistoryByIdAsync(int id);
        Task AddContactHistoryAsync(AddContactHistoryDto addContactHistoryDto);
        Task UpdateContactHistoryAsync(UpdateContactHistoryDto updateContactHistoryDto);
        Task DeleteContactHistoryAsync(int id);
    }
}
