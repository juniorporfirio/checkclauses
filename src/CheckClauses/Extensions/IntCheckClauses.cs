using System;
namespace JuniorPorfirio.CheckClauses
{
    public static class IntCheckClauses
    {
        public static int IsZero(this Clauses<int> clauses, string message = null)
        {
            return Check.Clauses(clauses.Name, clauses.Value).IsZero<int>(message);
        }

        public static int IsNegative(this Clauses<int> clauses, string message = null)
        {
            return Check.Clauses(clauses.Name, clauses.Value).IsNegative<int>(message);
        }
        public static int OutOfRange(this Clauses<int> clauses, int begin, int end, string message = null)
        {
            return Check.Clauses(clauses.Name, clauses.Value).OutOfRange<int>(begin, end, message);
        }
        public static int IsNegativeOrZero(this Clauses<int> clauses, string message = null)
        {
            return Check.Clauses(clauses.Name, clauses.Value).IsNegativeOrZero<int>(message);
        }



    }
}