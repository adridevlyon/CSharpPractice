namespace Performance.Collections
{
    public class OptionArrayAdd : IComparisonOption
    {
        public string Name => $"Array containing {_numberOfElements} elements";
        private readonly int _numberOfElements;
        private MyElement[] Array { get; }

        public OptionArrayAdd(int numberOfElements)
        {
            _numberOfElements = numberOfElements;
            Array = new MyElement[numberOfElements];
        }

        public void Run()
        {
            for (var i = 0; i < _numberOfElements; i++)
            {
                Array[i] = new MyElement(i);
            }
        }
    }
}