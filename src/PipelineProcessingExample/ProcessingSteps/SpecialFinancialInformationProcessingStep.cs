using Microsoft.Extensions.Options;
using PipelineProcessingExample.Config;
using PipelineProcessingExample.Interfaces.ProcessingSteps;
using PipelineProcessingExample.Interfaces.Services;
using PipelineProcessingExample.Models;

namespace PipelineProcessingExample.ProcessingSteps;

public class SpecialFinancialInformationProcessingStep : IProcessingStep
{
    private readonly AppConfig _appConfig;
    private readonly ICrmService _crmService;

    public SpecialFinancialInformationProcessingStep(ICrmService crmService, IOptionsMonitor<AppConfig> options)
    {
        _appConfig = options.CurrentValue;
        _crmService = crmService;
    }

    public async Task<PaymentContext> Process(PaymentContext context, CancellationToken cancellationToken)
    {
        // Determine other information about the financial transaction
        if (context.PaymentRequest.Amount >= _appConfig.SpecialCampaignThreshold)
        {
            var specialFinancialInformation = await _crmService.GetSpecialFinancialInformation(cancellationToken);

            if (specialFinancialInformation != null)
            {
                if (context.IsNewContact)
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

            context.SpecialFinancialInformation = specialFinancialInformation;
        }

        return context;
    }
}
