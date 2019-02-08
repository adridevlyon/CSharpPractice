using Performance.Reflection;
using Xunit;
using Xunit.Abstractions;

namespace Performance.Test.Reflection
{
    public class IsAsRunnerTest : AbstractRunnerTest
    {
        public IsAsRunnerTest(ITestOutputHelper testOutputHelper) : base(testOutputHelper, new Comparison<IsAsRunner>())
        {
        }

        [Fact]
        public void ExecuteComparison()
        {
            RunComparison(3, 10000000);
        }
    }
}