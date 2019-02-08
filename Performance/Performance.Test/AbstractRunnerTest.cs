using Xunit.Abstractions;

namespace Performance.Test
{
    public abstract class AbstractRunnerTest
    {
        private readonly ITestOutputHelper _testOutputHelper;
        protected readonly Comparison ComparisonRunner;

        protected AbstractRunnerTest(ITestOutputHelper testOutputHelper, Comparison comparisonRunner)
        {
            _testOutputHelper = testOutputHelper;
            ComparisonRunner = comparisonRunner;
        }

        protected void RunComparison(int numberTests, int numberExecutions)
        {
            for (var test = 0; test < numberTests; test++)
            {
                _testOutputHelper.WriteLine($"**** Test #{test + 1} ****");
                var result = ComparisonRunner.Run(numberExecutions);
                _testOutputHelper.WriteLine(result.GetJournal());
            }
        }
    }
}