using System.Text.RegularExpressions;

namespace Performance.Strings
{
    public class OptionRegex : IComparisonOption
    {
        public string Name => "Static regex";

        public void Run()
        {
            Regex.Replace("Je suis 1 texte (avec quelques caractères <'spéciaux'> !", "([A-z0-9])[A-z0-9]*", "$1");
        }
    }
}