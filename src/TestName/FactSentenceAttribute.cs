using System.IO;
using System.Runtime.CompilerServices;
using System.Text.RegularExpressions;
using Xunit;

/// <summary>
///     Attribute that is applied to a method to indicate that it is a fact that
///     should be run by the test runner. The name of the method will be used as
///     the test method's <see cref="Xunit.FactAttribute.DisplayName" /> after
///     being reformatted by replacing specific characters in the method's name
///     with other characters.
/// </summary>
// ReSharper disable once CheckNamespace
public class FactSentenceAttribute : FactAttribute
{
    /// <summary>
    ///     Attribute that is applied to a method to indicate that it is a fact that
    ///     should be run by the test runner. The name of the method will be used as
    ///     the test method's <see cref="Xunit.FactAttribute.DisplayName" /> after
    ///     being reformatted by replacing specific characters in the method's name
    ///     with other characters.
    /// </summary>
    /// <param name="charsToReplace">
    ///     A <see cref="string" /> containing the characters
    ///     to replace in the test method's name (e.g. "_").
    /// </param>
    /// <param name="replacementChars">
    ///     A <see cref="string" /> containing the characters (e.g. " ") that will
    ///     replace those specified by the <paramref name="charsToReplace" /> parameter
    ///     that are found in the test method's name.
    /// </param>
    /// <param name="testMethodName">
    ///     This is automatically set to the name of the current method;
    ///     there's no need to set a value for this parameter.
    /// </param>
    /// <param name="callerFile">
    ///     This is automatically set to the file name of the current method;
    ///     there's no need to set a value for this parameter.
    /// </param>
    public FactSentenceAttribute(string charsToReplace = "_",
        string replacementChars = " -",
        [CallerMemberName] string testMethodName = "",
        [CallerFilePath] string callerFile = "")
    {
        if (charsToReplace != null)
        {
            var value = testMethodName?.Replace(charsToReplace, replacementChars);
            value = Regex.Replace(value, @"((?<=\p{Ll})\p{Lu})|((?!\A)\p{Lu}(?>\p{Ll}))", " $0");
            value = value.Replace("- Should ", ">> Should ");

            var callerClass = GetClassName(callerFile);
            // ReSharper disable once RedundantBaseQualifier
            base.DisplayName = callerClass + value;
        }
    }

    private static string GetClassName(string callerFile)
    {
        if (string.IsNullOrWhiteSpace(callerFile))
            return string.Empty;

        var testClassName = Path.GetFileName(callerFile)?.Replace(".cs", "");


        var tailingTests = "Tests";
        var tailLength = tailingTests.Length;
        var classNameWitoutTailingTests = testClassName?.EndsWith(tailingTests) == true
            ? testClassName.Remove(testClassName.Length - tailLength)
            : testClassName;

        return $"{classNameWitoutTailingTests}-> ";
    }
}