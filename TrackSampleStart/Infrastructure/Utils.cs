using System;
using System.Linq.Expressions;

namespace TrackSampleStart.Infrastructure
{
    public static class Utils
    {
        public static void ThrowIfNull(Expression<Func<object>> expression)
        {
            var res = expression.Compile();

            if (res.Invoke() != null) return;

            var lambda = (LambdaExpression)expression;
            var member = (MemberExpression)lambda.Body;
            throw new ArgumentNullException(member.Member.Name);
        }
    }
}