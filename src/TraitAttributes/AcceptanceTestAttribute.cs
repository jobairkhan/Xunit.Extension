using System;

namespace Xunit.Extension.TraitAttributes
{
    /// <summary>
    ///     Indicates a test is a user acceptance test.
    /// </summary>
    [AttributeUsage(AttributeTargets.Class | AttributeTargets.Method)]
    public sealed class AcceptanceTestAttribute : CategoryTraitAttribute
    {
        private const string TestAttributeName = "Acceptance";

        /// <summary>
        ///     Initializes a new instance of the <see cref="AcceptanceTestAttribute" /> class.
        /// </summary>
        public AcceptanceTestAttribute() : base(TestAttributeName)
        {
        }

        /// <summary>
        ///     Initializes a new instance of the <see cref="AcceptanceTestAttribute" /> class including <see cref="project" />
        ///     name.
        /// </summary>
        /// <param name="project">Project name</param>
        public AcceptanceTestAttribute(string project) : base(TestAttributeName, project)
        {
        }
    }
}