using System;
namespace JuniorPorfirio.CheckClauses
{
    public static class GuidCheckClauses
    {
        public static Guid NullEmpty(this Clauses<Guid> clauses, string message = null)
        {
            Check.Clauses(clauses.Name, clauses.Value).IsNull();

            if (clauses.Value == Guid.Empty)
                throw new ArgumentException(message ?? $"Field {clauses.Name} cannot be empty", clauses.Name);
            return clauses.Value;
        }
    }

}