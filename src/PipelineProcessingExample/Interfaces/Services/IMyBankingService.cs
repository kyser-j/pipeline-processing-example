using PipelineProcessingExample.Models;
using PipelineProcessingExample.Models.PaymentResults;

namespace PipelineProcessingExample.Interfaces.Services;

public interface IMyBankingService
{
    public Task<BankResults> CaptureOneTimeBank(PaymentRequest paymentRequest, CancellationToken cancellationToken);

    public Task<CreditCardResults> CaptureOneTimeCreditCard(PaymentRequest paymentRequest, CancellationToken cancellationToken);

    public Task<BankResults> CreateBankSubscription(PaymentRequest paymentRequest, CancellationToken cancellationToken);

    public Task<CreditCardResults> CreateCreditCardSubscription(PaymentRequest paymentRequest, CancellationToken cancellationToken);
}
