namespace Performance
{
    public class ComparisonResult
    {
        public string OptionName { get; }
        public long ExecutionDurationMilliseconds { get; }

        public ComparisonResult(string optionName, long executionDurationMilliseconds)
        {
            OptionName = optionName;
            ExecutionDurationMilliseconds = executionDurationMilliseconds;
        }
    }
}