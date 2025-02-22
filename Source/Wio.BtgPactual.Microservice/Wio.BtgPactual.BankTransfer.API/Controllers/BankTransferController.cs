using Microsoft.AspNetCore.Mvc;
using Wio.BtgPactual.BankTransfer.Application.Interfaces;
using Wio.BtgPactual.BankTransfer.Domain.Entities;

namespace Wio.BtgPactual.BankTransfer.API.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class BankTransferController : ControllerBase
    {
        private readonly ITransferService _transferService;

        public BankTransferController(ITransferService transferService)
        {
            _transferService = transferService;
        }

        [HttpGet]
        public ActionResult<IEnumerable<TransferLog>> Get()
        {
            return Ok(_transferService.GetTransferLogs());
        }
    }
}
