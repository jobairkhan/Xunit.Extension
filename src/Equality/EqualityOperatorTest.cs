namespace Xunit.Extension.Equality
{
    public class EqualityOperatorTest<T>: OperatorTest<T>
    {
        public EqualityOperatorTest(T obj1, T obj2, bool expectedResult)
            : base("==", "op_Equality", obj1, obj2, expectedResult)
        {
        }
    }
}