using OpenToolkit.Abstractions;

namespace OpenToolkit.Tests;

public class MockResponse : IResponse
{
    public MockResponse(int sum)
    {
        Sum = sum;
    }
    public int Sum { get; }
}


