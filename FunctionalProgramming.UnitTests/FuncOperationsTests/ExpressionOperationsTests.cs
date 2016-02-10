namespace FunctionalProgramming.UnitTests.FuncOperationsTests
{
    using System;
    using System.Linq.Expressions;

    using FunctionalProgramming.UnitTests.Functional;

    using NUnit.Framework;

    /// <summary>
    /// Operations with expressions.
    /// </summary>
    [TestFixture]
    public class ExpressionOperationsTests
    {
        /// <summary>
        /// Expression operations under test.
        /// </summary>
        private ExpressionOperations expressionOperations;

        /// <summary>
        /// The setup.
        /// </summary>
        [OneTimeSetUp]
        public void SetUp()
        {
            this.expressionOperations = new ExpressionOperations();
        }

        /// <summary>
        /// Analyse an expression.
        /// </summary>
        [Test]
        public void UseExpressionToAnalyseFunc()
        {
            var objectHavingProperties = new HasProperties { Id = 1, Name = "Tester" };
            Expression<Func<HasProperties, string>> someExpressionOfFunc = e => e.Name.Substring(0, 2);
            var expression = this.expressionOperations.ExtractInformationAboutLambdaExpression(
                objectHavingProperties, someExpressionOfFunc);
            Assert.AreEqual("e.Name.Substring(0,2)", expression);
        }
    }
}