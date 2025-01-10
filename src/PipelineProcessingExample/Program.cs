using PipelineProcessingExample.Config;
using PipelineProcessingExample.Interfaces.Pipelines;
using PipelineProcessingExample.Interfaces.Services;
using PipelineProcessingExample.Pipelines;
using PipelineProcessingExample.ProcessingSteps;
using PipelineProcessingExample.Services;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();

// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

builder.Services
    .Configure<AppConfig>(builder.Configuration.GetSection("AppConfig"));

builder.Services
    .AddScoped<ICrmService, CrmService>()
    .AddKeyedScoped<IPaymentService, ApplePayService>("ApplePayService")
    .AddKeyedScoped<IPaymentService, BankService>("BankService")
    .AddKeyedScoped<IPaymentService, CreditCardService>("CreditCardService")
    .AddKeyedScoped<IPaymentService, GooglePayService>("GooglePayService")
    .AddKeyedScoped<IPaymentService, PayPalService>("PayPalService")

    .AddScoped<ContactProcessingStep>()
    .AddScoped<MarketingCampaignProcessingStep>()
    .AddScoped<OneTimeProcessingStep>()
    .AddScoped<SpecialFinancialInformationProcessingStep>()
    .AddScoped<SubscriptionProcessingStep>()
    .AddKeyedScoped<IPipeline, OneTimePipeline>("OneTimePipeline")
    .AddKeyedScoped<IPipeline, SubscriptionPipeline>("SubscriptionPipeline")
    .AddScoped<IPipelineFactory, PipelineFactory>();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
