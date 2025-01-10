using PipelineProcessingExample.Models;

namespace PipelineProcessingExample.Interfaces.Pipelines;

public interface IPipeline
{
    Task<PaymentContext> Run(PaymentContext context, CancellationToken cancellationToken);
}
