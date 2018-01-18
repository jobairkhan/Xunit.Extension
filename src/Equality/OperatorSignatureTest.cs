using System.Reflection;

namespace Xunit.Extension.Equality
{
    public class OperatorSignatureTest<T>: TestCase
    {

        private readonly string _signature;
        private readonly string _methodName;

        protected OperatorSignatureTest(string signature, string methodName)
        {
            _signature = signature;
            _methodName = methodName;
        }

        public override string Execute()
        {
            return 
                OperatorExists()
                    ? string.Empty
                    : $"{typeof(T).Name} does not implement operator {_signature}" ;
        }

        private bool OperatorExists()
        {
            const BindingFlags bindingFlags = BindingFlags.Static | BindingFlags.Public;

            var method = typeof(T).GetMethod(_methodName, bindingFlags);

            return method != null;
        }

        public override string TestName => $"Operator {_signature} signature test";
    }
}