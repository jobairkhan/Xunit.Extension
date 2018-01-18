using System;

namespace Xunit.Extension.TraitAttributes
{
    /// <summary>
    ///     Indicates a test is a unit test.
    /// </summary>
    [AttributeUsage(AttributeTargets.Class | AttributeTargets.Method)]
    public sealed class UnitTestAttribute : CategoryTraitAttribute
    {
        private const string TestAttributeName = "Unit";

        /// <summary>
        ///     Initializes a new instance of the <see cref="UnitTestAttribute" /> class.
        /// </summary>
        public UnitTestAttribute() : base(TestAttributeName)
        {
        }

        /// <summary>
        ///     Initializes a new instance of the <see cref="UnitTestAttribute" /> class including <see cref="project" /> name.
        /// </summary>
        /// <param name="project">Project name</param>
        public UnitTestAttribute(string project) : base(TestAttributeName, project)
        {
        }
    }
}