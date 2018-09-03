using System.Collections.Generic;

namespace Performance
{
    public interface IComparisonRunner
    {
        string Name { get; }
        Dictionary<int, IComparisonOption> OptionDictionary { get; }
    }
}