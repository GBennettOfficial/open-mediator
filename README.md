# OpenMediator

A simple implementation of the mediator pattern. I learned about this from <a href="https://www.dotnetwebacademy.com/">Patrick God</a>'s <a href="https://youtu.be/k62-sq35no8?si=VugAJTnClR2YHdsQ">Youtube video</a>.

## Usage

The mediator pattern works in terms of responses and requests. Both are models implementing the ```IResponse``` and ```IRequest<TResponse>``` interfaces respectively. Services are set up to take in a request and output a response asynchronously. These services implement the generic interface ```IRequestHandler<TRequest, TResponse>```. It is critcal that these services are registered into dependency injection with this interface and with a scoped lifetime. Now you can inject an ```IOpenMediator``` anywhere in your program, create a new request, send that request, and recieve a response.

```
    public class MockClass
    {
        private readonly IOpenMediator _mediator;

        public MockClass(IOpenMediator mediator)
        {
            _mediator = mediator;
        }

        public async Task DoWork()
        {
            int[] data = new int[] { 1, 2, 3 };
            MockRequest req = new(data);
            MockResponse res = await _mediator.Send(req);
            Console.WriteLine(res.ToString());
        }
    }
```

## Setup

First, when registering services for dependency injection, call ```.UseMediator()``` on your ```IServiceCollection```. 
Secondly, register your ```IRequestHandler```s.

```
    public class ExampleEnvironment : IDisposable
    {
        private readonly IHost _host;
        public ExampleEnvironment()
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

        public void Dispose() => _host.Dispose();
    }
```