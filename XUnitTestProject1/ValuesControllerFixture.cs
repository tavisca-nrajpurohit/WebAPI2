using System;
using Xunit;
using WebApi.Controllers;

namespace XUnitTestProject1
{
    public class ValuesControllerFixture
    {
        ValuesController controller = new ValuesController();

        [Fact]
        public void ParametrizedGetTestHi()
        {
            var getResult = controller.Get("hi");
            Assert.Equal("hello user",getResult);
        }

        [Fact]
        public void ParametrizedGetTestHello()
        {
            var getResult = controller.Get("hello");
            Assert.Equal("hi user", getResult);
        }

        [Fact]
        public void ParametrizedGetTestInvalidInput()
        {
            var getResult = controller.Get("invalid_input");
            Assert.Equal("invalid input", getResult);
        }

    }
}
