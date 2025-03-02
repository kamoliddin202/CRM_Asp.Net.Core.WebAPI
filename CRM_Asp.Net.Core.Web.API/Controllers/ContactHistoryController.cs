using BusinessLogicLayer.IServices;
using DTOs.ContactHistoryDtos;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace CRM_Asp.Net.Core.Web.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ContactHistoryController : ControllerBase
    {
        private readonly IContactHistoryService _contactHistoryService;

        public ContactHistoryController(IContactHistoryService contactHistoryService)
        {
            _contactHistoryService = contactHistoryService;
        }

        [HttpGet]
        public async Task<IActionResult> Get()
        {
            var contactHistories = await _contactHistoryService.GetAllContactHistoriesAsync();
            return Ok(contactHistories); 
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> Get(int id)
        {
            var contactHistory = await  _contactHistoryService.GetContactHistoryByIdAsync(id);
            return Ok(contactHistory);
        }

        [HttpPost]
        public async Task<IActionResult> Post(AddContactHistoryDto addContactHistoryDto)
        {
            await _contactHistoryService.AddContactHistoryAsync(addContactHistoryDto);
            return Ok("Added successfully !");
        }

        [HttpPut]
        public async Task<IActionResult> Put(UpdateContactHistoryDto updateContactHistoryDto)
        {
            await _contactHistoryService.UpdateContactHistoryAsync(updateContactHistoryDto);
            return Ok("Updated successefully !");
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            await _contactHistoryService.DeleteContactHistoryAsync(id);
            return Ok("Deleted successfully !");
        }
    }
}
