using System;
using Performance.Collections;
using Performance.Reflection;
using Performance.Strings;
using Enum = System.Enum;

namespace Performance
{
    public class Program
    {
        private static void Main(string[] args)
        {
            Console.WriteLine("***** Topics *****");
            Console.WriteLine("0. Exit");
            Console.WriteLine($"1. {IsAsRunner.ConstName}");
            Console.WriteLine($"2. {HashSetListContainsRunner.ConstName}");
            Console.WriteLine($"3. {StringBuilderConcatRunner.ConstName}");
            Console.WriteLine();

            var option = GetEnteredEnum<TopicOption>("Please pick a topic:", "No available topic selected");

            Comparison comparison = null;
            switch (option)
            {
                case TopicOption.None:
                    return;
                case TopicOption.IsAs:
                    comparison = new Comparison<IsAsRunner>();
                    break;
                case TopicOption.HashSetListContains:
                    comparison = new Comparison<HashSetListContainsRunner>();
                    break;
                case TopicOption.StringBuilderConcat:
                    comparison = new Comparison<StringBuilderConcatRunner>();
                    break;
            }
            if (comparison != null)
            {
                var numberTests = GetEnteredNumber("How many times to test ?", x => x <= 0, "Please enter an int");
                var numberExecutions = GetEnteredNumber("How many inner executions ?", x => x <= 0, "Please enter an int");

                for (var test = 0; test < numberTests; test++)
                {
                    Console.WriteLine();
                    Console.WriteLine($"**** Test #{test + 1} ****");
                    comparison.Run(numberExecutions);
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