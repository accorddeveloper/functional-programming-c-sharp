namespace FunctionalProgramming.UnitTests.Functional
{
    using System;

    /// <summary>
    /// Func operations.
    /// </summary>
    public class FuncOperations
    {
        /// <summary>
        /// Invokes the functionDefition lambda function on the obj argument to extract a value from
        /// that object. Depending on the defintion of the lambda Func argument, it can return any
        /// value based on the object which will be pass into it as an argument ie. Func will
        /// receive obj as its one and only argument to act upon.
        /// </summary>
        /// <param name="obj">The instance which will be used as an argument on the function.</param>
        /// <param name="functionDefintion">
        /// The defintion of the function which the client will define and pass as a lambda expression.
        /// </param>
        /// <typeparam name="TInstance">The type of the instance.</typeparam>
        /// <typeparam name="TSomeTypeOnProperty">
        /// The type of the property. It will be automatically inferred from the return type of the
        /// functionDefition lambda argument.
        /// </typeparam>
        /// <returns>The value of the TSomeTypeOnProperty type.</returns>
        public TSomeTypeOnProperty ExtractValueFromInstance<TInstance, TSomeTypeOnProperty>(TInstance obj, Func<TInstance, TSomeTypeOnProperty> functionDefintion)
        {
            // All we have to do here is to invoke it on the instance passed through as the first argument.
            return functionDefintion.Invoke(obj);
        }
    }
}