namespace JuniorPorfirio.CheckClauses
{
    public class Check
    {
        public static Clauses<T> Clauses<T>(string name, T input) => new Clauses<T>(name, input);
    }
}