using Microsoft.Extensions.Options;
using PipelineProcessingExample.Config;
using PipelineProcessingExample.Constants;
using PipelineProcessingExample.Interfaces;
using PipelineProcessingExample.Models;
using PipelineProcessingExample.Models.PaymentResults;

namespace PipelineProcessingExample.Services;

public class PaymentService : IPaymentService
{
    private readonly AppConfig _appConfig;
    private readonly IApplePayService _applePayService;
    private readonly ICrmService _crmService;
    private readonly IGooglePayService _googlePayService;
    private readonly ILogger<PaymentService> _logger;
    private readonly IMyBankingService _myBankingService;
    private readonly IPayPalService _payPalService;

    public PaymentService(
        IApplePayService applePayService,
        ICrmService crmService,
        IGooglePayService googlePayService,
        ILogger<PaymentService> logger,
        IMyBankingService myBankingService,
        IOptionsMonitor<AppConfig> options,
        IPayPalService payPalService)
    {
        _appConfig = options.CurrentValue;
        _applePayService = applePayService;
        _crmService = crmService;
        _googlePayService = googlePayService;
        _logger = logger;
        _myBankingService = myBankingService;
        _payPalService = payPalService;
    }

    public async Task<bool> ProcessPayment(PaymentRequest paymentRequest, CancellationToken cancellationToken)
    {
        // Process the payers contact information
        var contact = await _crmService.GetContact(paymentRequest.FirstName, paymentRequest.LastName, paymentRequest.Email, paymentRequest.PostalCode, cancellationToken);

        if (contact == null)
        {
            contact = await _crmService.CreateContact(paymentRequest.FirstName, paymentRequest.LastName, paymentRequest.Email, paymentRequest.PostalCode, cancellationToken);
        }

        // Determine marketing campaign attribution
        var marketingCampaign = await _crmService.GetMarketingCampaign(paymentRequest.MarketingCampaignId, cancellationToken);

        if (marketingCampaign == null)
        {
            marketingCampaign = await _crmService.GetDefaultMarketingCampaign(cancellationToken);
        }

        // Determine other information about the financial transaction
        if (paymentRequest.Amount >= _appConfig.SpecialCampaignThreshold)
        {
            var specialFinancialInformation = await _crmService.GetSpecialFinancialInformation(cancellationToken);

            if (specialFinancialInformation != null)
            {
                if (string.IsNullOrEmpty(contact!.Id))
                {
                    // Do another thing if it's a new contact
                    await _crmService.DoSpecialFinancialTask(specialFinancialInformation, isNewContact: true, cancellationToken);
                }
                else
                {
                    // Do something else if it's an existing contact
                    await _crmService.DoSpecialFinancialTask(specialFinancialInformation, isNewContact: true, cancellationToken);
                }
            }
        }

        // Capture funds or setup subscription
        bool paymentProcessed = false;

        if (paymentRequest.PaymentType == PaymentType.OneTime)
        {
            if (paymentRequest.PaymentMethod == PaymentMethod.ApplePay)
            {
                var applePayResults = await _applePayService.CaptureOneTime(paymentRequest, cancellationToken);

                ProcessApplePayResults(applePayResults, isSubscription: paymentRequest.PaymentType == PaymentType.Subscription);
            }

            if (paymentRequest.PaymentMethod == PaymentMethod.GooglePay)
            {
                var googlePayResults = await _googlePayService.CaptureOneTime(paymentRequest, cancellationToken);

                ProcessGooglePayResults(googlePayResults, isSubscription: paymentRequest.PaymentType == PaymentType.Subscription);
            }

            if (paymentRequest.PaymentMethod == PaymentMethod.PayPal)
            {
                var payPalResults = await _payPalService.CaptureOneTime(paymentRequest, cancellationToken);

                ProcessPayPalResults(payPalResults, isSubscription: paymentRequest.PaymentType == PaymentType.Subscription);
            }

            if (paymentRequest.PaymentMethod == PaymentMethod.Bank)
            {
                var bankResults = await _myBankingService.CaptureOneTimeBank(paymentRequest, cancellationToken);

                ProcessBankResults(bankResults, isSubscription: paymentRequest.PaymentType == PaymentType.Subscription);
            }

            if (paymentRequest.PaymentMethod == PaymentMethod.CreditCard)
            {
                var creditCardResults = await _myBankingService.CaptureOneTimeCreditCard(paymentRequest, cancellationToken);

                ProcessCreditCardResults(creditCardResults, isSubscription: paymentRequest.PaymentType == PaymentType.Subscription);
            }
        }
        else if (paymentRequest.PaymentType == PaymentType.Subscription)
        {
            if (paymentRequest.PaymentMethod == PaymentMethod.ApplePay)
            {
                var applePayResults = await _applePayService.CreateSubscription(paymentRequest, cancellationToken);

                ProcessApplePayResults(applePayResults, isSubscription: paymentRequest.PaymentType == PaymentType.Subscription);
            }

            if (paymentRequest.PaymentMethod == PaymentMethod.GooglePay)
            {
                var googlePayResults = await _googlePayService.CreateSubscription(paymentRequest, cancellationToken);

                ProcessGooglePayResults(googlePayResults, isSubscription: paymentRequest.PaymentType == PaymentType.Subscription);
            }

            if (paymentRequest.PaymentMethod == PaymentMethod.PayPal)
            {
                var payPalResults = await _payPalService.CreateSubscription(paymentRequest, cancellationToken);

                ProcessPayPalResults(payPalResults, isSubscription: paymentRequest.PaymentType == PaymentType.Subscription);
            }

            if (paymentRequest.PaymentMethod == PaymentMethod.Bank)
            {
                var bankResults = await _myBankingService.CreateBankSubscription(paymentRequest, cancellationToken);

                ProcessBankResults(bankResults, isSubscription: paymentRequest.PaymentType == PaymentType.Subscription);
            }

            if (paymentRequest.PaymentMethod == PaymentMethod.CreditCard)
            {
                var creditCardResults = await _myBankingService.CreateCreditCardSubscription(paymentRequest, cancellationToken);

                ProcessCreditCardResults(creditCardResults, isSubscription: paymentRequest.PaymentType == PaymentType.Subscription);
            }
        }
        else
        {
            throw new NotImplementedException("We don't support payment types outside of one-time and subscription.");
        }

        return paymentProcessed;
    }

    private void ProcessApplePayResults(ApplePayResults applePayResults, bool isSubscription)
    {
        _logger.LogInformation("Processing");
    }

    private void ProcessGooglePayResults(GooglePayResults googlePayResults, bool isSubscription)
    {
        _logger.LogInformation("Processing");
    }

    private void ProcessPayPalResults(PayPalResults payPalResults, bool isSubscription)
    {
        _logger.LogInformation("Processing");
    }

    private void ProcessBankResults(BankResults bankResults, bool isSubscription)
    {
        _logger.LogInformation("Processing");
    }

    private void ProcessCreditCardResults(CreditCardResults creditCardResults, bool isSubscription)
    {
        _logger.LogInformation("Processing");
    }
}
