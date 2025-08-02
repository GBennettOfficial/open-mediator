using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OpenMediator.Tests
{
    public class OpenMediatorServiceTests : IClassFixture<OpenMediatorTestEnvironment>
    {
        private readonly OpenMediatorTestEnvironment _env;

        public OpenMediatorServiceTests(OpenMediatorTestEnvironment env)
        {
            _env = env;
        }

        [Theory]
        [InlineData(2, 2, 4)]
        [InlineData(100, 150, 250)]
        public async Task DepInject_MockService_GetsSum(int num1, int num2, int expected)
        { 
            // Arrange
            IOpenMediator mediator = (IOpenMediator)_env
                .GetScopedServiceProvider()
                .GetService(typeof(IOpenMediator))!;
            int[] nums = new int[] { num1, num2 };

            // Act
            MockRequest req = new(nums);
            MockResponse resp = await mediator.Send(req);
            int result = resp.Sum;

            // Assert
            Assert.Equal(expected, result);
        }
    }
}
