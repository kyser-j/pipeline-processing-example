using PipelineProcessingExample.Constants;

namespace PipelineProcessingExample.Interfaces.Pipelines;

public interface IPipelineFactory
{
    IPipeline CreatePipeline(PaymentType paymentType);
}
