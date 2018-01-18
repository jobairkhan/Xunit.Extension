using System;
using Xunit.Sdk;

namespace Xunit.Extension.TraitAttributes
{
    /// <summary>
    ///     Applies a category trait to a test.
    /// </summary>
    [TraitDiscoverer(CategoryTraitDiscoverer.FullyQualifiedName, "Xunit.Extension")]
    [AttributeUsage(AttributeTargets.Class | AttributeTargets.Method, AllowMultiple = true)]
    public abstract class CategoryTraitAttribute : Attribute, ITraitAttribute
    {
        /// <summary>
        ///     Initializes a new instance of the <see cref="CategoryTraitAttribute" /> class.
        /// </summary>
        /// <param name="category">The category of the test (e.g. Unit or Integration)</param>
        /// <param name="project">The name of the test project</param>
        protected CategoryTraitAttribute(string category, string project) : this(category)
        {
            ProjectName = project;
        }

        /// <summary>
        ///     Initializes a new instance of the <see cref="CategoryTraitAttribute" /> class.
        /// </summary>
        /// <param name="category">The category of the test (e.g. Unit or Integration)</param>
        protected CategoryTraitAttribute(string category)
        {
            Category = category;
        }

        /// <summary>
        ///     Gets the value of the Category trait.
        /// </summary>
        public string Category { get; }

        /// <summary>
        ///     To show the project name
        /// </summary>
        public string ProjectName { get; }
    }
}