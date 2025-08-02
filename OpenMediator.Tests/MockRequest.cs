namespace OpenMediator.Tests;

public class MockRequest : IRequest<MockResponse>
{
    public MockRequest(IEnumerable<int> nums)
    {
        Numbers = nums;
    }
    public IEnumerable<int> Numbers { get; }
}


