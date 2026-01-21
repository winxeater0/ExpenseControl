using ExpenseControl.Application.People.Create;
using ExpenseControl.Application.People.List;
using Microsoft.AspNetCore.Mvc;

namespace ExpenseControl.Api.Controllers;

public class PeopleController : BaseController
{
    [HttpPost]
    public async Task<IActionResult> Create(
        [FromBody] CreatePersonRequest request,
        [FromServices] CreatePersonHandler handler)
    {
        var id = await handler.Handle(request);
        return CreatedAtAction(nameof(GetAll), new { id }, null);
    }

    [HttpGet]
    public async Task<ActionResult<IEnumerable<PersonDto>>> GetAll(
        [FromServices] ListPeopleHandler handler)
    {
        var result = await handler.Handle();
        return Ok(result);
    }

    [HttpDelete("{id:guid}")]
    public async Task<IActionResult> Delete(
        Guid id,
        [FromServices] DeletePersonHandler handler)
    {
        await handler.Handle(id);
        return NoContent();
    }
}

