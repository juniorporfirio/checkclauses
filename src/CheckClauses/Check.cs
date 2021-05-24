namespace JuniorPorfirio.CheckClauses
{
    /// <summary>
    /// Principal class to CheckClauses, where defined as extension method on Clauses
    /// </summary>
    public class Check
    {
        /// <summary>
        /// Configuration of the clauses to check
        /// </summary>
        /// <typeparam name="T">Type of clause</typeparam>
        /// <param name="name">Name of clause</param>
        /// <param name="value">Value to validation</param>
        /// <returns></returns>
        public static Clauses<T> Clauses<T>(string name, T value) => new Clauses<T>(name, value);
    }
}