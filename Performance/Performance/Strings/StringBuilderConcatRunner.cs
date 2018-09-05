using System.Collections.Generic;

namespace Performance.Strings
{
    public class StringBuilderConcatRunner : IComparisonRunner
    {
        public const string ConstName = "String builder versus String concatenation";
        public string Name => ConstName;

        public Dictionary<int, IComparisonOption> OptionDictionary { get; }

        public StringBuilderConcatRunner()
        {
            OptionDictionary = new Dictionary<int, IComparisonOption>
            {
                {1, new OptionStringBuilder(3) },
                {2, new OptionConcat(3) },
                {3, new OptionStringBuilder(5) },
                {4, new OptionConcat(5) },
                {5, new OptionStringBuilder(7) },
                {6, new OptionConcat(7) },
                {7, new OptionStringBuilder(9) },
                {8, new OptionConcat(9) },
                {9, new OptionStringBuilder(11) },
                {10, new OptionConcat(11) },
                {11, new OptionStringBuilder(13) },
                {12, new OptionConcat(13) },
                {13, new OptionStringBuilder(15) },
                {14, new OptionConcat(15) },
                {15, new OptionStringBuilder(20) },
                {16, new OptionConcat(20) }
            };
        }
    }
}