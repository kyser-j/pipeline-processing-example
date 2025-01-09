using PipelineProcessingExample.Models.CRM;

namespace PipelineProcessingExample.Interfaces;

public interface ICrmService
{
    Task<Contact?> CreateContact(string firstName, string lastName, string email, string postalCode, CancellationToken cancellationToken);

    Task DoSpecialFinancialTask(SpecialFinancialInformation info, bool isNewContact, CancellationToken cancellationToken);

    Task<Contact?> GetContact(string firstName, string lastName, string email, string postalCode, CancellationToken cancellationToken);

    Task<MarketingCampaign?> GetDefaultMarketingCampaign(CancellationToken cancellationToken);

    Task<MarketingCampaign?> GetMarketingCampaign(string? id, CancellationToken cancellationToken);

    Task<PaymentMethod?> GetPaymentMethod(string contactId, CancellationToken cancellationToken);

    Task<SpecialFinancialInformation?> GetSpecialFinancialInformation(CancellationToken cancellationToken);
}
