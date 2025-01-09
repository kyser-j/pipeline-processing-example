using PipelineProcessingExample.Interfaces;
using PipelineProcessingExample.Models;
using PipelineProcessingExample.Models.PaymentResults;

namespace PipelineProcessingExample.Services;

public class PayPalService : IPayPalService
{
    public Task<PayPalResults> CaptureOneTime(PaymentRequest paymentRequest, CancellationToken cancellationToken)
    {
        return Task.FromResult(new PayPalResults());
    }

    public Task<PayPalResults> CreateSubscription(PaymentRequest paymentRequest, CancellationToken cancellationToken)
    {
        return Task.FromResult(new PayPalResults());
    }
}
