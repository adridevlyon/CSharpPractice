using System.Collections.Generic;

namespace Performance.Collections
{
    public class HashSetListContainsRunner : IComparisonRunner
    {
        public const string ConstName = "Hashset versus List for contains";
        public string Name => ConstName;

        public Dictionary<int, IComparisonOption> OptionDictionary { get; }

        public HashSetListContainsRunner()
        {
            OptionDictionary = new Dictionary<int, IComparisonOption>
            {
                {1, new OptionListContains(3) },
                {2, new OptionHashsetContains(3) },
                {3, new OptionListContains(10) },
                {4, new OptionHashsetContains(10) },
                {5, new OptionListContains(20) },
                {6, new OptionHashsetContains(20) },
                {7, new OptionListContains(30) },
                {8, new OptionHashsetContains(30) }
            };
        }
    }
}