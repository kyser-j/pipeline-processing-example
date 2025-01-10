using PipelineProcessingExample.Models;

namespace PipelineProcessingExample.Interfaces.ProcessingSteps;

public interface IProcessingStep
{
    Task<PaymentContext> Process(PaymentContext context, CancellationToken cancellationToken);
}
