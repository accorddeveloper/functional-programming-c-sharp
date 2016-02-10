namespace FunctionalProgramming.UnitTests.Functional
{
    using System;
    using System.Linq;
    using System.Linq.Expressions;
    using System.Runtime.CompilerServices;

    /// <summary>
    /// Expression operations.
    /// </summary>
    public class ExpressionOperations
    {
        /// <summary>
        /// Converts an expression to string.
        /// </summary>
        /// <param name="expression">
        /// An expression of a func.
        /// </param>
        /// <returns>
        /// Returns the definition of a function as an <see cref="string"/>.
        /// </returns>
        public string ExpressionToString(Expression expression)
        {
            while (true)
            {
                switch (expression.NodeType)
                {
                    case ExpressionType.Lambda:
                        // x => (Something), return only (Something), the Body
                        expression = ((LambdaExpression)expression).Body;
                        continue;

                    case ExpressionType.Convert:
                    case ExpressionType.ConvertChecked:
                        // type casts are not important
                        expression = ((UnaryExpression)expression).Operand;
                        continue;

                    case ExpressionType.Call:
                        // method call can be an Indexer (get_Item),
                        var callExpr = (MethodCallExpression)expression;
                        if (callExpr.Method.Name == "get_Item")
                        {
                            // indexer call
                            return this.ExpressionToString(callExpr.Object) + "[" + string.Join(",", callExpr.Arguments.Select(this.ExpressionToString)) + "]";
                        }
                        else
                        {
                            // method call
                            var arguments = callExpr.Arguments.Select(this.ExpressionToString).ToArray();
                            string target;
                            if (callExpr.Method.IsDefined(typeof(ExtensionAttribute), false))
                            {
                                // extension method
                                target = string.Join(".", arguments[0], callExpr.Method.Name);
                                arguments = arguments.Skip(1).ToArray();
                            }
                            else if (callExpr.Object == null)
                            {
                                // static method
                                target = callExpr.Method.Name;
                            }
                            else
                            {
                                // instance method
                                target = string.Join(".", this.ExpressionToString(callExpr.Object), callExpr.Method.Name);
                            }
                            return target + "(" + string.Join(",", arguments) + ")";
                        }

                    case ExpressionType.MemberAccess:
                        // property or field access
                        var memberExpr = (MemberExpression)expression;
                        return memberExpr.Expression.Type.Name.Contains("<>") ? memberExpr.Member.Name : string.Join(".", this.ExpressionToString(memberExpr.Expression), memberExpr.Member.Name);
                }

                // by default, show the standard implementation
                return expression.ToString();
            }
        }

        /// <summary>
        /// Extracts information about a lambda expression.
        /// </summary>
        /// <param name="obj">
        /// The instance which will be used as an argument on the function.
        /// </param>
        /// <param name="expressionOfFunctionDefintion">
        /// The expression of a function which the client will define and pass in.
        /// </param>
        /// <typeparam name="TInstance">
        /// The type of the instance.
        /// </typeparam>
        /// <typeparam name="TResult">
        /// The type of the result of the lambda function.
        /// </typeparam>
        /// <returns>
        /// The string representation of the expression.
        /// </returns>
        public string ExtractInformationAboutLambdaExpression<TInstance, TResult>(TInstance obj, Expression<Func<TInstance, TResult>> expressionOfFunctionDefintion)
        {
            return ExpressionToString(expressionOfFunctionDefintion);
        }
    }
}