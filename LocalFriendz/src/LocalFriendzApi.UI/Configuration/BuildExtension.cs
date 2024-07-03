using FluentValidation;
using LocalFriendzApi.Application.IServices;
using LocalFriendzApi.Application.Services;
using LocalFriendzApi.Application.Validations;
using LocalFriendzApi.Domain.IRepositories;
using LocalFriendzApi.Infrastructure.Data.Context;
using LocalFriendzApi.Infrastructure.ExternalServices.Interfaces;
using LocalFriendzApi.Infrastructure.Logging;
using LocalFriendzApi.Infrastructure.Repositories;
using Microsoft.EntityFrameworkCore;
using Refit;


namespace LocalFriendzApi.UI.Configuration
{
    public static class BuildExtension
    {
        public static void AddConfiguration(this WebApplicationBuilder builder)
        {
            ApiConfiguration.ConnectionString = builder.Configuration.GetConnectionString("DefaultConnection") ?? string.Empty;
        }

        public static void AddDataContexts(this WebApplicationBuilder builder)
        {
            builder
                .Services
                .AddDbContext<AppDbContext>(
                    x =>
                    {
                        x.UseSqlServer(ApiConfiguration.ConnectionString);
                    });

        }

        public static void AddServices(this WebApplicationBuilder builder)
        {
            builder
                .Services
                .AddTransient<IContactServices, ContactServices>();

            builder
                .Services
                .AddTransient<IContactRepository, ContactRepository>();
        }

        public static void AddDocumentation(this WebApplicationBuilder builder)
        {
            builder.Services.AddEndpointsApiExplorer();
            builder.Services.AddSwaggerGen(x =>
            {
                x.CustomSchemaIds(n => n.FullName);
            });
        }

        public static void AddCrossOrigin(this WebApplicationBuilder builder)
        {
            // inserir implementação do cross
        }

        public static void AddLogging(this WebApplicationBuilder builder)
        {
            builder.Logging.ClearProviders();
            builder.Logging.AddProvider(new CustomLoggerProvider(new CustomLoggerProviderConfiguration
            {
                LogLevel = LogLevel.Information
            }));
        }

        public static void ExternalServices(this WebApplicationBuilder builder)
        {
            builder
            .Services
            .AddRefitClient<IAreaCodeExternalService>()
            .ConfigureHttpClient(c => c.BaseAddress = new Uri("https://brasilapi.com.br/api"));
        }

        public static void AddFluentValidation(this WebApplicationBuilder builder)
        {
            builder.Services.AddValidatorsFromAssemblyContaining<CreateContactRequestValidator>();
            builder.Services.AddValidatorsFromAssemblyContaining<UpdateContactRequestValidator>();
        }
    }
}


