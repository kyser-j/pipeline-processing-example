using PipelineProcessingExample.Constants;
using PipelineProcessingExample.Interfaces.Pipelines;

namespace PipelineProcessingExample.Pipelines;

public class PipelineFactory : IPipelineFactory
{
    private readonly IPipeline _oneTimePipeline;
    private readonly IPipeline _subscriptionPipeline;

    public PipelineFactory(
        [FromKeyedServices("OneTimePipeline")] IPipeline oneTimePipeline,
        [FromKeyedServices("SubscriptionPipeline")] IPipeline subscriptionPipeline)
    {
        _oneTimePipeline = oneTimePipeline;
        _subscriptionPipeline = subscriptionPipeline;
    }

    public IPipeline CreatePipeline(PaymentType paymentType)
    {
        return paymentType switch
        {
            PaymentType.OneTime => _oneTimePipeline,
            PaymentType.Subscription => _subscriptionPipeline,
            _ => throw new NotImplementedException("We don't support payment types outside of one-time and subscription.")
        };
    }
}
