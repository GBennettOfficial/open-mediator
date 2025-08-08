using OpenToolkit.Abstractions;

namespace OpenToolkit.Services
{
    public class RequestSenderAsync : ISendRequestAsync
    {
        private readonly IServiceProvider _serviceProvider;        
        public RequestSenderAsync(IServiceProvider serviceProvider)
        {
            _serviceProvider = serviceProvider;
        }

        public Task<TResponse> SendRequestAsync<TResponse>(IRequest<TResponse> request, CancellationToken ct = default) where TResponse : IResponse
        {
            Type t = typeof(IProcessRequestAsync<,>).MakeGenericType(request.GetType(), typeof(TResponse));
            object? obj = _serviceProvider.GetService(t);
            if (obj is null)
                ThrowAsyncProcessorNotRegistered(request.GetType());
            var requestHandler = (dynamic)obj!;
            Task<TResponse> response = requestHandler.ProcessRequestAsync((dynamic)request, ct);
            return response;
        }

        protected void ThrowAsyncProcessorNotRegistered(Type requestType)
        {
            string message = $"There is no IProcessRequestAsync service actively registered for request type {requestType.Name}.";
            ArgumentException innerException = new ArgumentException();
            OpenToolkitException exception = new OpenToolkitException(message, innerException);
            throw exception;
        }
    }
}
