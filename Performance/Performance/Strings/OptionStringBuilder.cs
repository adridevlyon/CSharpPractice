using System.Collections.Generic;
using System.Text;

namespace Performance.Strings
{
    public class OptionStringBuilder : IComparisonOption
    {
        public string Name => $"String builder containing {_numberOfElements} elements";
        private readonly int _numberOfElements;
        public List<string> StringList { get; }

        public OptionStringBuilder(int numberOfElements)
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
            var concatBuilder = new StringBuilder();

            foreach (var str in StringList)
            {
                concatBuilder.Append(str);
            }

            var concat = concatBuilder.ToString();
        }
    }
}