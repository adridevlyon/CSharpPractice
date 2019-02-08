using System.Collections.Generic;

namespace Performance.Collections
{
    public class OptionListAdd : IComparisonOption
    {
        public string Name => $"List containing {_numberOfElements} elements";
        private readonly int _numberOfElements;
        private List<MyElement> List { get; }

        public OptionListAdd(int numberOfElements)
        {
            _numberOfElements = numberOfElements;
            List = new List<MyElement>();
        }

        public void Run()
        {
            for (var i = 0; i < _numberOfElements; i++)
            {
                List.Add(new MyElement(i));
            }
        }
    }
}