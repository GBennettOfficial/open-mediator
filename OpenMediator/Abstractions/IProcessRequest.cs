
namespace OpenToolkit.Abstractions
{
    public interface IProcessRequest<in TRequest, TResponse> where TRequest : IRequest<IResponse> where TResponse : IResponse
    {
        public TResponse ProcessRequest(TRequest request);
    }
}
