namespace CalculatorUnitTests.TestUtils.DTOs
{
    public class TestCase
    {
        public int Id { get; set; }
        public string? TestRunId { get; set; }
        public string? Name { get; set; }
        public string? Description { get; set; }
        public List<string>? Attributes { get; set; }        
        public DateTime StartTime { get; set; }
        public DateTime EndTime { get; set; }
        public string? Status { get; set; }
        public string? ErrorMsg { get; set; }
        public string? StackTrace { get; set; }
    }
}
