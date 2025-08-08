namespace OpenToolkit.Abstractions
{
    public interface ISendRequest
    {
        public TResponse SendRequest<TResponse>(IRequest<TResponse> request) where TResponse : IResponse;
    }
}
