using System.Collections.Generic;
using System.Linq;

namespace Performance.Collections
{
    public class OptionListLoopLinq : IComparisonOption
    {
        public string Name => $"Linq to loop over list containing {_numberOfElements} elements";
        private readonly int _numberOfElements;
        private List<MyElement> List { get; }
        private List<MyElement> _filteredList;

        public OptionListLoopLinq(int numberOfElements)
        {
            _numberOfElements = numberOfElements;
            List = new List<MyElement>();
            for (var i = 0; i < _numberOfElements; i++)
            {
                List.Add(new MyElement(i % 7));
            }
        }

        public void Run()
        {
            _filteredList = new List<MyElement>();
            _filteredList.AddRange(List.Where(element => element.Index == 2));
        }
    }
}