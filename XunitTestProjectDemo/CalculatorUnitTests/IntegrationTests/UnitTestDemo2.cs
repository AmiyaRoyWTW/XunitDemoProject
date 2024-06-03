using CalculatorUnitTests.Xunit.TestsUtil;
using Microsoft.VisualStudio.TestPlatform.Utilities;
using NSubstitute;
using Xunit.Abstractions;
using XunitTestProjectDemo;
using Custom = CalculatorUnitTests.AssertUtil;

namespace CalculatorUnitTests.IntegrationTests
{
    [Collection("Test Collection")]
    public class UnitTestDemo2 : BaseTest
    {
        Operations operations;
        Calculator calculator;
        public UnitTestDemo2(ITestOutputHelper output) : base(output)
        {
            operations = new Operations();
            calculator = new Calculator(operations);
        }

        [Theory, Trait("Category", "Integration")]
        [Trait("Category", "E2E")]
        [InlineData(5, 10, 14)]
        public void DoCalculations_ShouldReturnTrueOnSuccess_Dup(int a, int b, int expected)
        {
            var actual = calculator.DoCalculations(a, b);
            Custom.Assert.AreEqual(expected, actual);
            Custom.Assert.IsTrue(calculator.outcome, "Value is not true");
        }
        
        [Theory]
        [Trait("Category", "E2E")]
        [InlineData(4, 10, 14)]
        public void DoCalculations_IMock_ShouldReturnTrueOnSuccess_Dup(int a, int b, int expected)
        {
            var _operations = Substitute.For<IOperations>();
            _operations.Add(Arg.Any<int>(), Arg.Any<int>()).Returns(15);
            Custom.Assert.AreEqual(15, _operations.Add(a, b));
            var _calculator = Substitute.For<Calculator>(_operations);
            var actual = _calculator.DoCalculations(a, b);
            _operations.Received().Add(Arg.Any<int>(), Arg.Any<int>());
            Custom.Assert.AreEqual(expected, actual);
        }
    }
}