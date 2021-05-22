using System.Linq;
using System.Text.RegularExpressions;
using System;
namespace JuniorPorfirio.CheckClauses
{
    public static class StringCheckClauses
    {
        public static string IsNullOrEmpty(this Clauses<string> clauses, string message = null)
        {
            if (string.IsNullOrEmpty(clauses.Value))
                throw new ArgumentException(message ?? $"Field {clauses.Name} cannot be null or empty", clauses.Name);
            return clauses.Value;
        }
        public static string IsNullOrWhiteSpace(this Clauses<string> clauses, string message = null)
        {
            if (string.IsNullOrWhiteSpace(clauses.Value))
                throw new ArgumentException(message ?? $"Field {clauses.Name} cannot be null or with white space", clauses.Name);
            return clauses.Value;
        }
        public static string IsMatchRegex(this Clauses<string> clauses, string rule, string message = null)
        {
            if (clauses.Value != Regex.Match(clauses.Value, rule).Value)
                throw new ArgumentException(message ?? $"Field {clauses.Name} was with invalid format", clauses.Name);
            return clauses.Value;
        }
        public static string IsNumber(this Clauses<string> clauses, string message = null)
        {
            if (clauses.Value.Any(s => Char.IsNumber(s) == false))
                throw new ArgumentException(message ?? $"Field {clauses.Name} should be numeric");
            return clauses.Value;
        }
        public static string MaxLength(this Clauses<string> clauses, int max, string message = null)
        {
            if (clauses.Value.Length > max)
                throw new ArgumentException(message ?? $"Field {clauses.Name} cannot be minor than {max} caracteres");
            return clauses.Value;
        }
    }
}