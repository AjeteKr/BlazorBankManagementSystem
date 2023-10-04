using DATABASEE.Models;
using DATABASEE.Repository;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Identity.Client;
using System.Threading;
using System.Threading.Tasks;

namespace ACCOUNTINGAPI.Controller
{
    [Route("api/[controller]")]
    [ApiController]
    [Authorize]
    public class DepositsController : ControllerBase
    {
        private readonly ILogger<DepositsController> _logger;

        private readonly IRepository<Deposits> _repository;

        public DepositsController(ILogger<DepositsController> logger, IRepository<Deposits> repository)
        {
            _repository = repository;

            _logger = logger;
        }

        [HttpGet("{Id}")]
        public async Task<IActionResult> GetDepositsById(int Id, CancellationToken token)
        {
            Deposits depositsData = await _repository.Get(Id, token);

            if (depositsData == null)

            {

                return NotFound();
            }


            return Ok(depositsData);
        }



        [HttpPost]
        public async Task<IActionResult> CreateDeposits(Deposits newDeposits)
        {
            await _repository.Add(newDeposits);
            return Ok(newDeposits);
        }
        [HttpDelete("{Id}")]
        public async Task<IActionResult> DeleteDeposits(int Id)
        {
            try
            {
                await _repository.Delete(Id);
                return Ok(); 
            }
            catch (Exception ex)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, "Server Error: " + ex.Message);
            }
        }

        [HttpPut("{Id}")]
        public async Task<IActionResult> UpdateDeposits(int Id, Deposits updatedDeposits)
        {
            var existingDeposit = await _repository.Get(Id, CancellationToken.None); 

            if (existingDeposit == null)
            {
                return NotFound();
            }

            existingDeposit.Amount = updatedDeposits.Amount;
            existingDeposit.Deposit_date = updatedDeposits.Deposit_date;

            _repository.Update(existingDeposit);

            return Ok(existingDeposit);
        }


    }
}  