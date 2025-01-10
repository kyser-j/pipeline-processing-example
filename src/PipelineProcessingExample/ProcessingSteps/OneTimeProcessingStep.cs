using PipelineProcessingExample.Constants;
using PipelineProcessingExample.Interfaces.ProcessingSteps;
using PipelineProcessingExample.Interfaces.Services;
using PipelineProcessingExample.Models;
using PipelineProcessingExample.Models.PaymentResults;

namespace PipelineProcessingExample.ProcessingSteps;

public class OneTimeProcessingStep : IProcessingStep
{
    private readonly IApplePayService _applePayService;
    private readonly ICrmService _crmService;
    private readonly IGooglePayService _googlePayService;
    private ILogger<OneTimeProcessingStep> _logger;
    private readonly IMyBankingService _myBankingService;
    private readonly IPayPalService _payPalService;

    public OneTimeProcessingStep(
        IApplePayService applePayService,
        ICrmService crmService,
        IGooglePayService googlePayService,
        ILogger<OneTimeProcessingStep> logger,
        IMyBankingService myBankingService,
        IPayPalService payPalService)
    {
        _applePayService = applePayService;
        _crmService = crmService;
        _googlePayService = googlePayService;
        _logger = logger;
        _myBankingService = myBankingService;
        _payPalService = payPalService;
    }

    public async Task<PaymentContext> Process(PaymentContext context, CancellationToken cancellationToken)
    {
        if (context.PaymentRequest.PaymentMethod == PaymentMethod.ApplePay)
        {
            var applePayResults = await _applePayService.CaptureOneTime(context.PaymentRequest, cancellationToken);

            ProcessApplePayResults(applePayResults);
        }

        if (context.PaymentRequest.PaymentMethod == PaymentMethod.GooglePay)
        {
            var googlePayResults = await _googlePayService.CaptureOneTime(context.PaymentRequest, cancellationToken);

            ProcessGooglePayResults(googlePayResults);
        }

        if (context.PaymentRequest.PaymentMethod == PaymentMethod.PayPal)
        {
            var payPalResults = await _payPalService.CaptureOneTime(context.PaymentRequest, cancellationToken);

            ProcessPayPalResults(payPalResults);
        }

        if (context.PaymentRequest.PaymentMethod == PaymentMethod.Bank)
        {
            var bankResults = await _myBankingService.CaptureOneTimeBank(context.PaymentRequest, cancellationToken);

            ProcessBankResults(bankResults);
        }

        if (context.PaymentRequest.PaymentMethod == PaymentMethod.CreditCard)
        {
            var creditCardResults = await _myBankingService.CaptureOneTimeCreditCard(context.PaymentRequest, cancellationToken);

            ProcessCreditCardResults(creditCardResults);
        }

        return context;
    }

    private void ProcessApplePayResults(ApplePayResults applePayResults)
    {
        _logger.LogInformation("Processing");
    }

    private void ProcessGooglePayResults(GooglePayResults googlePayResults)
    {
        _logger.LogInformation("Processing");
    }

    private void ProcessPayPalResults(PayPalResults payPalResults)
    {
        _logger.LogInformation("Processing");
    }

    private void ProcessBankResults(BankResults bankResults)
    {
        _logger.LogInformation("Processing");
    }

    private void ProcessCreditCardResults(CreditCardResults creditCardResults)
    {
        _logger.LogInformation("Processing");
    }
}
