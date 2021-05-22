using System;
namespace JuniorPorfirio.CheckClauses
{
    public static class DoubleCheckClauses
    {
        public static double IsZero(this Clauses<double> clauses, string message = null)
        {
            return Check.Clauses(clauses.Name, clauses.Value).IsZero<double>(message);
        }

        public static double IsNegative(this Clauses<double> clauses, string message = null)
        {
            return Check.Clauses(clauses.Name, clauses.Value).IsNegative<double>(message);
        }
        public static double OutOfRange(this Clauses<double> clauses, double begin, double end, string message = null)
        {
            return Check.Clauses(clauses.Name, clauses.Value).OutOfRange<double>(begin, end, message);
        }
        public static double IsNegativeOrZero(this Clauses<double> clauses, string message = null)
        {
            return Check.Clauses(clauses.Name, clauses.Value).IsNegativeOrZero<double>(message);
        }



    }
}