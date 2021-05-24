namespace JuniorPorfirio.CheckClauses
{
    /// <summary>
    /// Simple class base to CheckClauses
    /// </summary>
    /// <typeparam name="T"></typeparam>
    public struct Clauses<T>
    {
        public T Value { get; set; }
        public string Name { get; set; }

        public Clauses(string name, T input)
        {
            Value = input;
            Name = name;
        }
    }
}