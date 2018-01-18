namespace Xunit.Extension.Equality
{
    public class InequalityOperatorSignatureTest<T>: OperatorSignatureTest<T>
    {
        public InequalityOperatorSignatureTest()
            : base("!=", "op_Inequality")
        {
        }
    }
}