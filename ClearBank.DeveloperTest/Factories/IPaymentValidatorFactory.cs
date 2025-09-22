using ClearBank.DeveloperTest.Enums;
using ClearBank.DeveloperTest.Validators;

namespace ClearBank.DeveloperTest.Factories;

public interface IPaymentValidatorFactory
{
    IPaymentValidator Create(PaymentScheme paymentScheme);
}