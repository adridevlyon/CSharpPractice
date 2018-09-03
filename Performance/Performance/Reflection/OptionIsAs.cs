namespace Performance.Reflection
{
    public class OptionIsAs : IComparisonOption
    {
        public string Name => "Use is and cast with as if needed";
        public MyCastingType Casted { get; private set; }

        public void Run()
        {
            Casted = DoCast(new object());
            Casted = DoCast(new MyCastingType());
        }

        private MyCastingType DoCast(object myObject)
        {
            var isCastable = myObject is MyCastingType;
            if (isCastable)
            {
                return myObject as MyCastingType;
            }

            return null;
        }
    }
}