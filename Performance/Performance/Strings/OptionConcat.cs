using System.Collections.Generic;

namespace Performance.Strings
{
    public class OptionConcat : IComparisonOption
    {
        public string Name => $"String concatenation containing {_numberOfElements} elements";
        private readonly int _numberOfElements;
        private List<string> StringList { get; }

        public OptionConcat(int numberOfElements)
        {
            _numberOfElements = numberOfElements;
            StringList = new List<string>();
            for (var i = 0; i < _numberOfElements; i++)
            {
                StringList.Add($"myString{i}");
            }
        }

        public void Run()
        {
            var concat = "";

            foreach (var str in StringList)
            {
                concat += str;
            }
        }
    }
}