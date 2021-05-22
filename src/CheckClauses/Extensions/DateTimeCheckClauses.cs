using System;
namespace JuniorPorfirio.CheckClauses
{
    public static class DateTimeCheckClauses
    {
        public static DateTime OutOfRange(this Clauses<DateTime> clauses, DateTime begin, DateTime end)
        {
            return CustomCheckClauses.OutOfRange(Check.Clauses(clauses.Name, clauses.Value), begin, end);
        }
    }
}