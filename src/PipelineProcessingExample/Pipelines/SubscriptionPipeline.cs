using PipelineProcessingExample.Interfaces.Pipelines;
using PipelineProcessingExample.Models;
using PipelineProcessingExample.ProcessingSteps;

namespace PipelineProcessingExample.Pipelines;

public class SubscriptionPipeline : IPipeline
{
    private readonly ContactProcessingStep _contactProcessingStep;
    private readonly MarketingCampaignProcessingStep _marketingCampaignProcessingStep;
    private readonly SpecialFinancialInformationProcessingStep _specialFinancialInformationProcessingStep;
    private readonly SubscriptionProcessingStep _subscriptionProcessingStep;

    public SubscriptionPipeline(
        ContactProcessingStep contactProcessingStep,
        MarketingCampaignProcessingStep marketingCampaignProcessingStep,
        SpecialFinancialInformationProcessingStep specialFinancialInformationProcessingStep,
        SubscriptionProcessingStep subscriptionProcessingStep)
    {
        _contactProcessingStep = contactProcessingStep;
        _marketingCampaignProcessingStep = marketingCampaignProcessingStep;
        _specialFinancialInformationProcessingStep = specialFinancialInformationProcessingStep;
        _subscriptionProcessingStep = subscriptionProcessingStep;
    }

    public async Task<PaymentContext> Run(PaymentContext context, CancellationToken cancellationToken)
    {
        context = await _contactProcessingStep.Process(context, cancellationToken);
        context = await _marketingCampaignProcessingStep.Process(context, cancellationToken);
        context = await _specialFinancialInformationProcessingStep.Process(context, cancellationToken);
        context = await _subscriptionProcessingStep.Process(context, cancellationToken);

        context.Success = true;
        return context;
    }
}
