using System;
using System.Collections.Generic;
using Performance.Reflection;
using Enum = System.Enum;

namespace Performance
{
    public class Program
    {
        private static void Main(string[] args)
        {
            Console.WriteLine("***** Topics *****");
            Console.WriteLine($"1. {IsAsRunner.ConstName}");
            Console.WriteLine();

            var option = GetEnteredEnum<TopicOption>("Please pick a topic:", "No available topic selected");
            var numberTests = GetEnteredNumber("How many times to test ?", x => x <= 0, "Please enter an int");
            var numberExecutions = GetEnteredNumber("How many inner executions ?", x => x <= 0, "Please enter an int");

            Comparison comparison = null;
            switch (option)
            {
                case TopicOption.IsAs:
                    comparison = new Comparison<IsAsRunner>();
                    break;
            }
            if (comparison != null)
            {
                for (var test = 0; test < numberTests; test++)
                {
                    Console.WriteLine();
                    Console.WriteLine($"**** Test #{test + 1} ****");
                    comparison.Run(numberExecutions, new List<int> { 1, 2, 3 });
                }
            }

            Console.WriteLine("Press any key to exit...");
            Console.ReadLine();
        }

        private static T GetEnteredEnum<T>(string promptMessage, string errorMessage) where T : struct, IConvertible
        {
            if (!typeof(T).IsEnum)
                throw new ArgumentException("T must be an enumerated type");

            T option;
            var isWrongChoice = false;
            do
            {
                if (isWrongChoice)
                {
                    Console.WriteLine();
                    Console.WriteLine(errorMessage);
                }

                Console.WriteLine(promptMessage);
                isWrongChoice = !Enum.TryParse(Console.ReadLine(), out option) || !Enum.IsDefined(typeof(T), option);
            } while (isWrongChoice);

            return option;
        }

        private static int GetEnteredNumber(string promptMessage, Func<int, bool> validCondition, string errorMessage)
        {
            var isWrongChoice = false;
            int number;
            do
            {
                if (isWrongChoice)
                {
                    Console.WriteLine();
                    Console.WriteLine(errorMessage);
                }

                Console.WriteLine(promptMessage);
                isWrongChoice = !int.TryParse(Console.ReadLine(), out number) || validCondition(number);
            } while (isWrongChoice);

            return number;
        }
    }
}