using System.Net;

namespace Cashflow.Exception.ExceptionsBase;
public class ErrorOnValidationException(List<string> errorMessages) : CashflowException(String.Empty)
{
    private List<string> Errors { get; set; } = errorMessages;

    public override int StatusCode => (int)HttpStatusCode.BadRequest;

    public override List<string> GetErrors()
    {
       return Errors;
    }
}
