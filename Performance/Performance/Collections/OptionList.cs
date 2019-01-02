using System.Collections.Generic;

namespace Performance.Collections
{
    public class OptionList : IComparisonOption
    {
        public string Name => $"List containing {_numberOfElements} elements";
        private readonly int _numberOfElements;
        private List<MyElement> List { get; }
        private readonly MyElement _lastElement;

        public OptionList(int numberOfElements)
        {
            _numberOfElements = numberOfElements;
            List = new List<MyElement>();
            for (var i = 0; i < _numberOfElements; i++)
            {
                var element = new MyElement(i);
                List.Add(element);
                _lastElement = element;
            }
        }

        public void Run()
        {
            var found = List.Contains(_lastElement);
            var notFound = List.Contains(new MyElement(_numberOfElements + 5));
        }
    }
}