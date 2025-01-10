using PipelineProcessingExample.Constants;
using PipelineProcessingExample.Interfaces.Services;

namespace PipelineProcessingExample.Services;

public class PaymentServiceFactory : IPaymentServiceFactory
{
    private readonly IPaymentService _applePayService;
    private readonly IPaymentService _bankService;
    private readonly IPaymentService _creditCardService;
    private readonly IPaymentService _googlePayService;
    private readonly IPaymentService _payPalService;

    public PaymentServiceFactory(
        [FromKeyedServices("ApplePayService")] IPaymentService applePayService,
        [FromKeyedServices("BankService")] IPaymentService bankService,
        [FromKeyedServices("CreditCardService")] IPaymentService creditCardService,
        [FromKeyedServices("GooglePayService")] IPaymentService googlePayService,
        [FromKeyedServices("PayPalService")] IPaymentService payPalService)
    {
        _applePayService = applePayService;
        _bankService = bankService;
        _creditCardService = creditCardService;
        _googlePayService = googlePayService;
        _payPalService = payPalService;
    }

    public IPaymentService Create(PaymentMethod paymentMethod)
    {
        return paymentMethod switch
        {
            PaymentMethod.ApplePay => _applePayService,
            PaymentMethod.Bank => _bankService,
            PaymentMethod.CreditCard => _creditCardService,
            PaymentMethod.GooglePay => _googlePayService,
            PaymentMethod.PayPal => _payPalService,
            _ => throw new NotImplementedException("We do not support this payment method"),
        };
    }
}
