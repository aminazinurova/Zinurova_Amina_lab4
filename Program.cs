using System;
using System.Collections.Generic;
namespace Lab4
{
    internal class Program
    {
        private static void Main(string[] args)
        {
            Console.WriteLine("Задание 1.3");
            int sizeL1 = Checked.ReadPositiveInt
                ("Введите количество элементов в списке L1: ");
            List<int> L1 = new List<int>();
            Console.WriteLine
                ("Введите элементы списка L1 (по возрастанию):");
            int i; 
            for (i = 0; i < sizeL1; i++)
            {
                L1.Add(Checked.ReadInt($"Элемент L1 [{i}]: "));
            }
            int sizeL2 = Checked.ReadPositiveInt
                ("\nВведите количество элементов в списке L2: ");
            List<int> L2 = new List<int>();
            Console.WriteLine
                ("Введите элементы списка L2 (по возрастанию):");
            for (i = 0; i < sizeL2; i++)
            {
                L2.Add(Checked.ReadInt($"Элемент L2 [{i}]: "));
            }
            Console.WriteLine("\nСписок L1: " + string.Join(", ", L1));
            Console.WriteLine("Список L2: " + string.Join(", ", L2));
            List<int> result = CollectionTasks.Task1_3(L1, L2);
            Console.WriteLine
                ("\nРезультат объединения (без нарушения упорядоченности):");
            Console.WriteLine(string.Join(", ", result));
            Console.ReadLine();

            Console.WriteLine("\nЗадание 2.3");
            int sizeList = Checked.ReadPositiveInt("Введите количество элементов в списке: ");
            LinkedList<int> list23 = new LinkedList<int>();
            Console.WriteLine("Введите элементы списка:");
            for (i = 0; i < sizeList; i++)
            {
                list23.AddLast(Checked.ReadInt($"Элемент [{i}]: "));
            }
            Console.Write("\nВаш список: ");
            foreach (int item in list23)
            {
                Console.Write(item + " ");
            }
            Console.WriteLine();
            int result2 = CollectionTasks.Task2_3(list23);
            Console.WriteLine($"Количество элементов с равными соседями: {result2}");

            Console.WriteLine("\nЗадание 3.3");
            int dishCount = Checked.ReadPositiveInt("Сколько всего блюд в меню кафе? ");
            HashSet<string> allDishes = new HashSet<string>();

            Console.WriteLine("Введите названия блюд (через Enter):");
            for (i = 0; i < dishCount; i++)
            {
                allDishes.Add(Checked.ReadString($"Блюдо [{i + 1}]: "));
            }
            int visitorsCount = Checked.ReadPositiveInt("\nСколько посетителей было в кафе? ");
            List<HashSet<string>> orders = new List<HashSet<string>>();
            int j; 
            for (j = 0; j < visitorsCount; j++)
            {
                Console.WriteLine($"\nЗаказ посетителя №{j + 1}:");
                int itemsCount = Checked.ReadPositiveInt("Сколько блюд он заказал? ");
                HashSet<string> currentOrder = new HashSet<string>();
                int k; 
                for (k = 0; k < itemsCount; k++)
                {
                    string dish = Checked.ReadString($"Блюдо [{k + 1}]: ");
                    if (!allDishes.Contains(dish))
                    {
                        Console.WriteLine("Внимание: такого блюда нет в меню, но мы его добавим в общий список.");
                        allDishes.Add(dish);
                    }
                    currentOrder.Add(dish);
                }
                orders.Add(currentOrder);
            }
            List<HashSet<string>> results33 = CollectionTasks.Task3_3(orders, allDishes);
            Console.WriteLine("\nРезультаты анализа заказов");
            Console.WriteLine("Заказывали все: " + string.Join(", ", results33[0]));
            Console.WriteLine("Заказывали некоторые: " + string.Join(", ", results33[1]));
            Console.WriteLine("Не заказывал никто: " + string.Join(", ", results33[2]));

            Console.WriteLine("\nЗадание 4.3");
            string filePath4 = Checked.ReadString("Введите путь к файлу с текстом (например, text4.txt): ");
            if (!File.Exists(filePath4))
            {
                Console.WriteLine("Файл не найден. Создаю тестовый файл...");
                File.WriteAllText(filePath4, "Тестовый текст");
            }
            List<char> result4 = CollectionTasks.Task4_3(filePath4);
            Console.WriteLine("Согласные, входящие ровно в одно слово: " + string.Join(", ", result4));

            Console.WriteLine("\nЗадание 5.3");
            string filePath5 = "sport.txt";
            CollectionTasks.FillSportFile(filePath5);
            CollectionTasks.Task5_3(filePath5);
        }
    }
}