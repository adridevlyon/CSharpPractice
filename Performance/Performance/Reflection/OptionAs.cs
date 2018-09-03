namespace Performance.Reflection
{
    public class OptionAs : IComparisonOption
    {
        public string Name => "Cast as and check null";
        public MyCastingType Casted { get; private set; }

        public void Run()
        {
            Casted = DoCast(new object());
            Casted = DoCast(new MyCastingType());
        }

        private MyCastingType DoCast(object myObject)
        {
            return myObject as MyCastingType;
        }
    }
}