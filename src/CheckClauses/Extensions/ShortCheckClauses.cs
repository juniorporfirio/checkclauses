using System;
namespace JuniorPorfirio.CheckClauses
{
    public static class ShortCheckClauses
    {
        public static short IsZero(this Clauses<short> clauses, string message = null)
        {
            return Check.Clauses(clauses.Name, clauses.Value).IsZero<short>(message);
        }
        public static short IsNegative(this Clauses<short> clauses, string message = null)
        {
            return Check.Clauses(clauses.Name, clauses.Value).IsNegative<short>(message);
        }

        public static short IsNegativeOrZero(this Clauses<short> clauses, string message = null)
        {
            return Check.Clauses(clauses.Name, clauses.Value).IsNegativeOrZero<short>(message);
        }
    }
}