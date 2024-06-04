using CalculatorUnitTests.ReportUtils;

namespace CalculatorUnitTests.TestsUtils
{
    public class TestHooks : IAsyncLifetime
    {
        public Task DisposeAsync()
        {                       
            ReportUtil.FlushReport();
            JsonReporter.GenerateJsonReport();
            return Task.CompletedTask;
        }

        public Task InitializeAsync()
        {
            //var runner = AssemblyRunner.WithoutAppDomain(Assembly.GetExecutingAssembly().Location);
            //runner.Start();
            ReportUtil.Initilize();
            return Task.CompletedTask;
        }
    }
}
