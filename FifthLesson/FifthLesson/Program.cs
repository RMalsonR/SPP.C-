using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FifthLesson
{
    public class Student
    {
        //Так объявляется поле класса.
        //Оно не статическое, т.е. не является глобальной переменной.
        public int Age;
        public string FirstName;
        public string LastName;
    }

    class Program
    {
        //мы можем создать массив из Student, потому что Student — это такой же тип, как string или int
        static Student[] students;

        //Этот тип можно использовать в аргументах метода. 
        //Если мы захотим добавить новое поле в Student, не придется переписывать заголовок метода
        static void PrintStudent(Student student)
        {
            Console.WriteLine("{0} {1}", student.FirstName, student.LastName);
        }

        public class RightTriangle
        {
            public double Hypothenuse;
            public double[] Cathetes;

            public static double AngleBetweenCathetes = Math.PI / 2;
        }

        class Point
        {
            public int X;
            public int Y;

            public void Print()
            {
                Console.WriteLine("{0} {1}", X, Y);
            }

            public static void PrintPoint(Point point)
            {
                Console.WriteLine("{0} {1}", point.X, point.Y);
            }
        }

        static class StaticAlgorithm
        {
            static int temporalValue;
            static public int Run(int value)
            {
                var result = 0;
                for (temporalValue = 0; temporalValue <= value; temporalValue++)
                    result += temporalValue;
                return result;
            }
        }

        class Algorithm
        {
            int temporalValue;

            public int Run(int value)
            {
                var result = 0;
                for (temporalValue = 0; temporalValue <= value; temporalValue++)
                    result += temporalValue;
                return result;
            }
        }



        static void Main(string[] args)
        {
            students = new Student[2];

            //Классы — это ссылочные типы, поэтому их нужно инициализировать.
            //Можно сделать собственный тип-значение, но это мы рассмотрим позже.
            students[0] = new Student();
            students[0].FirstName = "John";
            students[0].LastName = "Jones";
            students[0].Age = 19;
            students[1] = new Student();
            students[1].FirstName = "William";
            students[1].LastName = "Williams";
            students[1].Age = 18;
            PrintStudent(students[0]);
            //Можно делать это с помощью сокращенной инициализации — это то же самое
            students = new[]
            {
            new Student { LastName = "Jones", FirstName = "John" },
            new Student { LastName = "Williams", FirstName = "William" }
            };

            // Создание объекта-треугольника.

            // RightTriangle — это тип данных, который определяет, какую информацию
            // и как мы храним в файле о прямоугольном треугольнике

            // firstTriangle — это конкретная область памяти, отформатированная
            // в соответствии с типом RightTriangle
            var firstTriangle = new RightTriangle();
            // Обращение к динамическому полю
            firstTriangle.Hypothenuse = 5;
            firstTriangle.Cathetes = new double[2];
            firstTriangle.Cathetes[0] = 3;
            firstTriangle.Cathetes[1] = 4;

            //Обращение к статическому полю
            Console.WriteLine(RightTriangle.AngleBetweenCathetes);


            var point = new Point { X = 1, Y = 2 };
            point.Print();
            Point.PrintPoint(point);

            StaticAlgorithm.Run(10);

            var algorithm = new Algorithm();
            algorithm.Run(10);
        }
    }

    public class ProgramX
    {
        static double MyNextDouble(Random rnd, double min, double max)
        {
            return rnd.NextDouble() * (max - min) + min;
        }

        static void MainX()
        {
            var rnd = new Random();
            Console.WriteLine(MyNextDouble(rnd, 10, 20));
            Console.WriteLine(rnd.NextDouble(10, 20));
            var array = new int[] { 1, 2, 3, 4, 5 };
            array.Swap(0, 1);
        }
    }

    public static class RandomExtensions
    {
        public static double NextDouble(this Random rnd, double min, double max)
        {
            return rnd.NextDouble() * (max - min) + min;
        }
    }

    public static class ArrayExtensions
    {
        public static void Swap(this int[] array, int i, int j)
        {
            var t = array[i];
            array[i] = array[j];
            array[j] = t;
        }
    }
}
