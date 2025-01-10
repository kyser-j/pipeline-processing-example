using PipelineProcessingExample.Models.CRM;

namespace PipelineProcessingExample.Models;

public class PaymentContext
{
    public Contact? Contact { get; set; }

    public MarketingCampaign? MarketingCampaign { get; set; }

    public SpecialFinancialInformation? SpecialFinancialInformation { get; set; }

    public PaymentRequest PaymentRequest { get; set; } = null!;

    public bool IsNewContact { get; set; } = false;

    public bool Success { get; set; } = false;
}
