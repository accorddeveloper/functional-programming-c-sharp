namespace FunctionalProgramming.UnitTests.Functional
{
    using System;

    /// <summary>
    /// Action operations.
    /// </summary>
    public class ActionOperations
    {
        /// <summary>
        /// Executes an action on the value.
        /// </summary>
        /// <param name="action">
        /// The action method.
        /// </param>
        /// <returns>
        /// An instance of Example which the action method has acted upon.
        /// </returns>
        public Example ExecuteAction(Action<int, Example> action)
        {
            var ex = new Example();
            action.Invoke(1, ex);
            return ex;
        } 
    }
}