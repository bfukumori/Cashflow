using Cashflow.Application.UseCases.Expenses.GetAll;
using Cashflow.Application.UseCases.Expenses.Register;
using Cashflow.Communication.Requests.Expenses;
using Cashflow.Communication.Responses;
using Cashflow.Communication.Responses.Expenses;
using Microsoft.AspNetCore.Mvc;

namespace Cashflow.Api.Controllers;

[Route("api/[controller]")]
[ApiController]
public class ExpensesController : ControllerBase
{
    [HttpPost]
    [ProducesResponseType(typeof(ResponseRegisteredExpenseJson), StatusCodes.Status201Created)]
    [ProducesResponseType(typeof(ResponseErrorsJson), StatusCodes.Status400BadRequest)]
    public async Task<IActionResult> Register([FromServices] IRegisterExpenseUseCase useCase, [FromBody] RequestRegisterExpenseJson request)
    {
        var response = await useCase.Execute(request);

        return Created(string.Empty, response);
    }

    [HttpGet]
    [ProducesResponseType(typeof(ResponseExpensesJson), StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status204NoContent)]
    public async Task<IActionResult> GetAll([FromServices] IGetAllExpensesUseCase useCase)
    {
        var response = await useCase.Execute();

        if(response.Expenses.Count == 0)
        {
            return NoContent();
        }

        return Ok(response);
    }
}
