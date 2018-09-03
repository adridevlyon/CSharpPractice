namespace Performance.Reflection
{
    public class OptionIsPatternMatching : IComparisonOption
    {
        public string Name => "Use is with pattern matching";
        public MyCastingType Casted { get; private set; }

        public void Run()
        {
            Casted = DoCast(new object());
            Casted = DoCast(new MyCastingType());
        }

        private MyCastingType DoCast(object myObject)
        {
            return myObject is MyCastingType casted ? casted : null;
        }
    }
}