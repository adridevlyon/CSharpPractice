using System.Collections.Generic;

namespace Performance.Collections
{
    public class OptionListWithCapacityAdd : IComparisonOption
    {
        public string Name => $"List containing {_numberOfElements} elements with pre-defined capacity";
        private readonly int _numberOfElements;
        private List<MyElement> List { get; }

        public OptionListWithCapacityAdd(int numberOfElements)
        {
            _numberOfElements = numberOfElements;
            List = new List<MyElement>(numberOfElements);
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