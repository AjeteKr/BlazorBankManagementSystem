using DATABASEE.Models;
using DATABASEE.Repository;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.IdentityModel.Tokens;
using Swashbuckle.AspNetCore.Annotations;

namespace ACCOUNTINGAPI.Controller
{
    [Route("api/[controller]")]
    [ApiController]
    public class WithdrawsController : ControllerBase
    {
        private readonly ILogger<WithdrawsController> _logger;

        private readonly IRepository<Withdraws> _repository;

        public WithdrawsController(ILogger<WithdrawsController> logger, IRepository<Withdraws> repository)
        {
            _repository = repository;

            _logger = logger;
        }


        [HttpGet("{Id}")]
        public async Task<IActionResult> GetWithdrawById(int Id, CancellationToken token)
        {
            Withdraws withdrawsData = await _repository.Get(Id, token);

            if  (withdrawsData == null)

            {

                return NotFound();
            }    


            return Ok(withdrawsData);
        }



        [HttpPost]
        public async Task<IActionResult> CreateWithdraw(Withdraws newWithdraw)
        {
            await _repository.Add(newWithdraw);
            return Ok(newWithdraw);
        }

        [HttpDelete("{Id}")]
        public async Task<IActionResult> DeleteWithdraw(int Id)
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
        public async Task<IActionResult> UpdateWithdraw(int Id, Withdraws updatedWithdraw)
        {
            var existingWithdraw = await _repository.Get(Id, CancellationToken.None); 

            if (existingWithdraw == null)
            {
                return NotFound();
            }

            existingWithdraw.User = updatedWithdraw.User;
            existingWithdraw.Amount = updatedWithdraw.Amount;
            existingWithdraw.Withdraw_date = updatedWithdraw.Withdraw_date;

            _repository.Update(existingWithdraw);

            return Ok(existingWithdraw);
        }


    }
}

