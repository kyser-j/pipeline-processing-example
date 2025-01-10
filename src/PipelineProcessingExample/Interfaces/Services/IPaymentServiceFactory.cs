using PipelineProcessingExample.Constants;

namespace PipelineProcessingExample.Interfaces.Services;

public interface IPaymentServiceFactory
{
    IPaymentService Create(PaymentMethod paymentMethod);
}
