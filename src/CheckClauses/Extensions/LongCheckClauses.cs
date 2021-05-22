using System;
namespace JuniorPorfirio.CheckClauses
{
    public static class LongCheckClauses
    {
        public static long IsZero(this Clauses<long> clauses, string message = null)
        {
            return Check.Clauses(clauses.Name, clauses.Value).IsZero<long>(message);
        }

        public static long IsNegative(this Clauses<long> clauses, string message = null)
        {
            return Check.Clauses(clauses.Name, clauses.Value).IsNegative<long>(message);
        }

        public static long IsNegativeOrZero(this Clauses<long> clauses, string message = null)
        {
            return Check.Clauses(clauses.Name, clauses.Value).IsNegativeOrZero<long>(message);
        }
    }
}