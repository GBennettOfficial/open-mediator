
namespace OpenToolkit.Abstractions
{
    public interface IProcessRequestAsync<in TRequest, TResponse> where TRequest : IRequest<TResponse> where TResponse : IResponse
    {
        public Task<TResponse> ProcessRequestAsync(TRequest request, CancellationToken ct);
    }
}
