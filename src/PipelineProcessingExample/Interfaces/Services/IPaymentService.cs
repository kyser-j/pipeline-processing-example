using PipelineProcessingExample.Models;

namespace PipelineProcessingExample.Interfaces.Services;

public interface IPaymentService
{
    Task<PaymentResult> CaptureOneTime(PaymentContext context, CancellationToken cancellationToken);

    Task<PaymentResult> CreateSubscription(PaymentContext context, CancellationToken cancellationToken);
}
