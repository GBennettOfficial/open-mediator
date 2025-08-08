using OpenToolkit.Abstractions;

namespace OpenToolkit.Tests;

public class MockService : IProcessRequestAsync<MockRequest, MockResponse>
{
    public Task<MockResponse> ProcessRequestAsync(MockRequest request, CancellationToken ct)
    {
        return Task.Run(() =>
        {
            int sum = request.Numbers.Sum();
            return new MockResponse(sum);
        });
    }
}


