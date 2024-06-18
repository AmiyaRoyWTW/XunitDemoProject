using AventStack.ExtentReports;
using CalculatorUnitTests.TestUtils.DTOs;
using Newtonsoft.Json;

namespace CalculatorUnitTests.ReportUtils
{
    public class JsonReporter
    {
        private static ExtentReports? _reports;

        public static void GenerateJsonReport()
        {
            _reports = HtmlReporter.extentReports;
            TestRunSummary testRunSummary = new TestRunSummary();
            testRunSummary.TestCases = new List<TestCase>();
            testRunSummary.FailedTestCases = new List<TestCase>();            
            testRunSummary.TestRunId = (HtmlReporter.testRunId != null) ? HtmlReporter.testRunId : "";
            testRunSummary.StartTime = _reports.Report.StartTime;
            testRunSummary.EndTime = _reports.Report.EndTime;
            var executedTests = _reports.Report.Tests.ToList();
            testRunSummary.TestCasesCount = executedTests.Count;
            testRunSummary.PassedCount = executedTests.Where(x => x.Status.ToString().Equals("Pass")).ToList().Count;
            testRunSummary.FailedCount = executedTests.Where(x => x.Status.ToString().Equals("Fail")).ToList().Count;
            foreach (var executedTest in executedTests)
            {
                var testCase = new TestCase()
                {
                    Id = executedTest.Id,
                    TestRunId = testRunSummary.TestRunId,
                    Name = executedTest.Name,
                    Attributes = executedTest.Category.ToList().Count>0 ? executedTest.Category.Select(x => x.Name.ToString()).ToList() : null,
                    Description = executedTest.Description,
                    Status = executedTest.Status.ToString(),
                    StartTime = executedTest.StartTime,
                    EndTime = executedTest.EndTime,
                    ErrorMsg = (executedTest.ExceptionInfo.Count>0) ? executedTest.ExceptionInfo.FirstOrDefault().Exception.Message : null,
                    StackTrace = (executedTest.ExceptionInfo.Count > 0) ? executedTest.ExceptionInfo.FirstOrDefault().Exception.StackTrace.ToString().Trim() : null
                };
                testRunSummary.TestCases.Add(testCase);
                if (testCase.ErrorMsg != null)
                {
                    testRunSummary.FailedTestCases.Add(testCase);
                }
            }
            File.WriteAllText($"{HtmlReporter.reportPath}\\RunReport.json", JsonConvert.SerializeObject(testRunSummary));
        }
    }
}
