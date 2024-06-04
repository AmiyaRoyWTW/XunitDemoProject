using System.ComponentModel;
using System.Reflection;
using Xunit.Abstractions;

namespace CalculatorUnitTests.TestUtils
{
    public static class TestOutputHelperExtension
    {
        #pragma warning disable CS8601 // Possible null reference assignment.
        public static Dictionary<string, string> GetTestCaseDetails(this ITestOutputHelper helper)
        {
            Dictionary<string, string> testCaseDetail = new Dictionary<string, string>();
            var type = helper.GetType();
            var testMember = type.GetField("test", BindingFlags.Instance | BindingFlags.NonPublic);
            var testAssem = (ITest)testMember.GetValue(helper);           
            var testMethodName = testAssem.TestCase.TestMethod.Method.Name;
            var testClassName = testAssem.TestCase.TestMethod.TestClass.Class.Name.Split(".").Last();
            var testCaseDesc = "";
            var descriptionAttribute = testAssem.TestCase.TestMethod.Method.GetCustomAttributes(typeof(DescriptionAttribute)).ToList();
            if (descriptionAttribute.Count>0)
            {
                testCaseDesc = descriptionAttribute.First().GetConstructorArguments().First().ToString();
            }
            testCaseDetail["TestMethodName"] = testMethodName;
            testCaseDetail["TestClassName"] = testClassName;
            testCaseDetail["TestCaseDesc"] = testCaseDesc;
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
    }
}
