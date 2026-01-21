using ExpenseControl.Application.Reports.CategoryTotals;
using ExpenseControl.Application.Reports.PeopleTotals;
using Microsoft.AspNetCore.Mvc;

namespace ExpenseControl.Api.Controllers;

public class ReportsController : BaseController
{
    [HttpGet("people")]
    public async Task<ActionResult<PeopleTotalsSummaryDto>> GetPeopleTotals(
        [FromServices] GetPeopleTotalsHandler handler)
    {
        var result = await handler.Handle();
        return Ok(result);
    }

    [HttpGet("categories")]
    public async Task<ActionResult<CategoryTotalsSummaryDto>> GetCategoryTotals(
        [FromServices] GetCategoryTotalsHandler handler)
    {
        var result = await handler.Handle();
        return Ok(result);
    }
}

