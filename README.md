# Xunit.Extension


XUnit test Extension.

Added functionalites

1. Subclass of trait attributes to mark tests as Unit, Acceptance and Integration Test.
2. Subclass of Fact and theory sentence attribute 
[FactSentence] and [TheorySentence] are added to increase readability. On test explorer, test name will display with spaces and arrow (after test class name).
3. Equality test. 
_Original equality test code is copied from the pluralsight course 'Improving Testability Through Design' by Zoran Horvat;_ and changed to work with XUnit

### How to use
Please check the [sample](https://github.com/jobairkhan/Xunit.Extension/tree/master/sample/XUnit.Extension.Sample).


### Example

```C#
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
        public void ValueObject_TrimTest(string value1MayContainSpaces, string value2MayContainSpaces)
        {
            EqualityTests
                .For(new SimpleValueObject("first", "second"))
                .EqualTo(new SimpleValueObject(value1MayContainSpaces, value2MayContainSpaces))
                .Assert();
        }
    }
}

```

### Result

![alt testwindow](https://raw.githubusercontent.com/jobairkhan/Xunit.Extension/master/sample/TheorySentence.PNG)


FAQ:
 - I have added [FactSentence] but still displaying without spaces
 
 --> *Please close and open the solution*

