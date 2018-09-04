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
                {1, new OptionList(3) },
                {2, new OptionHashset(3) },
                {3, new OptionList(10) },
                {4, new OptionHashset(10) },
                {5, new OptionList(20) },
                {6, new OptionHashset(20) },
                {7, new OptionList(30) },
                {8, new OptionHashset(30) }
            };
        }
    }
}