﻿using PipelineProcessingExample.Models;
using PipelineProcessingExample.Models.PaymentResults;

namespace PipelineProcessingExample.Interfaces;

public interface IGooglePayService
{
    public Task<GooglePayResults> CaptureOneTime(PaymentRequest paymentRequest, CancellationToken cancellationToken);

    public Task<GooglePayResults> CreateSubscription(PaymentRequest paymentRequest, CancellationToken cancellationToken);
}
