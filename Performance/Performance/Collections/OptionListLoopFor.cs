using System.Collections.Generic;

namespace Performance.Collections
{
    public class OptionListLoopFor : IComparisonOption
    {
        public string Name => $"For to loop over list containing {_numberOfElements} elements";
        private readonly int _numberOfElements;
        private List<MyElement> List { get; }
        private List<MyElement> _filteredList;

        public OptionListLoopFor(int numberOfElements)
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
            for (var i = 0; i < _numberOfElements; i++)
            {
                var element = List[i];
                if (element.Index == 2)
                    _filteredList.Add(element);
            }
        }
    }
}