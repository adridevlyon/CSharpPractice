using System.Collections.Generic;

namespace Performance.Collections
{
    public class ListArrayAddRunner : IComparisonRunner
    {
        public const string ConstName = "List versus Array for add";
        public string Name => ConstName;

        public Dictionary<int, IComparisonOption> OptionDictionary { get; }

        public ListArrayAddRunner()
        {
            OptionDictionary = new Dictionary<int, IComparisonOption>
            {
                {1, new OptionListAdd(10) },
                {2, new OptionListWithCapacityAdd(10) },
                {3, new OptionArrayAdd(10) },
                {4, new OptionListAdd(100) },
                {5, new OptionListWithCapacityAdd(100) },
                {6, new OptionArrayAdd(100) },
                {7, new OptionListAdd(1000) },
                {8, new OptionListWithCapacityAdd(1000) },
                {9, new OptionArrayAdd(1000) }
            };
        }
    }
}