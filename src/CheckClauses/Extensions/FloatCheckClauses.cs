using System;
namespace JuniorPorfirio.CheckClauses
{
    public static class FloatCheckClauses
    {
        public static float IsZero(this Clauses<float> clauses, string message = null)
        {
            return Check.Clauses(clauses.Name, clauses.Value).IsZero<float>(message);
        }

        public static float IsNegative(this Clauses<float> clauses, string message = null)
        {
            return Check.Clauses(clauses.Name, clauses.Value).IsNegative<float>(message);
        }
        public static float OutOfRange(this Clauses<float> clauses, float begin, float end, string message = null)
        {
            return Check.Clauses(clauses.Name, clauses.Value).OutOfRange<float>(begin, end, message);
        }
        public static float IsNegativeOrZero(this Clauses<float> clauses, string message = null)
        {
            return Check.Clauses(clauses.Name, clauses.Value).IsNegativeOrZero<float>(message);
        }



    }
}