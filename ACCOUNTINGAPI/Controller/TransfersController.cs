using ACCOUNTINGAPI.DTOs;
using DATABASEE.Models;
using DATABASEE.Repository;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace ACCOUNTINGAPI.Controller
{
    [Route("api/[controller]")]
    [ApiController]
    public class TransfersController : ControllerBase
    {
        private readonly ILogger<TransfersController> _logger;

        private readonly IRepository<Transfers> _repository;

        public TransfersController(ILogger<TransfersController> logger, IRepository<Transfers> repository)
        {
            _repository = repository;

            _logger = logger;
        }

        [HttpGet("{Id}")]
        public async Task<IActionResult> GetTransfersById(int Id, CancellationToken token)
        {
            Transfers transfersData = await _repository.Get(Id, token);

            if (transfersData == null)

            {

                return NotFound();
            }


            return Ok(transfersData);
        }



        [HttpPost]
        public async Task<IActionResult> CreateTransfers(Transfers newTransfers)
        {
            await _repository.Add(newTransfers);
            return Ok(newTransfers);
        }

        [HttpDelete("{Id}")]
        public async Task<IActionResult> DeleteTransfers(int Id)
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
        public async Task<IActionResult> UpdateTransfer(int Id, Transfers updatedTransfer)
        {
            var existingTransfer = await _repository.Get(Id, CancellationToken.None); 

            if (existingTransfer == null)
            {
                return NotFound();
            }

            existingTransfer.Amount = updatedTransfer.Amount;
            existingTransfer.Transfer_date = updatedTransfer.Transfer_date;

            _repository.Update(existingTransfer);

            return Ok(existingTransfer);
        }


    }
}
