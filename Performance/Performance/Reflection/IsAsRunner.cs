using System.Collections.Generic;

namespace Performance.Reflection
{
    public class IsAsRunner : IComparisonRunner
    {
        public const string ConstName = "Is versus As";
        public string Name => ConstName;

        public Dictionary<int, IComparisonOption> OptionDictionary { get; }

        public IsAsRunner()
        {
            OptionDictionary = new Dictionary<int, IComparisonOption>
            {
                {1, new OptionIsAs() },
                {2, new OptionAs() },
                {3, new OptionIsCast() },
                {4, new OptionIsPatternMatching() }
            };
        }
    }
}