﻿using PipelineProcessingExample.Interfaces.Services;
using PipelineProcessingExample.Models;

namespace PipelineProcessingExample.Services;

public class PayPalService : IPaymentService
{
    private readonly ILogger<PayPalService> _logger;

    public PayPalService(ILogger<PayPalService> logger)
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
