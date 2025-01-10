using PipelineProcessingExample.Models;
using PipelineProcessingExample.Models.PaymentResults;

namespace PipelineProcessingExample.Interfaces.Services;

public interface IPayPalService
{
    public Task<PayPalResults> CaptureOneTime(PaymentRequest paymentRequest, CancellationToken cancellationToken);

    public Task<PayPalResults> CreateSubscription(PaymentRequest paymentRequest, CancellationToken cancellationToken);
}
