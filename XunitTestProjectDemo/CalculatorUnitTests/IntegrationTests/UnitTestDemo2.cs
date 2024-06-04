using CalculatorUnitTests.Xunit.TestsUtil;
using NSubstitute;
using System.ComponentModel;
using Xunit.Abstractions;
using XunitTestProjectDemo;
using CalculatorUnitTests.AssertUtil;

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

        [Theory]
        [Trait("Category", "Integration")]
        [Trait("Category", "E2E")]
        [InlineData(5, 10, 14)]
        public void DoCalculations_ShouldReturnTrueOnSuccess_Dup(int a, int b, int expected)
        {
            var actual = calculator.DoCalculations(a, b);
            Assertion.AreEqual(expected, actual);
            Assertion.IsTrue(calculator.outcome, "Value is not true");
        }
        
        [Theory]
        [Description("This is my descriptive test")]
        [Trait("Category", "E2E")]
        [InlineData(4, 10, 14)]
        public void DoCalculations_IMock_ShouldReturnTrueOnSuccess_Dup(int a, int b, int expected)
        {
            var _operations = Substitute.For<IOperations>();
            _operations.Add(Arg.Any<int>(), Arg.Any<int>()).Returns(15);
            Assertion.AreEqual(15, _operations.Add(a, b));
            var _calculator = Substitute.For<Calculator>(_operations);
            var actual = _calculator.DoCalculations(a, b);
            _operations.Received().Add(Arg.Any<int>(), Arg.Any<int>());
            Assertion.AreEqual(expected, actual);
        }
    }
}