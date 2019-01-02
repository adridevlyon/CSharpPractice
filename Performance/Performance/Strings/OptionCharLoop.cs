using System.Collections.Generic;

namespace Performance.Strings
{
    public class OptionCharLoop : IComparisonOption
    {
        public string Name => "Char loop";
        private readonly HashSet<char> _charsToRemove = new HashSet<char>
        {
            'a', 'b', 'c', 'd', 'e', 'f', 'g', 'h', 'i', 'j', 'k', 'l', 'm', 'n', 'o', 'p', 'q', 'r', 's', 't', 'u', 'v', 'w', 'x', 'y', 'z',
            'A', 'B', 'C', 'D', 'E', 'F', 'G', 'H', 'I', 'J', 'K', 'L', 'M', 'N', 'O', 'P', 'Q', 'R', 'S', 'T', 'U', 'V', 'W', 'X', 'Y', 'Z',
            '0', '1', '2', '3', '4', '5', '6', '7', '8', '9'
        };

        public void Run()
        {
            var input = "Je suis 1 texte (avec quelques caractères <'spéciaux'> !";
            var outputChars = new char[input.Length];
            var indexCounter = 0;
            var isInsideGroup = false;
            var isFirstCharOfGroup = true;
            var firstCharOfGroup = 'a';

            foreach (var c in input)
            {
                if (_charsToRemove.Contains(c))
                {
                    if (isFirstCharOfGroup)
                    {
                        isFirstCharOfGroup = false;
                        firstCharOfGroup = c;
                        isInsideGroup = true;
                    }
                }
                else
                {
                    if (isInsideGroup)
                    {
                        isInsideGroup = false;
                        outputChars[indexCounter++] = firstCharOfGroup;
                        isFirstCharOfGroup = true;
                    }
                    outputChars[indexCounter++] = c;
                }
            }

            new string(outputChars, 0, indexCounter);
        }
    }
}