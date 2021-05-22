using System;
namespace JuniorPorfirio.CheckClauses
{
    public static class TimeSpanCheckClauses
    {
        public static TimeSpan IsZero(this Clauses<TimeSpan> clauses, string message = null)
        {
            return Check.Clauses(clauses.Name, clauses.Value).IsZero<TimeSpan>(message);
        }
        public static TimeSpan IsNegative(this Clauses<TimeSpan> clauses, string message = null)
        {
            return Check.Clauses(clauses.Name, clauses.Value).IsNegative<TimeSpan>(message);
        }
        public static TimeSpan OutOfRange(this Clauses<TimeSpan> clauses, TimeSpan begin, TimeSpan end, string message = null)
        {
            return Check.Clauses(clauses.Name, clauses.Value).OutOfRange<TimeSpan>(begin, end, message);
        }
        public static TimeSpan IsNegativeOrZero(this Clauses<TimeSpan> clauses, string message = null)
        {
            return Check.Clauses(clauses.Name, clauses.Value).IsNegativeOrZero<TimeSpan>(message);
        }



    }
}