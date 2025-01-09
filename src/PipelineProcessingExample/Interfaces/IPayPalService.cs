﻿using PipelineProcessingExample.Models;
using PipelineProcessingExample.Models.PaymentResults;

namespace PipelineProcessingExample.Interfaces;

public interface IPayPalService
{
    public Task<PayPalResults> CaptureOneTime(PaymentRequest paymentRequest, CancellationToken cancellationToken);

    public Task<PayPalResults> CreateSubscription(PaymentRequest paymentRequest, CancellationToken cancellationToken);
}
