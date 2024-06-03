using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using Xunit.Abstractions;
using Xunit.Runners;
using Xunit.Sdk;

namespace CalculatorUnitTests.TestUtils
{
    public static class TestOutputHelperExtension
    {
        public static Dictionary<string, string> GetTestCaseDetails(this ITestOutputHelper helper)
        {
            Dictionary<string, string> testCaseDetail = new Dictionary<string, string>();
            var type = helper.GetType();
            var testMember = type.GetField("test", BindingFlags.Instance | BindingFlags.NonPublic);
            var testAssem = (ITest)testMember.GetValue(helper);           
            var testMethodName = testAssem.TestCase.TestMethod.Method.Name;
            var testClassName = testAssem.TestCase.TestMethod.TestClass.Class.Name.Split(".").Last();
            testCaseDetail["TestMethodName"] = testMethodName;
            testCaseDetail["TestClassName"] = testClassName;           
            return testCaseDetail;
        }

        public static List<string> GetTestCaseAttributes(this ITestOutputHelper helper)
        {
            List<string> categories = new List<string>();
            var type = helper.GetType();
            var testMember = type.GetField("test", BindingFlags.Instance | BindingFlags.NonPublic);
            var testAssem = (ITest)testMember.GetValue(helper);
            if (testAssem.TestCase.Traits.ContainsKey("Category"))
            {
                categories = testAssem.TestCase.Traits["Category"];
            }
            return categories;
        }

        public static void GetTestExecutionDetails(this ITestOutputHelper helper)
        {
            List<string> categories = new List<string>();
            var type = helper.GetType();
            var testMember = type.GetField("test", BindingFlags.Instance | BindingFlags.NonPublic);
            var testAssem = (ITestExecutionSummary)testMember.GetValue(helper);
        }
    }
}
