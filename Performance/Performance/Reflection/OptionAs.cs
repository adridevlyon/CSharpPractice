namespace Performance.Reflection
{
    public class OptionAs : IComparisonOption
    {
        public string Name => "Cast as and check null";

        public void Run()
        {
            DoCast(new object());
            DoCast(new MyCastingType());
        }

        private MyCastingType DoCast(object myObject)
        {
            return myObject as MyCastingType;
        }
    }
}