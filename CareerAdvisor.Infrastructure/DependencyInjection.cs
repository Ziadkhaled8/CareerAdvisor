using CareerAdvisor.Application.Abstractions;
using CareerAdvisor.Application.Abstractions.Repositories;
using CareerAdvisor.Application.Abstractions.Services;
using CareerAdvisor.Infrastructure.Repositories;
using CareerAdvisor.Infrastructure.Services;
using Microsoft.Extensions.DependencyInjection;


namespace CareerAdvisor.Infrastructure
{
    public static class DependencyInjection
    {
        public static IServiceCollection AddInfrastructure(this IServiceCollection services)
        {
            services.AddScoped<IUserProfileRepository, UserProfileRepository>();
            services.AddScoped<IAuthService, AuthService>();
            services.AddHttpClient<IAIClient, AIClient>(client =>
            {
                client.BaseAddress = new Uri("http://localhost:8001");
            });

            return services;
        }
    }
}
