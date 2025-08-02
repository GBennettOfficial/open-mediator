using Microsoft.Extensions.DependencyInjection;

namespace OpenMediator
{
    public static class Extensions
    {
        public static void UseOpenMediator(this IServiceCollection services)
        {
            services.AddScoped<OpenMediatorService>();
            services.AddScoped<IOpenMediator, OpenMediatorService>();
        }
    }
}
