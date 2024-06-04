using AventStack.ExtentReports;
using AventStack.ExtentReports.Reporter;
using AventStack.ExtentReports.Reporter.Config;
using System.Reflection;


namespace CalculatorUnitTests.ReportUtils
{
    
    public class ReportUtil
    {
        public static ExtentReports extentReports;
        public static string reportPath;
        public static string testRunId;

        public static void Initilize()
        {
            string? executionAssemblyPath = Path.GetDirectoryName(Assembly.GetExecutingAssembly().Location);
            string? companyLogo = $"{executionAssemblyPath}\\ReportUtils\\logo1.png";            
            testRunId = Guid.NewGuid().ToString();
            string baseDirectory = Path.Combine(executionAssemblyPath, @"..\..\..\");
            if (Environment.GetEnvironmentVariable("ExtentReportPath")==null)
            {
                reportPath = Path.Combine(baseDirectory, @$"Reports\{testRunId}");
            }
            else reportPath = $"{Environment.GetEnvironmentVariable("ExtentReportPath")}\\{testRunId}";
            var spark = new ExtentSparkReporter($"{reportPath}\\RunReport.html");
            spark.Config.DocumentTitle = "Process Orchestration";
            spark.Config.Theme = Theme.Standard;
            spark.Config.ReportName = "Execution Report";
            spark.Config.TimelineEnabled = true;
            spark.Config.OfflineMode = false;
            spark.Config.JS = $"document.querySelector('.logo').style.background=\"url('{companyLogo.Replace("\\", "/")}')\"";
            extentReports = new ExtentReports();
            extentReports.AttachReporter(spark);
        }

        public static void FlushReport()
        {
            extentReports.Flush();
        }

    }
}
