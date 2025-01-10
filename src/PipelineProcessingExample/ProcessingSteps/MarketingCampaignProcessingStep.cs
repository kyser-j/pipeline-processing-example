using PipelineProcessingExample.Interfaces.ProcessingSteps;
using PipelineProcessingExample.Interfaces.Services;
using PipelineProcessingExample.Models;

namespace PipelineProcessingExample.ProcessingSteps;

public class MarketingCampaignProcessingStep : IProcessingStep
{
    private readonly ICrmService _crmService;

    public MarketingCampaignProcessingStep(ICrmService crmService)
    {
        _crmService = crmService;
    }

    public async Task<PaymentContext> Process(PaymentContext context, CancellationToken cancellationToken)
    {
        // Determine marketing campaign attribution
        var marketingCampaign = await _crmService.GetMarketingCampaign(context.PaymentRequest.MarketingCampaignId, cancellationToken);

        if (marketingCampaign == null)
        {
            marketingCampaign = await _crmService.GetDefaultMarketingCampaign(cancellationToken);
        }

        context.MarketingCampaign = marketingCampaign;
        return context;
    }
}
