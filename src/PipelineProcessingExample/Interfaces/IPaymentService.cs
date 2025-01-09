using PipelineProcessingExample.Models;

namespace PipelineProcessingExample.Interfaces;

public interface IPaymentService
{
    public Task<bool> ProcessPayment(PaymentRequest paymentRequest, CancellationToken cancellationToken);
}
