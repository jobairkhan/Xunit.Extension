using System;

namespace Xunit.Extension.TraitAttributes
{
    /// <summary>
    ///     Indicates the test has external dependencies.
    /// </summary>
    [AttributeUsage(AttributeTargets.Class | AttributeTargets.Method)]
    public sealed class IntegrationTestAttribute : CategoryTraitAttribute
    {
        private const string TestAttributeName = "Integration";

        /// <summary>
        ///     Initializes a new instance of the <see cref="IntegrationTestAttribute" /> class.
        /// </summary>
        public IntegrationTestAttribute() : base(TestAttributeName)
        {
        }

        /// <summary>
        ///     Initializes a new instance of the <see cref="IntegrationTestAttribute" /> class including <see cref="project" />
        ///     name.
        /// </summary>
        /// <param name="project">Project name</param>
        public IntegrationTestAttribute(string project) : base(TestAttributeName, project)
        {
        }
    }
}