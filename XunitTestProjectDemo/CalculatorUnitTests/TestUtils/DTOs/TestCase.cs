using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CalculatorUnitTests.TestUtils.DTOs
{
    public class TestCase
    {
        public int Id { get; set; }
        public string? Name { get; set; }
        public string? TestCaseError { get; set; }
        public DateTime StartTime { get; set; }
        public DateTime EndTime { get; set; }
        public string? Status { get; set; }        
        public string? Description { get; set; }
        public List<string>? Attributes { get; set; }
        public string? TestRunId { get; set; }
    }
}
