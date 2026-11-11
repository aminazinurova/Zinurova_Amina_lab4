using System;
namespace Lab4_Part2
{
    public class Point
    {
        private double _x;
        private double _y;
        public double X
        {
            get 
            { 
                return _x;
            
            }
            set
            {
                _x = value; 
            }
        }
        public double Y
        {
            get 
            { 
                return _y; 
            }
            set 
            { 
                _y = value;
            }
        }
        public Point(double x, double y)
        {
            _x = x;
            _y = y;
        }
        public override string ToString()
        {
            return "x = " + _x + ", y = " + _y;
        }
        public double DistanceTo(Point other)
        {
            double dx = _x - other._x;
            double dy = _y - other._y;
            return Math.Sqrt(dx * dx + dy * dy);
        }
        public static Point operator ++(Point p)
        {
            return new Point(p._x + 1, p._y);
        }

        public static Point operator --(Point p)
        {
            return new Point(p._x - 1, p._y);
        }

        public static explicit operator int(Point p)
        {
            return (int)p._x;
        }
        public static implicit operator double(Point p)
        {
            return p._y;
        }

        public static double operator +(Point a, Point b)
        {
            return a.DistanceTo(b);
        }

        public static Point operator +(Point p, int value)
        {
            return new Point(p._x + value, p._y);
        }
        public static Point operator +(int value, Point p)
        {
            return new Point(p._x + value, p._y);
        }
    }
}