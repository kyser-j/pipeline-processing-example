using PipelineProcessingExample.Models;
using PipelineProcessingExample.Models.PaymentResults;

namespace PipelineProcessingExample.Interfaces;

public interface IApplePayService
{
    public Task<ApplePayResults> CaptureOneTime(PaymentRequest paymentRequest, CancellationToken cancellationToken);

    public Task<ApplePayResults> CreateSubscription(PaymentRequest paymentRequest, CancellationToken cancellationToken);
}
