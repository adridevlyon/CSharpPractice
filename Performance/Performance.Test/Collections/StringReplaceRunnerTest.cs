using Performance.Strings;
using Xunit;
using Xunit.Abstractions;

namespace Performance.Test.Collections
{
    public class StringReplaceRunnerTest : AbstractRunnerTest
    {
        public StringReplaceRunnerTest(ITestOutputHelper testOutputHelper) : base(testOutputHelper, new Comparison<StringReplaceRunner>())
        {
        }

        [Fact]
        public void ExecuteComparison()
        {
            RunComparison(3, 100000);
        }
    }
}