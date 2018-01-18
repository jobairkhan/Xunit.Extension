namespace Xunit.Extension.Equality
{
    public abstract class TestCase
    {
        public abstract string Execute();
        public abstract string TestName { get; }

        protected string ArgumentToString(object obj)
        {
            return 
                obj == null 
                    ? "null" 
                    : obj.ToString();
        }
    }
}