using System;
using System.Linq;

namespace Xunit.Extension.Equality
{
    public class TypedEqualsTest<T>: TestCase
    {
        private readonly IEquatable<T> _obj1;
        private readonly T _obj2;
        private readonly bool _expectedResult;

        public TypedEqualsTest(T obj1, T obj2, bool expectedResult)
        {
            _obj1 = obj1 as IEquatable<T>;
            _obj2 = obj2;
            _expectedResult = expectedResult;
        }

        public override string Execute()
        {
            
            if (typeof(T).GetInterfaces().All(x => x != typeof(IEquatable<T>)))
                return string.Empty;

            var actualResult = ((IEquatable<T>)_obj1).Equals(_obj2);
            if (actualResult != _expectedResult)
                return string.Format("IEquatable<{0}>.Equals({1}, {2}) returned {3} when expecting {4}",
                                     typeof(T).Name, 
                                     ArgumentToString(_obj1),
                                     ArgumentToString(_obj2), 
                                     actualResult, _expectedResult);

            return string.Empty;

        }

        public override string TestName => $"IEquatable<{typeof(T).Name}>.Equals test";
    }
}