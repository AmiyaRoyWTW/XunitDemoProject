using CalculatorUnitTests.ReportUtils;

namespace CalculatorUnitTests.TestsUtils
{
    public class TestHooks : IAsyncLifetime
    {
        public Task DisposeAsync()
        {                       
            HtmlReporter.FlushReport();
            JsonReporter.GenerateJsonReport();
            return Task.CompletedTask;
        }

        public Task InitializeAsync()
        {
            HtmlReporter.Initilize();
            return Task.CompletedTask;
        }
    }
}
