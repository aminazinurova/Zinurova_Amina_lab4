using System;
namespace Lab4_Part2
{
    internal class Program
    {
        private static void Main(string[] args)
        {
            Console.WriteLine("Задания 6 и 7. Класс Point");
            Console.WriteLine("\nВвод первой точки:");
            double x1 = Checked.ReadDouble("Введите координату X1: ");
            double y1 = Checked.ReadDouble("Введите координату Y1: ");
            Point p1 = new Point(x1, y1);
            Console.WriteLine("\nВвод второй точки:");
            double x2 = Checked.ReadDouble("Введите координату X2: ");
            double y2 = Checked.ReadDouble("Введите координату Y2: ");
            Point p2 = new Point(x2, y2);
            Console.WriteLine("\nВы ввели:");
            Console.WriteLine("Точка 1: " + p1);
            Console.WriteLine("Точка 2: " + p2);
            double distance = p1.DistanceTo(p2);
            Console.WriteLine("\nРасстояние (метод DistanceTo): " + distance);
            double distOp = p1 + p2;
            Console.WriteLine("Расстояние (оператор +): " + distOp);
            Console.WriteLine("\nТестирование ++ и -- для Точки 1:");
            Console.WriteLine("До ++: " + p1);
            p1++;
            Console.WriteLine("После ++: " + p1);
            p1--;
            Console.WriteLine("После --: " + p1);
            int shift = Checked.ReadInt("\nВведите целое число для сдвига по X: ");
            Point shiftedRight = p1 + shift;
            Point shiftedLeft = shift + p1;
            Console.WriteLine("p1 + shift: " + shiftedRight);
            Console.WriteLine("shift + p1: " + shiftedLeft);
            int intX = (int)p1;
            Console.WriteLine("\n(int)p1 (целая часть X): " + intX);
            double doubleY = p2;
            Console.WriteLine("(double)p2 (координата Y): " + doubleY);
            Console.ReadLine();
        }
    }
}