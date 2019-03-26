using Performance.Collections;
using Xunit;
using Xunit.Abstractions;

namespace Performance.Test.Collections
{
    public class ListLoopOverRunnerTest : AbstractRunnerTest
    {
        public ListLoopOverRunnerTest(ITestOutputHelper testOutputHelper) : base(testOutputHelper, new Comparison<ListLoopOverRunner>())
        {
        }

        [Fact]
        public void ExecuteComparison()
        {
            RunComparison(3, 100000);
        }
    }
}