using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Res_Service.Models;
using Res_Service.Repositores;

namespace Res_Service.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ServerController : ControllerBase
    {
        private readonly IUserRepository<Server> _serverRepository;

        public ServerController(IUserRepository<Server> serverRepository)
        {
            _serverRepository = serverRepository;
        }

        [HttpGet]
        public async Task<IActionResult> GetAllservers()
        {
            var servers = await _serverRepository.GetAllUsersAsync();
            return Ok(servers);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetserverById(Guid id)
        {
            var server = await _serverRepository.GetUserByIdAsync(id);
            if (server == null)
            {
                return NotFound();
            }
            return Ok(server);
        }

        [HttpPost]
        public async Task<IActionResult> Createserver([FromBody] Server server)
        {
            var newserver = await _serverRepository.CreateUserAsync(server);
            return CreatedAtAction(nameof(GetserverById), new { id = newserver.Id }, newserver);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> Updateserver(Guid id, [FromBody] Server server)
        {
            if (id != server.Id)
            {
                return BadRequest();
            }
            var updatedserver = await _serverRepository.UpdateUserAsync(server);
            return Ok(updatedserver);
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> Deleteserver(Guid id)
        {
            var server = await _serverRepository.DeleteUserAsync(id);
            if (server == null)
            {
                return NotFound();
            }
            return Ok(server);
        }
    }

}
