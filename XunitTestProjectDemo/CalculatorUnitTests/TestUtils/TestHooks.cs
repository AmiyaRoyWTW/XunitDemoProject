using CalculatorUnitTests.ReportUtils;
using System.Reflection;
using Xunit.Runners;
using Xunit.Sdk;

namespace CalculatorUnitTests.TestsUtils
{
    public class TestHooks : IAsyncLifetime
    {
        public Task DisposeAsync()
        {                       
            ReportUtil.FlushReport();
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
