using PipelineProcessingExample.Interfaces.ProcessingSteps;
using PipelineProcessingExample.Interfaces.Services;
using PipelineProcessingExample.Models;

namespace PipelineProcessingExample.ProcessingSteps;

public class SubscriptionProcessingStep : IProcessingStep
{
    private readonly IPaymentServiceFactory _paymentServiceFactory;

    public SubscriptionProcessingStep(IPaymentServiceFactory paymentServiceFactory)
    {
        _paymentServiceFactory = paymentServiceFactory;
    }

    public async Task<PaymentContext> Process(PaymentContext context, CancellationToken cancellationToken)
    {
        var results = await _paymentServiceFactory.Create(context.PaymentRequest.PaymentMethod).CreateSubscription(context, cancellationToken);
        context.PaymentResult = results;
        return context;
    }
}
