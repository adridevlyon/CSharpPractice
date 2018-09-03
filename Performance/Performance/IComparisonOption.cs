namespace Performance
{
    public interface IComparisonOption
    {
        string Name { get; }
        void Run();
    }
}