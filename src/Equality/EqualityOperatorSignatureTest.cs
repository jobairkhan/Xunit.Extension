namespace Xunit.Extension.Equality
{
    public class EqualityOperatorSignatureTest<T>: OperatorSignatureTest<T>
    {
        public EqualityOperatorSignatureTest()
            : base("==", "op_Equality")
        {
        }
    }
}