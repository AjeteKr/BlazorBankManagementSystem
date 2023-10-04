using DATABASEE.Models;
using DATABASEE.Repository;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace ACCOUNTINGAPI.Controller
{
    [Route("api/[controller]")]
    [ApiController]
    public class UsersController : ControllerBase
    {
        private readonly ILogger<UsersController> _logger;

        private readonly IRepository<Users> _repository;

        public UsersController(ILogger<UsersController> logger, IRepository<Users> repository)
        {
            _repository = repository;

            _logger = logger;
        }

        [HttpGet("{Id}")]
        public async Task<IActionResult> GetUsersById(int Id, CancellationToken token)
        {
            Users usersData = await _repository.Get(Id, token);

            if (usersData == null)

            {
                return NotFound();
            }
            return Ok(usersData);
        }

        [HttpPost]
        public async Task<IActionResult> CreateUsers(Users newUsers)
        {
            await _repository.Add(newUsers);
            return Ok(newUsers);
        }
        [HttpDelete("{Id}")]
        public async Task<IActionResult> DeleteUsers(int Id)
        {
            try
            {
                await _repository.Delete(Id);
                return NoContent(); 
            }
            catch (Exception ex)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, "Server Error: " + ex.Message);
            }
        }

        [HttpPut("{Id}")]
        public async Task<IActionResult> UpdateUser(int Id, Users updatedUser)
        {
            var existingUser = await _repository.Get(Id, CancellationToken.None); 

            if (existingUser == null)
            {
                return NotFound();
            }

            existingUser.Username = updatedUser.Username;
            existingUser.Pin = updatedUser.Pin;
            existingUser.Account_Number = updatedUser.Account_Number;
            existingUser.Balance = updatedUser.Balance;
            existingUser.User_role = updatedUser.User_role;
            existingUser.Created_date = updatedUser.Created_date;

            _repository.Update(existingUser);

            return Ok(existingUser);
        }


    }
}
