using System.Net;

namespace Cashflow.Exception.ExceptionsBase;
public class NotFoundException(string message) : CashflowException(message)
{
    public override int StatusCode => (int)HttpStatusCode.NotFound;

    public override List<string> GetErrors()
    {
        return [Message];
    }
}
