using System;
using System.Collections.Generic;
namespace Lab4
{
    internal class CollectionTasks
    {
        //ЗАДАНИЕ 1.3
        public static List<int> Task1_3(List<int> L1, List<int> L2)
        {
            List<int> result = new List<int>(L1);
            result.Sort();
            List<int> sortedL2 = new List<int>(L2);
            sortedL2.Sort();
            int i;
            int j;
            bool inserted;
            for (i = 0; i < sortedL2.Count; i++)
            {
                inserted = false;
                for (j = 0; j < result.Count; j++)
                {
                    if (sortedL2[i] < result[j])
                    {
                        result.Insert(j, sortedL2[i]);
                        inserted = true;
                        break;
                    }
                }
                if (!inserted)
                {
                    result.Add(sortedL2[i]);
                }
            }
            return result;
        }
        //ЗАДАНИЕ 2.3
        public static int Task2_3(LinkedList<int> list)
        {
            if (list.Count < 3)
            {
                return 0;
            }
            int count = 0; 
            LinkedListNode<int> current = list.First.Next;
            while (current != null && current.Next != null)
            {
                if (current.Previous.Value == current.Next.Value)
                {
                    count++; 
                }
                current = current.Next;
            }
            return count;
        }
        //ЗАДАНИЕ 3.3
        public static List<HashSet<string>> Task3_3(List<HashSet<string>> orders, HashSet<string> allDishes)
        {
            List<HashSet<string>> results = new List<HashSet<string>>();

            if (orders.Count == 0)
            {
                results.Add(new HashSet<string>());
                results.Add(new HashSet<string>());
                results.Add(new HashSet<string>(allDishes));
                return results;
            }
            HashSet<string> orderedByAll = new HashSet<string>(orders[0]);
            int i;
            for (i = 1; i < orders.Count; i++)
            {
                orderedByAll.IntersectWith(orders[i]);
            }
            results.Add(orderedByAll);
            HashSet<string> orderedByAnyone = new HashSet<string>();
            for (i = 0; i < orders.Count; i++)
            {
                orderedByAnyone.UnionWith(orders[i]);
            }
            HashSet<string> orderedBySome = new HashSet<string>(orderedByAnyone);
            orderedBySome.ExceptWith(orderedByAll);
            results.Add(orderedBySome);
            HashSet<string> orderedByNoOne = new HashSet<string>(allDishes);
            orderedByNoOne.ExceptWith(orderedByAnyone);
            results.Add(orderedByNoOne);
            return results;
        }
            //ЗАДАНИЕ 4.3
            public static List<char> Task4_3(string filePath)
            {
                if (!File.Exists(filePath))
                {
                    Console.WriteLine("Ошибка: Файл не найден!");
                    return new List<char>();
                }
                string consonants = "бвгджзйклмнпрстфхцчшщ";
                HashSet<char> inOneWord = new HashSet<char>();
                HashSet<char> inManyWords = new HashSet<char>();
                string line;
                using (StreamReader reader = new StreamReader(filePath))
                {
                    while ((line = reader.ReadLine()) != null)
                    {
                        string[] words = line.Split(new char[] { ' ', ',', '.', '!', '?', ';', ':' }, StringSplitOptions.RemoveEmptyEntries);
                        int i;
                        int j;
                        foreach (string word in words)
                        {
                            HashSet<char> currentWordLetters = new HashSet<char>();
                            for (i = 0; i < word.Length; i++)
                            {
                                char c = char.ToLower(word[i]);
                                if (consonants.Contains(c))
                                {
                                    currentWordLetters.Add(c);
                                }
                            }
                            foreach (char c in currentWordLetters)
                            {
                                if (inOneWord.Contains(c))
                                {
                                    inOneWord.Remove(c);
                                    inManyWords.Add(c);
                                }
                                else if (!inManyWords.Contains(c))
                                {
                                    inOneWord.Add(c);
                                }
                            }
                        }
                    }
                }
                List<char> result = new List<char>(inOneWord);
                result.Sort();
                return result;
            }
        //ЗАДАНИЕ 5.3 (Заполнение файла)
        public static void FillSportFile(string filePath)
        {
            int n = Checked.ReadPositiveInt("Введите количество участников (N): ");

            using (StreamWriter writer = new StreamWriter(filePath))
            {
                int i;
                for (i = 0; i < n; i++)
                {
                    Console.WriteLine($"\nУчастник №{i + 1}:");

                    string surname = Checked.ReadString("Введите фамилию: ");
                    string name = Checked.ReadString("Введите имя: ");
                    int score1 = Checked.ReadInt("Балл за 1-й вид спорта (0-10): ");
                    int score2 = Checked.ReadInt("Балл за 2-й вид спорта (0-10): ");
                    int score3 = Checked.ReadInt("Балл за 3-й вид спорта (0-10): ");
                    int score4 = Checked.ReadInt("Балл за 4-й вид спорта (0-10): ");
                    writer.WriteLine($"{surname} {name} {score1} {score2} {score3} {score4}");
                }
            }
            Console.WriteLine($"\nДанные записаны в файл {filePath}");
        }
        //ЗАДАНИЕ 5.3 (Решение)
        public static void Task5_3(string filePath)
        {
            if (!File.Exists(filePath))
            {
                Console.WriteLine("Ошибка: Файл не найден!");
                return;
            }
            SortedList<int, List<string>> results = new SortedList<int, List<string>>();
            string line;
            using (StreamReader reader = new StreamReader(filePath))
            {
                while ((line = reader.ReadLine()) != null)
                {
                    string[] parts = line.Split(new char[] { ' ' }, StringSplitOptions.RemoveEmptyEntries);
                    if (parts.Length < 6) continue;

                    string fullName = parts[0] + " " + parts[1];

                    int total = int.Parse(parts[2]) + int.Parse(parts[3]) +
                                int.Parse(parts[4]) + int.Parse(parts[5]);
                    if (!results.ContainsKey(total))
                    {
                        results.Add(total, new List<string>());
                    }
                    results[total].Add(fullName);
                }
            }
            Console.WriteLine("\nТри лучших участника многоборья:");
            int places = 0;
            int thirdPlaceScore = -1;
            int i;
            for (i = results.Count - 1; i >= 0; i--)
            {
                List<string> names = results.Values[i];
                int currentScore = results.Keys[i]; 
                if (places >= 3 && currentScore < thirdPlaceScore)
                {
                    break;
                }
                foreach (string name in names)
                {
                    Console.WriteLine(name + " - " + currentScore + " баллов");
                    places++;
                }
                if (places >= 3 && thirdPlaceScore == -1)
                {
                    thirdPlaceScore = currentScore;
                }
            }
        }
    }

}

