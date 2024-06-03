using AventStack.ExtentReports;
using AventStack.ExtentReports.Reporter;
using AventStack.ExtentReports.Reporter.Config;
using System.Reflection;


namespace CalculatorUnitTests.ReportUtils
{
    
    public class ReportUtil
    {
        public static ExtentReports extentReports;
        private static string reportPath;

        public static void Initilize()
        {
            string? executionAssemblyPath = Path.GetDirectoryName(Assembly.GetExecutingAssembly().Location);
            string? companyLogo = $"{executionAssemblyPath}\\ReportUtils\\logo1.png";            
            string testRunId = Guid.NewGuid().ToString();
            string baseDirectory = Path.Combine(executionAssemblyPath, @"..\..\..\");
            if (Environment.GetEnvironmentVariable("ExtenReportPath")==null)
            {
                reportPath = Path.Combine(baseDirectory, @"Reports");
            }
            else reportPath = $"{Environment.GetEnvironmentVariable("ExtenReportPath")}";
            var spark = new ExtentSparkReporter($"{reportPath}\\{testRunId}\\RunReport.html");
            spark.Config.DocumentTitle = "Process Orchestration";
            spark.Config.Theme = Theme.Dark;
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
