namespace Xunit.Extension.Equality
{
    public class EqualsTest : TestCase
    {
        private readonly object _obj1;
        private readonly object _obj2;
        private readonly bool _expectedResult;

        public EqualsTest(object obj1, object obj2, bool expectedResult)
        {
            _obj1 = obj1;
            _obj2 = obj2;
            _expectedResult = expectedResult;
        }

        public override string Execute()
        {
            var actualResult = _obj1.Equals(_obj2);

            return
                actualResult == _expectedResult
                    ? string.Empty
                    : string.Format("Object.Equals({0}, {1}) returned {2} when expecting {3}",
                        ArgumentToString(_obj1),
                        ArgumentToString(_obj2),
                        actualResult,
                        _expectedResult);
        }

        public override string TestName => "Object.Equals test";
    }
}