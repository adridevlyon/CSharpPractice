using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;

namespace Performance
{
    public abstract class Comparison
    {
        public abstract ComparisonExecutionResult Run(int numberTimes, IEnumerable<int> optionsToRun = null);
    }

    public class Comparison<T> : Comparison
        where T : IComparisonRunner, new()
    {
        private readonly T _comparisonRunner;

        public Comparison()
        {
            _comparisonRunner = new T();
        }

        public override ComparisonExecutionResult Run(int numberTimes, IEnumerable<int> optionsToRun = null)
        {
            var comparisonExecutionResult = new ComparisonExecutionResult(_comparisonRunner.Name, optionsToRun?.ToList(), numberTimes);

            foreach (var option in optionsToRun ?? _comparisonRunner.OptionDictionary.Keys.AsEnumerable())
            {
                if (!_comparisonRunner.OptionDictionary.TryGetValue(option, out var comparisonOption))
                    continue;

                var durationWatch = new Stopwatch();
                durationWatch.Start();
                for (var time = 0; time < numberTimes; time++)
                {
                    comparisonOption.Run();
                }
                durationWatch.Stop();
                comparisonExecutionResult.Results.Add(option, new ComparisonResult(comparisonOption.Name, durationWatch.ElapsedMilliseconds));
            }

            return comparisonExecutionResult;
        }
    }
}