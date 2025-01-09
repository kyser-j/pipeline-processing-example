using PipelineProcessingExample.Interfaces;
using PipelineProcessingExample.Models;
using PipelineProcessingExample.Models.PaymentResults;

namespace PipelineProcessingExample.Services;

public class MyBankingService : IMyBankingService
{
    public Task<BankResults> CaptureOneTimeBank(PaymentRequest paymentRequest, CancellationToken cancellationToken)
    {
        return Task.FromResult(new BankResults());
    }

    public Task<CreditCardResults> CaptureOneTimeCreditCard(PaymentRequest paymentRequest, CancellationToken cancellationToken)
    {
        return Task.FromResult(new CreditCardResults());
    }

    public Task<BankResults> CreateBankSubscription(PaymentRequest paymentRequest, CancellationToken cancellationToken)
    {
        return Task.FromResult(new BankResults());
    }

    public Task<CreditCardResults> CreateCreditCardSubscription(PaymentRequest paymentRequest, CancellationToken cancellationToken)
    {
        return Task.FromResult(new CreditCardResults());
    }
}
