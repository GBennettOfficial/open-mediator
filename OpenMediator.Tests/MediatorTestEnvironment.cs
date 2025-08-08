using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using OpenToolkit.Abstractions;
using OpenToolkit.Services;

namespace OpenToolkit.Tests
{
    public class OpenMediatorTestEnvironment : IDisposable
    {
        private readonly IHost _host;
        public OpenMediatorTestEnvironment()
        {
            _host = Host.CreateDefaultBuilder()
                .ConfigureServices((context, services) =>
                {
                    services.AddScoped<ISendRequestAsync, RequestSenderAsync>();
                    services.AddScoped<IProcessRequestAsync<MockRequest, MockResponse>, MockService>();
                })
                .Build();
            _host.Start();
        }
        public IServiceProvider GetScopedServiceProvider() =>
            _host.Services.CreateScope().ServiceProvider;
        public void Dispose() => _host.Dispose();
    }
}
