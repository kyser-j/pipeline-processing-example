using Microsoft.AspNetCore.Mvc;
using PipelineProcessingExample.Interfaces.Services;
using PipelineProcessingExample.Models;
using System.Text.Json;

namespace PipelineProcessingExample.Controllers;

[ApiController]
[Route("api/[controller]")]
public class PaymentController : ControllerBase
{
    private readonly ILogger<PaymentController> _logger;
    private readonly IPaymentService _paymentService;

    public PaymentController(ILogger<PaymentController> logger, IPaymentService paymentService)
    {
        _logger = logger;
        _paymentService = paymentService;
    }

    [HttpPost]
    public async Task<ActionResult> Post(CancellationToken cancellationToken)
    {
        // Get payment request from body
        using var streamReader = new StreamReader(Request.Body);
        var body = await streamReader.ReadToEndAsync(cancellationToken);

        PaymentRequest? paymentRequest;
        try
        {
            paymentRequest = JsonSerializer.Deserialize<PaymentRequest>(body, new JsonSerializerOptions(JsonSerializerDefaults.Web));
        }
        catch (Exception ex)
        {
            _logger.LogError(ex, "Unable to parse request.");
            return BadRequest();
        }

        if (paymentRequest == null)
        {
            _logger.LogError("Unable to parse request");
            return BadRequest();
        }

        bool paymentCaptured = await _paymentService.ProcessPayment(paymentRequest, cancellationToken);

        return paymentCaptured ? Ok() : BadRequest();
    }
}
