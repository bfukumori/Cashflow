using Bogus;
using Cashflow.Communication.Enums;
using Cashflow.Communication.Requests.Expenses;

namespace CommonTestUtilities.Requests;
public class RequestRegisterExpenseJsonBuilder
{
    public static RequestRegisterExpenseJson Build()
    {
        return new Faker<RequestRegisterExpenseJson>()
            .RuleFor(r => r.Title, faker => faker.Commerce.ProductName())
            .RuleFor(r => r.Description, faker => faker.Commerce.ProductDescription())
            .RuleFor(r => r.Date, faker => faker.Date.Past())
            .RuleFor(r => r.Amount, faker => faker.Finance.Amount(min: 1, max: 1000))
            .RuleFor(r => r.PaymentType, faker => faker.PickRandom<PaymentType>());
    }
}
