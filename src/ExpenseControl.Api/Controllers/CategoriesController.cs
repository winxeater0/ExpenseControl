using ExpenseControl.Application.Categories.Create;
using ExpenseControl.Application.Categories.List;
using Microsoft.AspNetCore.Mvc;

namespace ExpenseControl.Api.Controllers;

public class CategoriesController : BaseController
{
    [HttpPost]
    public async Task<IActionResult> Create(
        [FromBody] CreateCategoryRequest request,
        [FromServices] CreateCategoryHandler handler)
    {
        var id = await handler.Handle(request);
        return CreatedAtAction(nameof(GetAll), new { id }, null);
    }

    [HttpGet]
    public async Task<ActionResult<IEnumerable<CategoryDto>>> GetAll(
        [FromServices] ListCategoryHandler handler)
    {
        var result = await handler.Handle();
        return Ok(result);
    }
}

