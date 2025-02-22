using Microsoft.AspNetCore.Mvc;
using Wio.BtgPactual.Banking.Application.Entities;
using Wio.BtgPactual.Banking.Application.Interfaces;
using Wio.BtgPactual.Banking.Domain.Entities;

namespace Wio.BtgPactual.Banking.API.Controllers;

[ApiController]
[Route("api/[controller]")]
public class BankController : ControllerBase
{
    private readonly IAccountService _accountService;

    public BankController(IAccountService accountService) => _accountService = accountService;  

    [HttpGet]
    public ActionResult<IEnumerable<Account>> Get()
    {
        return Ok(_accountService.GetAccounts());
    }

    [HttpPost]
    public IActionResult Post([FromBody] AccountTransferred accountTransferred)
    {      
        _accountService.Transfer(accountTransferred);
        return Ok(accountTransferred);
    }
}
