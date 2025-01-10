using PipelineProcessingExample.Models;

namespace PipelineProcessingExample.Interfaces.Services;

public interface IPaymentService
{
    public Task<bool> ProcessPayment(PaymentRequest paymentRequest, CancellationToken cancellationToken);
}
