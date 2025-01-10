using Microsoft.AspNetCore.Mvc;
using PipelineProcessingExample.Interfaces.Pipelines;
using PipelineProcessingExample.Models;
using System.Text.Json;

namespace PipelineProcessingExample.Controllers;

[ApiController]
[Route("api/[controller]")]
public class PaymentController : ControllerBase
{
    private readonly ILogger<PaymentController> _logger;
    private readonly IPipelineFactory _pipelineFactory;

    public PaymentController(ILogger<PaymentController> logger, IPipelineFactory pipelineFactory)
    {
        _logger = logger;
        _pipelineFactory = pipelineFactory;
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

        var context = new PaymentContext
        {
            PaymentRequest = paymentRequest,
        };

        context = await _pipelineFactory.CreatePipeline(paymentRequest.PaymentType).Run(context, cancellationToken);

        return context.Success ? Ok() : BadRequest();
    }
}
