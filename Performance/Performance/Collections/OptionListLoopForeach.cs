using System.Collections.Generic;

namespace Performance.Collections
{
    public class OptionListLoopForeach : IComparisonOption
    {
        public string Name => $"Foreach to loop over list containing {_numberOfElements} elements";
        private readonly int _numberOfElements;
        private List<MyElement> List { get; }
        private List<MyElement> _filteredList;

        public OptionListLoopForeach(int numberOfElements)
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
            foreach (var element in List)
            {
                if (element.Index == 2)
                    _filteredList.Add(element);
            }
        }
    }
}