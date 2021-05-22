namespace JuniorPorfirio.CheckClauses
{
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