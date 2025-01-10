using PipelineProcessingExample.Interfaces.ProcessingSteps;
using PipelineProcessingExample.Interfaces.Services;
using PipelineProcessingExample.Models;

namespace PipelineProcessingExample.ProcessingSteps;

public class ContactProcessingStep : IProcessingStep
{
    private readonly ICrmService _crmService;

    public ContactProcessingStep(ICrmService crmService)
    {
        _crmService = crmService;
    }

    public async Task<PaymentContext> Process(PaymentContext context, CancellationToken cancellationToken)
    {
        // Process the payers contact information
        var contact = await _crmService.GetContact(context.PaymentRequest.FirstName, context.PaymentRequest.LastName, context.PaymentRequest.Email, context.PaymentRequest.PostalCode, cancellationToken);

        if (contact == null)
        {
            contact = await _crmService.CreateContact(context.PaymentRequest.FirstName, context.PaymentRequest.LastName, context.PaymentRequest.Email, context.PaymentRequest.PostalCode, cancellationToken);
            context.IsNewContact = true;
        }

        context.Contact = contact;
        return context;
    }
}
