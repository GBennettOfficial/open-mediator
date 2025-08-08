using OpenToolkit.Abstractions;

namespace OpenToolkit.Services
{
    public class RequestSender : ISendRequest
    {
        private readonly IServiceProvider _serviceProvider;
        public RequestSender(IServiceProvider serviceProvider)
        {
            _serviceProvider = serviceProvider;
        }

        public TResponse SendRequest<TResponse>(IRequest<TResponse> request) where TResponse : IResponse
        {
            Type t = typeof(IProcessRequest<,>).MakeGenericType(request.GetType(), typeof(TResponse));
            object? obj = _serviceProvider.GetService(t);
            if (obj is null)
                ThrowProcessorNotRegistered(request.GetType());
            var requestHandler = (dynamic)obj!;
            TResponse response = requestHandler.HandleRequest((dynamic)request);
            return response;
        }

        protected void ThrowProcessorNotRegistered(Type requestType)
        {
            string message = $"There is no IProcessRequest service actively registered for request type {requestType.Name}.";
            ArgumentException innerException = new ArgumentException();
            OpenToolkitException exception = new OpenToolkitException(message, innerException);
            throw exception;
        }
    }
}
