
namespace OpenMediator
{
    public class OpenMediatorService : IOpenMediator
    {
        private readonly IServiceProvider _serviceProvider;        
        public OpenMediatorService(IServiceProvider serviceProvider)
        {
            _serviceProvider = serviceProvider;
        }

        public Task<TResponse> Send<TResponse>(IRequest<TResponse> request, CancellationToken ct = default) where TResponse : IResponse
        {
            Type t = typeof(IRequestHandler<,>).MakeGenericType(request.GetType(), typeof(TResponse));
            object? obj = _serviceProvider.GetService(t);
            if (obj is null)
                throw new OpenMediatorException($"IRequestHandler for request of type {request.GetType().Name} has not been registered");
            var requestHandler = (dynamic)obj;
            Task<TResponse> response = requestHandler.Handle((dynamic)request, ct);
            return response;
        }
    }
}
