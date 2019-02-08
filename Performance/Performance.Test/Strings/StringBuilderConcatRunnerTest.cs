using Performance.Strings;
using Xunit;
using Xunit.Abstractions;

namespace Performance.Test.Strings
{
    public class StringBuilderConcatRunnerTest : AbstractRunnerTest
    {
        public StringBuilderConcatRunnerTest(ITestOutputHelper testOutputHelper) : base(testOutputHelper, new Comparison<StringBuilderConcatRunner>())
        {
        }

        [Fact]
        public void ExecuteComparison()
        {
            RunComparison(3, 100000);
        }
    }
}