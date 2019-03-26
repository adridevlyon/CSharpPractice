namespace Performance.Collections
{
    public class MyElement
    {
        public int Index { get; }
        private string Name1 { get; }
        private string Name2 { get; }
        private string Name3 { get; }
        private string Name4 { get; }
        private string Name5 { get; }

        public MyElement(int index)
        {
            Index = index;
            Name1 = $"{index}";
            Name2 = $"{index}";
            Name3 = $"{index}";
            Name4 = $"{index}";
            Name5 = $"{index}";
        }
    }
}