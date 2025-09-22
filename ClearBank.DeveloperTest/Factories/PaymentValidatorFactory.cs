using System;
using ClearBank.DeveloperTest.Enums;
using ClearBank.DeveloperTest.Validators;
using Microsoft.Extensions.DependencyInjection;

namespace ClearBank.DeveloperTest.Factories;

public class PaymentValidatorFactory : IPaymentValidatorFactory
{
    private readonly IServiceProvider _serviceProvider;

    public PaymentValidatorFactory(IServiceProvider serviceProvider)
    {
        _serviceProvider = serviceProvider;
    }

    public IPaymentValidator Create(PaymentScheme paymentScheme)
    {
        return _serviceProvider.GetKeyedService<IPaymentValidator>(paymentScheme);
    }
}