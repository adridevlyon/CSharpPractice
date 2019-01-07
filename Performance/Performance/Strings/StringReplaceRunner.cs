using System.Collections.Generic;

namespace Performance.Strings
{
    public class StringReplaceRunner : IComparisonRunner
    {
        public const string ConstName = "String replace char loop versus Regex versus compiled Regex";
        public string Name => ConstName;

        public Dictionary<int, IComparisonOption> OptionDictionary { get; }

        public StringReplaceRunner()
        {
            OptionDictionary = new Dictionary<int, IComparisonOption>
            {
                {1, new OptionCharLoop() },
                {2, new OptionRegex() },
                {3, new OptionCompiledRegex() },
                {4, new OptionCharLoopStringBuilder() }
            };
        }
    }
}