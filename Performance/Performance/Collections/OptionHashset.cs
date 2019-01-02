using System.Collections.Generic;

namespace Performance.Collections
{
    public class OptionHashset : IComparisonOption
    {
        public string Name => $"Hashset containing {_numberOfElements} elements";
        private readonly int _numberOfElements;
        private HashSet<MyElement> HashSet { get; }
        private readonly MyElement _lastElement;

        public OptionHashset(int numberOfElements)
        {
            _numberOfElements = numberOfElements;
            HashSet = new HashSet<MyElement>();
            for (var i = 0; i < _numberOfElements; i++)
            {
                var element = new MyElement(i);
                HashSet.Add(element);
                _lastElement = element;
            }
        }

        public void Run()
        {
            var found = HashSet.Contains(_lastElement);
            var notFound = HashSet.Contains(new MyElement(_numberOfElements + 5));
        }
    }
}