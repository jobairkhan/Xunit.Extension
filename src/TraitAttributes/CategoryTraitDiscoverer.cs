using System.Collections.Generic;
using Xunit.Abstractions;
using Xunit.Sdk;

namespace Xunit.Extension.TraitAttributes
{
    public class CategoryTraitDiscoverer : ITraitDiscoverer
    {
        /// <summary>
        ///     The namespace of this class
        /// </summary>
        private const string Namespace = nameof(Xunit) + "." + nameof(Xunit.Extension) + "." + nameof(TraitAttributes);

        /// <summary>
        ///     The fully qualified name of this class
        /// </summary>
        internal const string FullyQualifiedName = Namespace + "." + nameof(CategoryTraitDiscoverer);

        /// <summary>
        ///     Gets the trait values from the Category attribute.
        /// </summary>
        /// <param name="traitAttribute">
        ///     The trait attribute containing the trait values.
        /// </param>
        /// <returns>
        ///     The trait values.
        /// </returns>
        public IEnumerable<KeyValuePair<string, string>> GetTraits(IAttributeInfo traitAttribute)
        {
            var projectNameValue = traitAttribute.GetNamedArgument<string>("ProjectName");

            var categoryValue = traitAttribute.GetNamedArgument<string>("Category");

            if (!string.IsNullOrWhiteSpace(projectNameValue))
                yield return new KeyValuePair<string, string>(
                    projectNameValue,
                    categoryValue);
        }
    }
}