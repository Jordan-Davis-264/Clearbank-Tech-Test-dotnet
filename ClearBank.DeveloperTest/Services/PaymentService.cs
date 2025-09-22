using ClearBank.DeveloperTest.Factories;
using ClearBank.DeveloperTest.Options;
using ClearBank.DeveloperTest.Types;
using Microsoft.Extensions.Options;

namespace ClearBank.DeveloperTest.Services;

public class PaymentService : IPaymentService
{
    private readonly DataStoreOptions _dataStoreOptions;
    private readonly IDataStoreFactory _dataStoreFactory;
    private readonly IPaymentValidatorFactory _paymentValidatorFactory;

    public PaymentService(IOptions<DataStoreOptions> dataStoreOptions, IDataStoreFactory dataStoreFactory, IPaymentValidatorFactory paymentValidatorFactory)
    {
        _dataStoreFactory = dataStoreFactory;
        _paymentValidatorFactory = paymentValidatorFactory;
        _dataStoreOptions = dataStoreOptions.Value;
    }

    public MakePaymentResult MakePayment(MakePaymentRequest request)
    {
        var dataStore = _dataStoreFactory.Create(_dataStoreOptions.DataStoreType);
        var account = dataStore.GetAccount(request.DebtorAccountNumber);

        var paymentValidator = _paymentValidatorFactory.Create(request.PaymentScheme);
        var result = new MakePaymentResult
        {
            Success = paymentValidator.Validate(account, request)
        };

        if (!result.Success) return result;

        account.Balance -= request.Amount;
        dataStore.UpdateAccount(account);

        return result;
    }
}