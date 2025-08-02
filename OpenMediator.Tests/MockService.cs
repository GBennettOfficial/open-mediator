namespace OpenMediator.Tests;

public class MockService : IRequestHandler<MockRequest, MockResponse>
{
    public Task<MockResponse> Handle(MockRequest request, CancellationToken ct)
    {
        return Task.Run(() =>
        {
            int sum = request.Numbers.Sum();
            return new MockResponse(sum);
        });
    }
}


