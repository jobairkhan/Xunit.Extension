using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;

namespace Xunit.Extension.Equality
{
    public class Tester<T>
    {
        private readonly T _objectToCompare;
        private readonly TestCase[] _testCases;

        public Tester(T obj)
        {

            _objectToCompare = obj;

            var tests = new List<TestCase>()
            {
                new EqualityOperatorSignatureTest<T>(),
                new InequalityOperatorSignatureTest<T>()
            };

            if (!typeof(T).GetTypeInfo().IsValueType)
            {
                tests.Add(new EqualsTest(obj, null, false));
                tests.Add(new TypedEqualsTest<T>(obj, default(T), false));
                tests.Add(new EqualityOperatorTest<T>(obj, default(T), false));
                tests.Add(new InequalityOperatorTest<T>(obj, default(T), true));
                tests.AddRange(FindInterfaceEqualsTests(default(T), false));
            };

            _testCases = tests.ToArray();
        }

        private Tester(Tester<T> tester, TestCase testCase)
        {

            var testCases = new TestCase[tester._testCases.Length + 1];
            Array.Copy(tester._testCases, testCases, tester._testCases.Length);
            testCases[tester._testCases.Length] = testCase;

            _objectToCompare = tester._objectToCompare;
            _testCases = testCases;

        }

        public Tester<T> EqualTo(T obj)
        {
            return this
                .Add(new EqualsTest(_objectToCompare, obj, true))
                .Add(new TypedEqualsTest<T>(_objectToCompare, obj, true))
                .Add(new EqualityOperatorTest<T>(_objectToCompare, obj, true))
                .Add(new InequalityOperatorTest<T>(_objectToCompare, obj, false))
                .Add(new GetHashCodeTest<T>(_objectToCompare, obj))
                .AddInterfacesEqualsTests(obj, true);
        }

        public Tester<T> UnequalTo(T obj)
        {
            return this
                .Add(new EqualsTest(_objectToCompare, obj, false))
                .Add(new TypedEqualsTest<T>(_objectToCompare, obj, false))
                .Add(new EqualityOperatorTest<T>(_objectToCompare, obj, false))
                .Add(new InequalityOperatorTest<T>(_objectToCompare, obj, true))
                .AddInterfacesEqualsTests(obj, false);
        }

        private Tester<T> Add(TestCase testCase)
        {
            return new Tester<T>(this, testCase);
        }

        private Tester<T> AddInterfacesEqualsTests(T obj, bool expectedResult)
        {

            var tester = this;

            return 
                FindInterfaceEqualsTests(obj, expectedResult)
                .Aggregate(tester, 
                           (current, tc) => current.Add(tc));

        }

        private IEnumerable<TestCase> FindInterfaceEqualsTests(T obj, bool expectedResult)
        {

            var tests = new List<TestCase>();

            foreach (var baseInterface in typeof(T).GetInterfaces())
            {

                var iequatableType = typeof(IEquatable<>).MakeGenericType(baseInterface);

                if (typeof(T).GetInterfaces().Any(x => x == iequatableType))
                {
                    var testerType = typeof(TypedEqualsTest<>).MakeGenericType(baseInterface);

                    var ctor = testerType.GetConstructor(new Type[] {baseInterface, baseInterface, typeof(bool)});
                    var arguments = new object[] {_objectToCompare, obj, expectedResult};

                    var testCase = (TestCase) ctor.Invoke(arguments);

                    tests.Add(testCase);
                }
            }

            return tests;
        }

        public void Assert()
        {
            var errors = CollectErrors();
            Xunit.Assert
                 .True(
                    string.IsNullOrEmpty(errors), 
                    errors);
        }

        private string CollectErrors()
        {

            var errors = ExecuteTestCases();

            return 
                errors.Length <= 0 
                    ? string.Empty 
                    : $"Some test cases failed:\n{string.Join(Environment.NewLine, errors)}";
        }

        private string[] ExecuteTestCases()
        {
            return 
                _testCases
                    .Select(ExecuteTestCase)
                    .Where(s => !string.IsNullOrEmpty(s)).ToArray();
        }

        private static string ExecuteTestCase(TestCase testCase)
        {
            try
            {
                return testCase.Execute();
            }
            catch (Exception ex)
            {
                return $"{testCase.TestName} threw {ex.GetType().Name}: {ex.Message}";
            }
        }
    }
}