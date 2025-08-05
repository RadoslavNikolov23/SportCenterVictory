namespace SCV.Web.Infrastructure
{
    using Microsoft.Extensions.Configuration;
    using Microsoft.Extensions.DependencyInjection;
    using Microsoft.Extensions.Options;

    using SCV.Services.Common.EmailSettings;
    using SCV.Services.Core.EmailServices;
    using SCV.Services.Core.EmailServices.Contracts;

    public static class EmailServiceCollectionExtensions
    {
        public static IServiceCollection AddEmailServices(this IServiceCollection services, IConfiguration configuration)
        {
            services.Configure<EmailSettings>(configuration.GetSection("EmailSettings"));

            services.AddScoped<IEmailService, EmailService>();

            services.AddScoped<Func<ISmtpClient>>(sp =>
            {
                EmailSettings settings = sp.GetRequiredService<IOptions<EmailSettings>>().Value;

                return () => new SmtpClientWrapper(
                    settings.Host,
                    settings.Port,
                    settings.Username,
                    settings.Password
                );
            });

            return services;
        }
    }
}
