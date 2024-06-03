namespace XunitTestProjectDemo
{
    public class Calculator
    {
        IOperations operations;
        public bool outcome;
        public Calculator(IOperations operations)
        {
            this.operations = operations;
        }

        public int DoCalculations(int a, int b)
        {
            int result = 0;
            int sum = operations.Add(a, b);
            int mult = operations.Multiplications(sum, b);
            int sub = operations.Substraction(mult, b);
            int div = operations.Division(sub, b);
            try
            {
                result = ((a + b) * b - b) / b;
            }catch(Exception)
            {
                result = 0;
            }
            
            if (div == result)
            {
                outcome = true;
            }
            else outcome = false;
            return div;
        }

    }
}
