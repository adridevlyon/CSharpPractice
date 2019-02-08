using Performance.Collections;
using Xunit;
using Xunit.Abstractions;

namespace Performance.Test.Collections
{
    public class ListArrayAddRunnerTest : AbstractRunnerTest
    {
        public ListArrayAddRunnerTest(ITestOutputHelper testOutputHelper) : base(testOutputHelper, new Comparison<ListArrayAddRunner>())
        {
        }

        [Fact]
        public void ExecuteComparison()
        {
            RunComparison(3, 1000);
        }
    }
}