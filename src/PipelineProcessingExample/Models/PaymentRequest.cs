using PipelineProcessingExample.Constants;

namespace PipelineProcessingExample.Models;

public class PaymentRequest
{
    public double Amount { get; set; }

    public ApplePayInfo? ApplePayInfo { get; set; }

    public BankInfo? BankInfo { get; set; }

    public string City { get; set; } = string.Empty;

    public DateTime CreateDate { get; set; }

    public CreditCardInfo? CreditCardInfo { get; set; }

    public string Country { get; set; } = string.Empty;

    public string Email { get; set; } = string.Empty;

    public string FirstName { get; set; } = string.Empty;

    public GooglePayInfo? GooglePayInfo { get; set; }

    public string LastName { get; set; } = string.Empty;

    public string? MarketingCampaignId { get; set; }

    public PaymentMethod PaymentMethod { get; set; }

    public PaymentType PaymentType { get; set; }

    public PayPalInfo? PayPalInfo { get; set; }

    public string PostalCode { get; set; } = string.Empty;

    public string State { get; set; } = string.Empty;

    public string StreetAddress { get; set; } = string.Empty;
}
