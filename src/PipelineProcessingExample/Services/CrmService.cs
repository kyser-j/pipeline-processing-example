using PipelineProcessingExample.Interfaces.Services;
using PipelineProcessingExample.Models.CRM;

namespace PipelineProcessingExample.Services;

public class CrmService : ICrmService
{
    public Task<Contact?> CreateContact(string firstName, string lastName, string email, string postalCode, CancellationToken cancellationToken)
    {
        return Task.FromResult<Contact?>(new Contact());
    }

    public Task DoSpecialFinancialTask(SpecialFinancialInformation info, bool isNewContact, CancellationToken cancellationToken)
    {
        return Task.CompletedTask;
    }

    public Task<Contact?> GetContact(string firstName, string lastName, string email, string postalCode, CancellationToken cancellationToken)
    {
        return Task.FromResult<Contact?>(new Contact());
    }

    public Task<MarketingCampaign?> GetDefaultMarketingCampaign(CancellationToken cancellationToken)
    {
        return Task.FromResult<MarketingCampaign?>(new MarketingCampaign());
    }

    public Task<MarketingCampaign?> GetMarketingCampaign(string? id, CancellationToken cancellationToken)
    {
        return Task.FromResult<MarketingCampaign?>(new MarketingCampaign());
    }

    public Task<PaymentMethod?> GetPaymentMethod(string contactId, CancellationToken cancellationToken)
    {
        return Task.FromResult<PaymentMethod?>(new PaymentMethod());
    }

    public Task<SpecialFinancialInformation?> GetSpecialFinancialInformation(CancellationToken cancellationToken)
    {
        return Task.FromResult<SpecialFinancialInformation?>(new SpecialFinancialInformation());
    }
}
