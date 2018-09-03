using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;

namespace Performance
{
    public abstract class Comparison
    {
        public abstract void Run(int numberTimes, IEnumerable<int> optionsToRun = null);
    }

    public class Comparison<T> : Comparison
        where T : IComparisonRunner
    {
        private readonly T _comparisonRunner;

        public Comparison()
        {
            _comparisonRunner = Activator.CreateInstance<T>();
        }

        public override void Run(int numberTimes, IEnumerable<int> optionsToRun = null)
        {
            Console.WriteLine();
            var optionsText = optionsToRun == null ? "all options" : $"options : {string.Join(" vs ", optionsToRun)}";
            Console.WriteLine($"*** Run comparison {_comparisonRunner.Name} with {optionsText} and {numberTimes} executions ***");

            foreach (var option in optionsToRun ?? _comparisonRunner.OptionDictionary.Keys.AsEnumerable())
            {
                Console.WriteLine();
                Console.WriteLine($"** Option {option} **");
                if (!_comparisonRunner.OptionDictionary.TryGetValue(option, out var comparisonOption))
                {
                    Console.WriteLine("/!\\ This option does not exist /!\\");
                    continue;
                }

                Console.WriteLine($"Name : {comparisonOption.Name}");
                var durationWatch = new Stopwatch();
                durationWatch.Start();
                for (var time = 0; time < numberTimes; time++)
                {
                    comparisonOption.Run();
                }
                durationWatch.Stop();
                Console.WriteLine($"Elapsed time for {numberTimes} executions : {durationWatch.ElapsedMilliseconds} ms");
            }

            Console.WriteLine();
            Console.WriteLine("*** End of comparison ***");
        }
    }
}