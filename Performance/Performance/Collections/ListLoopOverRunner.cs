using System.Collections.Generic;

namespace Performance.Collections
{
    public class ListLoopOverRunner : IComparisonRunner
    {
        public const string ConstName = "Foreach versus For versus Linq for list loop over";
        public string Name => ConstName;

        public Dictionary<int, IComparisonOption> OptionDictionary { get; }

        public ListLoopOverRunner()
        {
            OptionDictionary = new Dictionary<int, IComparisonOption>
            {
                {1, new OptionListLoopForeach(10) },
                {2, new OptionListLoopFor(10) },
                {3, new OptionListLoopLinq(10) },
                {4, new OptionListLoopForeach(100) },
                {5, new OptionListLoopFor(100) },
                {6, new OptionListLoopLinq(100) },
                {7, new OptionListLoopForeach(1000) },
                {8, new OptionListLoopFor(1000) },
                {9, new OptionListLoopLinq(1000) }
            };
        }
    }
}