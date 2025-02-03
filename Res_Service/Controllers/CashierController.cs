using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Res_Service.Models;
using Res_Service.Repositores;

namespace Res_Service.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CashierController : ControllerBase
    {
        private readonly IUserRepository<Cashier> _cashierRepository;
        public CashierController(IUserRepository<Cashier> cashierRepository)
        {
            _cashierRepository = cashierRepository;
        }
        [HttpGet]
        public async Task<IActionResult> GetAllCashiers()
        {
            var cashiers = await _cashierRepository.GetAllUsersAsync();
            return Ok(cashiers);
        }
        [HttpGet("{id}")]
        public async Task<IActionResult> GetCashierById(Guid id)
        {
            var cashier = await _cashierRepository.GetUserByIdAsync(id);
            if (cashier == null)
            {
                return NotFound();
            }
            return Ok(cashier);
        }
        [HttpPost]
        public async Task<IActionResult> CreateCashier([FromBody] Cashier cashier)
        {
            var newCashier = await _cashierRepository.CreateUserAsync(cashier);
            return CreatedAtAction(nameof(GetCashierById), new { id = newCashier.Id }, newCashier);
        }
        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateCashier(Guid id, [FromBody] Cashier cashier)
        {
            if (id != cashier.Id)
            {
                return BadRequest();
            }
            var updatedCashier = await _cashierRepository.UpdateUserAsync(cashier);
            return Ok(updatedCashier);
        }
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteCashier(Guid id)
        {
            var cashier = await _cashierRepository.DeleteUserAsync(id);
            if (cashier == null)
            {
                return NotFound();
            }
            return Ok(cashier);
        }
    }
}
