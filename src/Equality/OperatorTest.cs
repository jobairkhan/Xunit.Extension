using System.Reflection;

namespace Xunit.Extension.Equality
{
    public class OperatorTest<T>: TestCase
    {
        private readonly T _obj1;
        private readonly T _obj2;
        private readonly string _signature;
        private readonly string _methodName;
        private readonly bool _expectedResult;

        protected OperatorTest(string signature, string methodName, T obj1, T obj2, bool expectedResult)
        {
            _signature = signature;
            _methodName = methodName;
            _obj1 = obj1;
            _obj2 = obj2;
            _expectedResult = expectedResult;
        }

        public override string Execute()
        {
            var method = FindOperator();
            return TestOperator(method);
        }

        private MethodInfo FindOperator()
        {
            const BindingFlags bindingFlags = BindingFlags.Static | BindingFlags.Public;
            return typeof(T).GetMethod(_methodName, bindingFlags);
        }

        private string TestOperator(MethodInfo method)
        {
            return 
                method == null 
                    ? string.Empty 
                    : SafeTestOperator(method);
        }

        private string SafeTestOperator(MethodInfo method)
        {
            var actualResult = CallOperator(method);

            return 
                actualResult == _expectedResult
                ? string.Empty
                : string.Format("{0} {1} {2} returned {3} when expecting {4}",
                        ArgumentToString(_obj1), 
                        _signature,
                        ArgumentToString(_obj2), 
                        actualResult, 
                        _expectedResult);
        }

        private bool CallOperator(MethodInfo method)
        {
            try
            {
                return (bool)method.Invoke(null, new object[] { _obj1, _obj2 });
            }
            catch (TargetInvocationException ex)
            {
                throw ex.InnerException;
            }
        }

        public override string TestName => string.Format("Operator {0} test", _signature);
    }
}