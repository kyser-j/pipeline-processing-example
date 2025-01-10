using PipelineProcessingExample.Interfaces.Services;
using PipelineProcessingExample.Models;

namespace PipelineProcessingExample.Services;

public class ApplePayService : IPaymentService
{
    private readonly ILogger<ApplePayService> _logger;

    public ApplePayService(ILogger<ApplePayService> logger)
    {
        _logger = logger;
    }

    public Task<PaymentResult> CaptureOneTime(PaymentContext context, CancellationToken cancellationToken)
    {
        var paymentResult = new PaymentResult();
        ProcessResults(paymentResult);
        return Task.FromResult(paymentResult);
    }

    public Task<PaymentResult> CreateSubscription(PaymentContext context, CancellationToken cancellationToken)
    {
        var paymentResult = new PaymentResult();
        ProcessResults(paymentResult);
        return Task.FromResult(paymentResult);
    }

    private void ProcessResults(PaymentResult result)
    {
        _logger.LogInformation("Processing");
    }
}
