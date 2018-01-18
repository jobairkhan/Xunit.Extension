using Xunit;
using Xunit.Extension.Equality;
using Xunit.Extension.TraitAttributes;

namespace XUnit.Extension.Sample
{
    [UnitTest]
    public class EqualityTest
    {
        [TheorySentence]
        [InlineData("first ", "second")]
        [InlineData(" first", " second")]
        [InlineData(" first", "second")]
        [InlineData("first", "second ")]
        public void SimpleValueObject_TrimTest(string value1MayContainSpaces, string value2MayContainSpaces)
        {
            EqualityTests
                .For(new SimpleValueObject("first", "second"))
                .EqualTo(new SimpleValueObject(value1MayContainSpaces, value2MayContainSpaces))
                .Assert();
        }

        [FactSentence]
        public void SimpleValueObject_FullTest()
        {
            EqualityTests
                .For(new SimpleValueObject("first", "second"))
                .EqualTo(new SimpleValueObject("FIRST", "SECOND"))
                .EqualTo(new SimpleValueObject("First", "second"))
                .EqualTo(new SimpleValueObject("first", "SECOND"))
                .EqualTo(new SimpleValueObject("first ", "second"))
                .EqualTo(new SimpleValueObject("first", " second"))
                .UnequalTo(new SimpleValueObject("fi rst", "second"))
                .UnequalTo(new SimpleValueObject("not equal", "second"))
                .Assert();
        }

    }
}
