using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;

namespace OpenMediator.Tests
{
    public class OpenMediatorTestEnvironment : IDisposable
    {
        private readonly IHost _host;
        public OpenMediatorTestEnvironment()
        {
            _host = Host.CreateDefaultBuilder()
                .ConfigureServices((context, services) =>
                {
                    services.UseOpenMediator();
                    services.AddScoped<IRequestHandler<MockRequest, MockResponse>, MockService>();
                })
                .Build();
            _host.Start();
        }
        public IServiceProvider GetScopedServiceProvider() =>
            _host.Services.CreateScope().ServiceProvider;
        public void Dispose() => _host.Dispose();
    }
}
