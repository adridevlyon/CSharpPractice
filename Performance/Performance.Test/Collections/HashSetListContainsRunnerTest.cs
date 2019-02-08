using Performance.Collections;
using Xunit;
using Xunit.Abstractions;

namespace Performance.Test.Collections
{
    public class HashSetListContainsRunnerTest : AbstractRunnerTest
    {
        public HashSetListContainsRunnerTest(ITestOutputHelper testOutputHelper) : base(testOutputHelper, new Comparison<HashSetListContainsRunner>())
        {
        }

        [Fact]
        public void ExecuteComparison()
        {
            RunComparison(3, 100000);
        }
    }
}