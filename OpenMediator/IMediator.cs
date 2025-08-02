
namespace OpenMediator
{
    public interface IOpenMediator
    {
        public Task<TResponse> Send<TResponse>(IRequest<TResponse> request, CancellationToken ct = default) where TResponse : IResponse;
    }
}
