﻿
namespace OpenMediator
{
    public interface IRequestHandler<TRequest, TResponse> where TRequest : IRequest<TResponse> where TResponse : IResponse
    {
        public Task<TResponse> Handle(TRequest request, CancellationToken ct);
    }
}
