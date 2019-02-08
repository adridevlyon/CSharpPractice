using System.Collections.Generic;
using System.Text;

namespace Performance
{
    public class ComparisonExecutionResult
    {
        public string ComparisonName { get; }
        public List<int> OptionsToRun { get; }
        public int NumberTimes { get; }
        public Dictionary<int, ComparisonResult> Results { get; } = new Dictionary<int, ComparisonResult>();

        public ComparisonExecutionResult(string comparisonName, List<int> optionsToRun, int numberTimes)
        {
            ComparisonName = comparisonName;
            OptionsToRun = optionsToRun;
            NumberTimes = numberTimes;
        }

        public string GetJournal()
        {
            var resultBuilder = new StringBuilder();
            var optionsText = OptionsToRun == null ? "all options" : $"options : {string.Join(" vs ", OptionsToRun)}";
            resultBuilder.AppendLine($"*** Run comparison {ComparisonName} with {optionsText} and {NumberTimes} executions ***");

            foreach (var comparisonResult in Results)
            {
                var option = comparisonResult.Key;
                var result = comparisonResult.Value;

                resultBuilder.AppendLine($"** Option {option} - {result.OptionName} : {result.ExecutionDurationMilliseconds} ms");
            }

            resultBuilder.AppendLine();
            resultBuilder.AppendLine("*** End of comparison ***");

            return resultBuilder.ToString();
        }
    }
}