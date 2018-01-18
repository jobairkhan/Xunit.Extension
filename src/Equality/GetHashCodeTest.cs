namespace Xunit.Extension.Equality
{
    public class GetHashCodeTest<T> : TestCase
    {
        private readonly T _obj1;
        private readonly T _obj2;

        public GetHashCodeTest(T obj1, T obj2)
        {
            _obj1 = obj1;
            _obj2 = obj2;
        }

        public override string Execute()
        {

            var hash1 = _obj1.GetHashCode();
            var hash2 = _obj2.GetHashCode();

            return
                hash1 == hash2
                ? string.Empty
                : string.Format(
                        "GetHashCode({0} = {1} and GetHashCode({2}) = {3} when expecting equal values",
                        ArgumentToString(_obj1), 
                        hash1,
                        ArgumentToString(_obj2), 
                        hash2);
        }

        public override string TestName => $"{typeof(T).Name}.GetHashCode test";
    }
}