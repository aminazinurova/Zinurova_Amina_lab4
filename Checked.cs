using System;
namespace Lab4_Part2
{
    internal class Checked
    {
        // Проверка на int
        public static int ReadInt(string prompt)
        {
            Console.Write(prompt);

            while (true)
            {
                string input = Console.ReadLine();

                if (int.TryParse(input, out int x))
                {
                    return x;
                }

                Console.Write("Ошибка.Введите ещё раз: ");
            }
        }
        public static char ReadChar()
        {
            while (true)
            {
                string s = Console.ReadLine();

                // Строка не пустая И длина ровно 1
                if (s != null && s != "" && s.Length == 1)
                {
                    return s[0];
                }

                Console.Write("Введите один символ: ");
            }
        }
        // Проверка на int с положительностью
        public static int ReadPositiveInt(string prompt)
        {
            Console.Write(prompt);

            while (true)
            {
                string input = Console.ReadLine();

                if (int.TryParse(input, out int x) && x > 0)
                {
                    return x;
                }

                Console.Write("Ошибка.Введите положительное число: ");
            }
        }

        // Проверка на double
        public static double ReadDouble(string prompt)
        {
            Console.Write(prompt);

            while (true)
            {
                string input = Console.ReadLine();

                if (double.TryParse(input, out double x))
                {
                    return x;
                }

                Console.Write("Ошибка.Введите число: ");
            }
        }

        // Проверка на непустую строку
        public static string ReadString(string prompt)
        {
            Console.Write(prompt);

            while (true)
            {
                string input = Console.ReadLine();

                if (input != null && input.Trim() != "")
                {
                    return input.Trim();
                }

                Console.Write("Ошибка.Строка не может быть пустой: ");
            }
        }

        // Проверка на строку с возможностью null (Enter - не задано)
        public static string ReadStringOrNull(string prompt)
        {
            Console.Write(prompt);

            string input = Console.ReadLine();

            if (input == null)
            {
                return null;
            }

            input = input.Trim();

            if (input == "")
            {
                return null;
            }

            return input;
        }
    }
}