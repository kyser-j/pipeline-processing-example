using PipelineProcessingExample.Interfaces.Pipelines;
using PipelineProcessingExample.Models;
using PipelineProcessingExample.ProcessingSteps;

namespace PipelineProcessingExample.Pipelines;

public class OneTimePipeline : IPipeline
{
    private readonly ContactProcessingStep _contactProcessingStep;
    private readonly MarketingCampaignProcessingStep _marketingCampaignProcessingStep;
    private readonly SpecialFinancialInformationProcessingStep _specialFinancialInformationProcessingStep;
    private readonly OneTimeProcessingStep _oneTimeProcessingStep;

    public OneTimePipeline(
        ContactProcessingStep contactProcessingStep,
        MarketingCampaignProcessingStep marketingCampaignProcessingStep,
        SpecialFinancialInformationProcessingStep specialFinancialInformationProcessingStep,
        OneTimeProcessingStep oneTimeProcessingStep)
    {
        _contactProcessingStep = contactProcessingStep;
        _marketingCampaignProcessingStep = marketingCampaignProcessingStep;
        _specialFinancialInformationProcessingStep = specialFinancialInformationProcessingStep;
        _oneTimeProcessingStep = oneTimeProcessingStep;
    }

    public async Task<PaymentContext> Run(PaymentContext context, CancellationToken cancellationToken)
    {
        context = await _contactProcessingStep.Process(context, cancellationToken);
        context = await _marketingCampaignProcessingStep.Process(context, cancellationToken);
        context = await _specialFinancialInformationProcessingStep.Process(context, cancellationToken);
        context = await _oneTimeProcessingStep.Process(context, cancellationToken);

        context.Success = true;
        return context;
    }
}
