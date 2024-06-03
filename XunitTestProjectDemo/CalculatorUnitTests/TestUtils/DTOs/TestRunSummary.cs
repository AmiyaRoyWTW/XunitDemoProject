
namespace CalculatorUnitTests.TestUtils.DTOs
{
    public class TestRunSummary
    {
        public string TestRunId { get; set; }
        public List<TestCase>? TestCases { get; set; }
        public int TestCasesCount { get; set; }
        public int PassedCount { get; set; }
        public int FailedCount { get; set; }
        public DateTime StartTime { get; set; }
        public DateTime EndTime { get; set; }
        public List<TestCase>? FailedTestCases { get; set; }
    }
}
