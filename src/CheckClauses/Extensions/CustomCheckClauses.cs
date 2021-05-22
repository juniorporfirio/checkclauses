using System.Collections;
using System;
using System.Collections.Generic;

namespace JuniorPorfirio.CheckClauses
{
    public static class CustomCheckClauses
    {
        public static T IsNull<T>(this Clauses<T> clauses, string message = null)
        {
            if (clauses.Value == null)
                throw new ArgumentNullException(clauses.Name, message ?? $"Field {clauses.Name} cannot be null.");

            return clauses.Value;
        }
        public static T Where<T>(this Clauses<T> clauses, Func<T, bool> func, string message = null)
        {
            if (func(clauses.Value) == false)
                throw new ArgumentException(message ?? $"Field {clauses.Name} is invalid rules", clauses.Name);
            return clauses.Value;
        }
        public static T OutOfRange<T>(this Clauses<T> clauses, T begin, T end, string message = null)
        {

            Comparer<T> comparer = Comparer<T>.Default;
            if (comparer.Compare(clauses.Value, begin) < 0 ||
                comparer.Compare(clauses.Value, end) > 0)
                throw new ArgumentOutOfRangeException(clauses.Name, message ?? $"Field {clauses.Name} cannot be out of range {begin} and {end}");
            return clauses.Value;
        }
        public static T IsZero<T>(this Clauses<T> clauses, string message = null) where T : struct
        {
            if (EqualityComparer<T>.Default.Equals(clauses.Value, default(T)))
                throw new ArgumentException(message ?? $"Field {clauses.Name} cannot be zero", clauses.Name);
            return clauses.Value;
        }

        public static T IsNegative<T>(this Clauses<T> clauses, string message = null) where T : struct, IComparable
        {
            if (clauses.Value.CompareTo(default(T)) < 0)
                throw new ArgumentException(message ?? $"Field {clauses.Name} cannot be negative", clauses.Name);
            return clauses.Value;
        }
        public static T IsNegativeOrZero<T>(this Clauses<T> clauses, string message = null) where T : struct, IComparable
        {
            if (clauses.Value.CompareTo(default(T)) <= 0)
                throw new ArgumentException(message ?? $"Field {clauses.Name} cannot be negative or zero", clauses.Name);
            return clauses.Value;
        }

    }
}