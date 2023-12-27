using Microsoft.AspNetCore.Mvc;
using TaskSystem.Models;
using TaskSystem.Repositories.Interfaces;

namespace TaskSystem.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UserController : ControllerBase
    {
        private readonly IUserRepository _userRepository;
        public UserController(IUserRepository userRepository)
        {
            _userRepository = userRepository;
        }
        [HttpGet]
        public async Task<ActionResult<List<TaskModel>>> SearchForUsers()
        {
            List<UserModel> users = await _userRepository.SearchForUsers();
            return Ok(users);
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<TaskModel>> SearchForId(int id)
        {
            UserModel user = await _userRepository.SearchForId(id);
            return Ok(user);
        }
        [HttpPost]
        public async Task<ActionResult<UserModel>> Register([FromBody] UserModel userModel)
        {
            UserModel user = await _userRepository.Add(userModel);
            return Ok(user);
        }

    }
}
