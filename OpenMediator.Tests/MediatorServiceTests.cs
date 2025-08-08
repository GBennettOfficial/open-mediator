using OpenToolkit.Abstractions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OpenToolkit.Tests
{
    public class RequestSenderAsyncTests : IClassFixture<OpenMediatorTestEnvironment>
    {
        private readonly OpenMediatorTestEnvironment _env;

        public RequestSenderAsyncTests(OpenMediatorTestEnvironment env)
        {
            _env = env;
        }

        [Theory]
        [InlineData(2, 2, 4)]
        [InlineData(100, 150, 250)]
        public async Task DepInject_MockService_GetsSum(int num1, int num2, int expected)
        { 
            // Arrange
            ISendRequestAsync mediator = (ISendRequestAsync)_env
                .GetScopedServiceProvider()
                .GetService(typeof(ISendRequestAsync))!;
            int[] nums = new int[] { num1, num2 };

            // Act
            MockRequest req = new(nums);
            MockResponse resp = await mediator.SendRequestAsync(req);
            int result = resp.Sum;

            // Assert
            Assert.Equal(expected, result);
        }
    }
}
