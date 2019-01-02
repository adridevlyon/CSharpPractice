using System.Text.RegularExpressions;

namespace Performance.Strings
{
    public class OptionCompiledRegex : IComparisonOption
    {
        public string Name => "Compiled regex";
        private readonly Regex _regex = new Regex("([A-z0-9])[A-z0-9]*", RegexOptions.Compiled);

        public void Run()
        {
            _regex.Replace("Je suis 1 texte (avec quelques caractères <'spéciaux'> !", "$1");
        }
    }
}