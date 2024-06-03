using CalculatorUnitTests.TestsUtils;

namespace CalculatorUnitTests.Xunit.TestsUtil
{
    [CollectionDefinition("Test Collection", DisableParallelization = true)]
    public class TestCollection : ICollectionFixture<TestHooks>
    {
    }
}
