namespace Xunit.Extension.Equality
{
    public class InequalityOperatorTest<T>: OperatorTest<T>
    {
        public InequalityOperatorTest(T obj1, T obj2, bool expectedResult)
            : base("!=", "op_Inequality", obj1, obj2, expectedResult)
        {
        }
    }
}