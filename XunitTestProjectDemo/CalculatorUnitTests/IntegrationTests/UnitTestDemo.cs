using CalculatorUnitTests.Xunit.TestsUtil;
using NSubstitute;
using Xunit.Abstractions;
using XunitTestProjectDemo;
using CalculatorUnitTests.AssertUtil;

namespace CalculatorUnitTests.IntegrationTests
{
    [Collection("Test Collection")]
    public class UnitTestDemo : BaseTest
    {
        Operations operations;
        Calculator calculator;
        public UnitTestDemo(ITestOutputHelper output) : base(output)
        {
            operations = new Operations();
            calculator = new Calculator(operations);
        }

        [Fact]
        [Trait("Category", "E2E")]
        public async Task DoCalculations_ShouldReturnTrueOnSuccess()
        {
            var actual = calculator.DoCalculations(5, 10);
            Assertion.AreEqual(14, actual);
            Assertion.IsTrue(calculator.outcome, "Value is not true");
            await Assertion.ThrowsAsync<NullReferenceException>(MethodThatThrows);
        }

        [Theory]
        [Trait("Category", "Integration")]
        [Trait("Category", "E2E")]
        [InlineData(4, 10, 14)]
        public void DoCalculations_IMock_ShouldReturnTrueOnSuccess(int a, int b, int expected)
        {
            var _operations = Substitute.For<IOperations>();
            _operations.Add(Arg.Any<int>(), Arg.Any<int>()).Returns(15);
            Assertion.AreEqual(15, _operations.Add(a, b));
            var _calculator = Substitute.For<Calculator>(_operations);
            var actual = _calculator.DoCalculations(a, b);
            _operations.Received().Add(Arg.Any<int>(), Arg.Any<int>());
            Assertion.AreEqual(expected, actual);
        }

        private async Task MethodThatThrows()
        {
            await Task.Delay(100);
            throw new ArgumentException();
        }
    }
}