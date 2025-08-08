namespace OpenToolkit.Abstractions
{
    public interface ISendRequestAsync
    {
        public Task<TResponse> SendRequestAsync<TResponse>(IRequest<TResponse> request, CancellationToken ct = default) where TResponse : IResponse;
    }
}
