using PipelineProcessingExample.Interfaces;
using PipelineProcessingExample.Models;
using PipelineProcessingExample.Models.PaymentResults;

namespace PipelineProcessingExample.Services;

public class ApplePayService : IApplePayService
{
    public Task<ApplePayResults> CaptureOneTime(PaymentRequest paymentRequest, CancellationToken cancellationToken)
    {
        return Task.FromResult(new ApplePayResults());
    }

    public Task<ApplePayResults> CreateSubscription(PaymentRequest paymentRequest, CancellationToken cancellationToken)
    {
        return Task.FromResult(new ApplePayResults());
    }
}
