
namespace XunitTestProjectDemo
{
    public interface IOperations
    {
        public int Add(int a, int b)
        {
            return a + b;
        }

        public int Substraction(int a, int b)
        {
            return (a - b);
        }

        public int Multiplications(int a, int b)
        {
            return a * b;
        }

        public int Division(int a, int b)
        {
            try
            {
                return a / b;
            }
            catch (Exception)
            {
                return -1;
            }
        }
    }
}
