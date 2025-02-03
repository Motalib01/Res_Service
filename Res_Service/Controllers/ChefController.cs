using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Res_Service.Models;
using Res_Service.Repositores;

namespace Res_Service.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ChefController : ControllerBase
    {
        private readonly IUserRepository<Chef> _chefRepository;

        public ChefController(IUserRepository<Chef> chefRepository)
        {
            _chefRepository = chefRepository;
        }

        [HttpGet]
        public async Task<IActionResult> GetAllChefs()
        {
            var chefs= await _chefRepository.GetAllUsersAsync();
            return Ok(chefs);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetChefById(Guid id)
        {
            var chef = await _chefRepository.GetUserByIdAsync(id);
            if (chef == null)
            {
                return NotFound();
            }
            return Ok(chef);
        }

        [HttpPost]
        public async Task<IActionResult> CreateChef([FromBody] Chef chef)
        {
            var newChef = await _chefRepository.CreateUserAsync(chef);
            return CreatedAtAction(nameof(GetChefById), new { id = newChef.Id }, newChef);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateChef(Guid id, [FromBody] Chef chef)
        {
            if (id != chef.Id)
            {
                return BadRequest();
            }
            var updatedChef = await _chefRepository.UpdateUserAsync(chef);
            return Ok(updatedChef);
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteChef(Guid id)
        {
            var chef = await _chefRepository.DeleteUserAsync(id);
            if (chef == null)
            {
                return NotFound();
            }
            return Ok(chef);
        }
    }
}
