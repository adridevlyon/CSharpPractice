namespace Performance.Reflection
{
    public class OptionIsCast : IComparisonOption
    {
        public string Name => "Use is and direct cast if needed";
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
                return (MyCastingType)myObject;
            }

            return null;
        }
    }
}