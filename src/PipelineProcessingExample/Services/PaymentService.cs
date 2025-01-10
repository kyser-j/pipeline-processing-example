using PipelineProcessingExample.Constants;
using PipelineProcessingExample.Interfaces.Pipelines;
using PipelineProcessingExample.Interfaces.Services;
using PipelineProcessingExample.Models;

namespace PipelineProcessingExample.Services;

public class PaymentService : IPaymentService
{
    private readonly IPipeline _oneTimePipeline;
    private readonly IPipeline _subscriptionPipeline;

    public PaymentService(
        [FromKeyedServices("OneTimePipeline")] IPipeline oneTimePipeline,
        [FromKeyedServices("SubscriptionPipeline")] IPipeline subscriptionPipeline)
    {
        _oneTimePipeline = oneTimePipeline;
        _subscriptionPipeline = subscriptionPipeline;
    }

    public async Task<bool> ProcessPayment(PaymentRequest paymentRequest, CancellationToken cancellationToken)
    {
        // Capture funds or setup subscription
        var context = new PaymentContext
        {
            PaymentRequest = paymentRequest,
        };

        if (paymentRequest.PaymentType == PaymentType.OneTime)
        {
            context = await _oneTimePipeline.Run(context, cancellationToken);
        }
        else if (paymentRequest.PaymentType == PaymentType.Subscription)
        {
            context = await _subscriptionPipeline.Run(context, cancellationToken);
        }
        else
        {
            throw new NotImplementedException("We don't support payment types outside of one-time and subscription.");
        }

        return context.Success;
    }
}
