using AventStack.ExtentReports;
using CalculatorUnitTests.ReportUtils;
using CalculatorUnitTests.TestUtils;
using Xunit.Abstractions;

namespace CalculatorUnitTests.Xunit.TestsUtil
{
    public class BaseTest : IDisposable
    {
        private readonly ITestOutputHelper _output;
        public static ExtentTest CurrentTest { get; set; }
        public Dictionary<string, string> currentTestCaseDetails;
        public List<string> currentTestAttributes;

        public BaseTest(ITestOutputHelper output)
        {
            _output = output;
            currentTestCaseDetails = _output.GetTestCaseDetails();
            currentTestAttributes = _output.GetTestCaseAttributes();            
            CurrentTest = ReportUtil.extentReports.CreateTest($"{currentTestCaseDetails["TestClassName"]}.{currentTestCaseDetails["TestMethodName"]}", currentTestCaseDetails["TestCaseDesc"]);
            foreach (var attribute in currentTestAttributes)
            {
                CurrentTest.AssignCategory(attribute);
            }            
            CurrentTest.Log(Status.Info, $"Start of text case execution - {currentTestCaseDetails["TestMethodName"]}");
        }
        public void Dispose()
        {
            CurrentTest.Log(Status.Info, $"End of text execution - {currentTestCaseDetails["TestMethodName"]}");
        }
    }
}
