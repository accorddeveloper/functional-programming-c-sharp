namespace FunctionalProgramming.UnitTests.FuncOperationsTests
{
    using System;

    using FunctionalProgramming.UnitTests.Functional;

    using NUnit.Framework;

    /// <summary>
    /// The action operations tests.
    /// </summary>
    [TestFixture]
    public class ActionOperationsTests
    {
        /// <summary>
        /// The action operations.
        /// </summary>
        private ActionOperations actionOperations;

        /// <summary>
        /// The setup.
        /// </summary>
        [OneTimeSetUp]
        public void Setup()
        {
            actionOperations = new ActionOperations();
        }

        /// <summary>
        /// Just a silly test to show how Action differs from Func. Action does not
        /// have a return value. It just acts based on the parameters that are provided to it. It's
        /// essentially void Func.
        /// </summary>
        [Test]
        public void UseActionOnAnObject()
        {
            Action<int, Example> action = (i, example) => { example.Id = i; };
            var ex = this.actionOperations.ExecuteAction(action);
            Assert.That(ex.Id, Is.EqualTo(1));
        }
    }
}