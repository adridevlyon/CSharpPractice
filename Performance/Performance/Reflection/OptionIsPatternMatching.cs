namespace Performance.Reflection
{
    public class OptionIsPatternMatching : IComparisonOption
    {
        public string Name => "Use is with pattern matching";

        public void Run()
        {
            DoCast(new object());
            DoCast(new MyCastingType());
        }

        private MyCastingType DoCast(object myObject)
        {
            return myObject is MyCastingType casted ? casted : null;
        }
    }
}