using ExpenseControl.Application.Transactions.Create;
using ExpenseControl.Application.Transactions.List;
using Microsoft.AspNetCore.Mvc;

namespace ExpenseControl.Api.Controllers;

public class TransactionsController : BaseController
{
    [HttpPost]
    public async Task<IActionResult> Create(
        [FromBody] CreateTransactionRequest request,
        [FromServices] CreateTransactionHandler handler)
    {
        var id = await handler.Handle(request);
        return CreatedAtAction(nameof(GetAll), new { id }, null);
    }

    [HttpGet]
    public async Task<ActionResult<IEnumerable<TransactionDto>>> GetAll(
        [FromServices] ListTransactionHandler handler)
    {
        var result = await handler.Handle();
        return Ok(result);
    }
}

