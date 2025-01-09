using PipelineProcessingExample.Interfaces;
using PipelineProcessingExample.Models;
using PipelineProcessingExample.Models.PaymentResults;

namespace PipelineProcessingExample.Services;

public class GooglePayService : IGooglePayService
{
    public Task<GooglePayResults> CaptureOneTime(PaymentRequest paymentRequest, CancellationToken cancellationToken)
    {
        return Task.FromResult(new GooglePayResults());
    }

    public Task<GooglePayResults> CreateSubscription(PaymentRequest paymentRequest, CancellationToken cancellationToken)
    {
        return Task.FromResult(new GooglePayResults());
    }
}
