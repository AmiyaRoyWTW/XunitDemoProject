using AventStack.ExtentReports;
using CalculatorUnitTests.TestUtils.DTOs;
using Newtonsoft.Json;

namespace CalculatorUnitTests.ReportUtils
{
    public class JsonReporter
    {
        private ExtentReports _reports;

        public static void GenerateJsonReport()
        {
            var _reports = ReportUtil.extentReports;
            TestRunSummary testRunSummary = new TestRunSummary();
            testRunSummary.TestCases = new List<TestCase>();
            testRunSummary.FailedTestCases = new List<TestCase>();            
            testRunSummary.TestRunId = ReportUtil.testRunId;
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
                    TestCaseError = executedTest.Status.ToString().Equals("Fail") 
                                        ? executedTest.Logs.Where(x => x.Status.ToString().Equals("Fail")).First()
                                            .Details.ToString() : ""
                };
                testRunSummary.TestCases.Add(testCase);
                if (testCase.TestCaseError != "")
                {
                    testRunSummary.FailedTestCases.Add(testCase);
                }
            }
            File.WriteAllText($"{ReportUtil.reportPath}\\RunReport.json", JsonConvert.SerializeObject(testRunSummary));
        }
    }
}
