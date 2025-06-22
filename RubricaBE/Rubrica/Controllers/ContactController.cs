using Microsoft.AspNetCore.Mvc;
using Rubrica.API.Models.Dto;
using Rubrica.API.Models.Extensions;
using Rubrica.Application.Interfaces;
using Rubrica.Domain.Class;
using System.ComponentModel;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace Rubrica.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ContactController : ControllerBase
    {
        private IContactRepository _repo;
        private readonly ILogger _logger;

        public ContactController(IContactRepository repo, ILogger<ContactController> logger)
        {
            _logger = logger;
            _repo = repo;
        }

        
        [HttpGet("GetAllContacts")]
        public async Task<ActionResult<IEnumerable<ContactDto>>> GetAll()
        {

            var results = await _repo.GetAllAsync();

            if (results.Count() == 0) {
                return Ok();
            }

            return Ok(results.Select(x => x.ToDto()));
        }

        [HttpGet("GetAllCities")]
        public  async Task<ActionResult<IEnumerable<string>>> GetAllCity()
        {

            var res = await _repo.GetAllCitiesAsync();

            if(res.Count() == 0)
                return Ok();

            return Ok(res);

        }


        [HttpGet("{id}")]
        public async Task<ActionResult<ContactDto>> Get([FromBody] Guid id)
        {
             var res = await _repo.GetByIdAsync(id);

            if (res == null)
            {
                return NotFound();
            }

            return res.ToDto();
        }
        
        [HttpPost("GetAdvanced")]
        public async Task<ActionResult<ContactDto>> GetAdvanced([FromBody] SearchContactDto contact)
        {
            if(contact == null) 
                return BadRequest();

            var res = await _repo.Search(contact.Name, contact.Surname, contact.Email, contact.PhoneNumber);

            if(res == null)
                return NotFound();

            return Ok(res.Select(x => x?.ToDto()));

        }

        [HttpPost]
        public async Task<ActionResult> Post([FromBody] CreateContactDto contact)
        {

            if (contact == null)
                return BadRequest($"Empty body");

            if (!ModelState.IsValid)
                return BadRequest(contact);

            try
            {
                await _repo.AddAsync(contact.ToEntity());

                return Ok();
            }
            catch (Exception ex)
            {
                _logger.LogError($"Error during creation of contact. Message: {ex.Message}");
                return BadRequest(contact);
            }
        }

        [HttpPut]
        public async Task<ActionResult<ContactDto>> Put([FromBody] UpdateContactDto contact)
        {
            if (contact == null)
                return BadRequest("Empty body");

            if(!ModelState.IsValid)
                return BadRequest(contact);
            try
            {
                var res = await _repo.UpdateAsync(contact.ToEntity());

                if (res == null)
                    return BadRequest(contact);

                return Ok(res.ToDto());

            }catch(Exception ex)
            {
                _logger.LogError($"Error during update of contact. Message: {ex.Message}");
                return BadRequest(contact);
            }


        }

        [HttpDelete("{id}")]
        public async Task<ActionResult<ContactDto>> Delete(Guid id)
        {

            var res = await _repo.DeleteAsync(id);

            if (res == null)
                return Ok();

            return Ok(res.ToDto());

        }
    }
}
