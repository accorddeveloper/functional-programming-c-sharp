namespace FunctionalProgramming.UnitTests.FuncOperationsTests
{
    using System;

    using FunctionalProgramming.UnitTests.Functional;

    using NUnit.Framework;

    /// <summary>
    /// Extraxcting property values tests.
    /// </summary>
    [TestFixture]
    public class ExtractValueFromInstanceTests
    {
        /// <summary>
        /// Functional operations under test.
        /// </summary>
        private FuncOperations funcOperations;

        /// <summary>
        /// The setup.
        /// </summary>
        [OneTimeSetUp]
        public void SetUp()
        {
            this.funcOperations = new FuncOperations();
        }

        /// <summary>
        /// Test if we can extract a string property value from an instance.
        /// </summary>
        [Test]
        public void ExtractStringValue()
        {
            var objectHavingProperties = new HasProperties { Name = "Tester" };
            var result = this.funcOperations.ExtractValueFromInstance(objectHavingProperties, e => e.Name);

            Assert.AreEqual("Tester", result);
        }

        /// <summary>
        /// Test if we can extract an int property value from an instance.
        /// </summary>
        [Test]
        public void ExtractIntValue()
        {
            var objectHavingProperties = new HasProperties { Id = 10 };
            var result = this.funcOperations.ExtractValueFromInstance(objectHavingProperties, e => e.Id);

            Assert.AreEqual(10, result);
        }

        /// <summary>
        /// Test if we can return any value we want by processing an instance of HasProperties by
        /// our lambda function.
        /// </summary>
        [Test]
        public void UseInstanceWithLambdaFunction()
        {
            var objectHavingProperties = new HasProperties { Id = 10 };

            // Takes an instance of HasProperties as its only parameter and returns a string value.
            // We pass this function like a normal variable. This is functional programming. We
            // treat functions like values.
            Func<HasProperties, string> someLambda = e =>
                    {
                        var s = "Id + 2 = " + (e.Id + 2);
                        return s;
                    };

            var result = this.funcOperations.ExtractValueFromInstance(objectHavingProperties, someLambda);

            Assert.AreEqual("Id + 2 = 12", result);
        }
    }
}