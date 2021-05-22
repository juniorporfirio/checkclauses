using System;
namespace JuniorPorfirio.CheckClauses
{
    public static class DecimalCheckClauses
    {
        public static decimal IsZero(this Clauses<decimal> clauses, string message = null)
        {
            return Check.Clauses(clauses.Name, clauses.Value).IsZero<decimal>(message);
        }

        public static decimal IsNegative(this Clauses<decimal> clauses, string message = null)
        {
            return Check.Clauses(clauses.Name, clauses.Value).IsNegative<decimal>(message);
        }
        public static decimal OutOfRange(this Clauses<decimal> clauses, decimal begin, decimal end, string message = null)
        {
            return Check.Clauses(clauses.Name, clauses.Value).OutOfRange<decimal>(begin, end, message);
        }
        public static decimal IsNegativeOrZero(this Clauses<decimal> clauses, string message = null)
        {
            return Check.Clauses(clauses.Name, clauses.Value).IsNegativeOrZero<decimal>(message);
        }



    }
}