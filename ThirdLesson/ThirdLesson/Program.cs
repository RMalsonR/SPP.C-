using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ThirdLesson
{
    public enum Color
    {
        Red,
        Green,
        Blue
    }

    class Program
    {
        static string GetColorNameWrongWay(Color color)
        {
            if (color == Color.Red) return "Красный";
            if (color == Color.Blue) return "Синий";
            if (color == Color.Green) return "Зеленый";

            return "";
            /* 
            компилятор не знает, что это взаимоисключающие возможности!
            Если закомментировать предыдущую строку, то будет ошибка 
            "not all code paths return a value".
            Т.е. существуют некоторые ветви алгоритма, которые не возвращают значения. 
            Но метод должен вернуть значение в любом случае, поэтому это - ошибка. 
            */
        }

        static string GetColorNameGoodWay(Color color)
        {
            if (color == Color.Red) return "Красный";
            if (color == Color.Blue) return "Синий";
            if (color == Color.Green) return "Зеленый";
            throw new Exception("Unknown color " + color);
            /* 
            В большинстве случаев писать нужно именно так.
            Если появится новый цвет, то "магическая" строка throw new Exception
            сгенерирует исключительную ситуацию, которая прервет работу программы.

            Обычно падение программы в таком случае лучше, чем некорректная работа.
                (Лучше вообще не стрелять, чем стрелять не туда)
            */
        }

        // Если совершенно точно известно, что новые цвета появляться не будут, можно писать так:
        static string GetColorName(Color color)
        {
            if (color == Color.Red) return "Красный";
            else if (color == Color.Blue) return "Синий";
            else return "Зеленый";
        }

        //Часто встречающиеся стилевые ошибки

        //Допустим, вы решили написать метод, возвращающий отрицание переменной
        static bool Negate(bool argument)
        {
            return !argument;
            // так правильно

            /*
             * if (argument) return false;
             * else return true;
             * - а так - нет.
             */
        }

        //Или метод, сравнивающий два значения
        static bool LessThan(int arg1, int arg2)
        {
            return arg1 < arg2;
            //так правильно

            /*
             * if (arg1<arg2) return true;
             * else return false;
             * - а так - нет
             */
        }
        static void Main(string[] args)
        {
            //Сравнение, как сложение или деление, тоже имеет возвращаемое значение
            Console.WriteLine(5 < 4);

            // И его можно сохранить в переменную логического типа
            // Это тип, абсолютно равноправный с int, double и другими 
            bool comparisonResult = 6 > 7;
            Console.WriteLine(comparisonResult);

            //Константы истины и лжи
            bool trueValue = true;
            bool falseValue = false;

            //Все операции сравнения
            Console.WriteLine(5 == 6);
            Console.WriteLine(5 != 6);
            Console.WriteLine(5 < 5);
            Console.WriteLine(5 <= 5);
            Console.WriteLine(5 > 5);
            Console.WriteLine(5 >= 5);

            // Операция "И", или конъюнкция
            Console.WriteLine((5 < 4) && (3 < 4));

            // Операция "ИЛИ", или дизъюнкция
            Console.WriteLine((5 < 4) || (3 < 4));

            // Операция "НЕ", или отрицание
            Console.WriteLine(!(5 < 4));

            var a = int.Parse(Console.ReadLine());

            if (a == 0) Console.WriteLine("A is zero");
            // если действие if состоит из одного оператора, его можно писать без фигурных скобок

            if (a == 1)
            {
                //В противном случае нужно обнести нужные операторы скобками
                Console.Write("Let me think... ");
                Console.WriteLine("A is one!");
            }

            if (a % 2 == 0) Console.WriteLine("A is even"); // тут ошибка на видео: перепутаны odd и even
            else Console.WriteLine("A is odd");

            if (a < 0) Console.WriteLine("A is negative");
            else if (a < 10) Console.WriteLine("A consists of one digit");
            else
            {
                var num = a.ToString().Length;
                Console.WriteLine("The number of digits in A is {0}", num);
                if (a > 1000)
                    Console.Write("A is enormous!");
            }

            //ЦИКЛЫ

            int number = 1;
            while (number < 100)            // пока выполняются условия
            {
                number *= 2;                // делай инструкции в теле цикла
                Console.WriteLine(number);
            }

            int sum = 0;
            while (true)
            {
                var line = Console.ReadLine();
                if (line == "") break;
                if (line.Length > 100) continue; //запросить следующую линию
                sum += int.Parse(line);
            }

            var sum = 0;
            while (true)
            {
                bool stop = false;
                while (true)
                {
                    sum += int.Parse(Console.ReadLine());
                    if (sum > 100)
                    {
                        stop = true;
                        break; //этот break выходит только из внутреннего цикла
                    }
                }
                if (stop)
                {
                    break; //этот break выходит из внешнего цикла по флагу stop
                }
            }


            //Суммируем все числа от 1 до 10
            var sum = 0;
            for (int i = 1; i <= 10; i++)
                sum += i;

            // Чтобы сделать что-то N раз, мы делаем цикл от 0 до N. 
            // В C# принято в таких случаях делать цикл именно от 0 до i<N, 
            // а не от 1 до i<=N, например.
            for (int i = 0; i < 10; i++)
                Console.WriteLine(i);

            // Выводим все символы строки
            string str = "abc";
            for (int i = 0; i < str.Length; i++)
                Console.Write(str[i]);

            //Декремент
            for (int i = 9; i >= 0; i--)
                Console.Write(i + " ");

            Console.WriteLine();
            //Допускается произвольное изменение переменной
            for (int i = 1; i < 100; i *= 2)
                Console.Write(i + " ");

            Console.WriteLine();
            //Не обязательно инициализировать переменную
            int start = int.Parse(Console.ReadLine());
            for (; start >= 0; start--)
                Console.Write(start + " ");

            Console.WriteLine();
            //И условие тоже может быть произвольным
            for (; start * start < 5 * start; start++)
                Console.Write(start + " ");

            Console.WriteLine();

            //Проверка условия осуществляется КАЖДУЮ итерацию цикла! 
            //Поэтому в данном случае лучше ввести переменную var bound=GetBound() 
            //и сравнивать с ней, а не вызывать цикл каждый раз
            for (int i = 0; i < GetBound(); i++)
                Console.Write(i + " ");
            for (;;) // «Ктулху-фор» — вечный цикл
            {
                break;
            }

            // МАССИВЫ
            //Объявляем переменную array, точно так же, как раньше объявляли переменные других типов.
            //Тип массива чисел - это int[]. Аналогично, есть типы string[], double[], и т.д.
            int[] array;
            int number;

            //Инициализируем переменную array значением "new int[3]" - новый массив длины 3. 
            array = new int[3];
            number = 10;

            //Обращение к элементам массива
            array[0] = 1;
            array[1] = 2;
            array[2] = 3;

            //Массив, как и остальные типы, имеет собственные свойства и методы
            Console.WriteLine(array.Length); //Выведет 3

            //Обратите внимание, что array.ToString() работает не так, как хотелось бы.
            Console.WriteLine(array.ToString()); //Выведет System.Int32[]

            //Этот код вызовет exception - выход за границы массива
            Console.WriteLine(array[100]);

            var array2 = new[] { 1, 2, 3 };

            //Элементы массива можно пробежать так
            for (int i = 0; i < array2.Length; i++)
                Console.WriteLine(array2[i]);

            // Но лучше использовать специально предназначенный для этого оператор foreach 
            // Работает он аналогично циклу for выше.
            // Однако исключает любые ошибки в индексах и выглядит понятнее.
            foreach (var e in array2)
                Console.WriteLine(e);

            // Иногда, когда нужны именно индексы, foreach не подходит.
            // Например, в случае присвоения элементов массива 
            for (int i = 0; i < array2.Length; i++)
                array2[i] = 2 * i;

            //Как и с другими типами, можно использовать var и совместить объявление и инициализацию
            var array1 = new int[3];
            array1[0] = 1;
            array1[1] = 2;
            array1[2] = 3;

            //Можно записать так. Это тоже самое, что предыдущие 4 строки. 
            var array2 = new int[] { 1, 2, 3 };

            //Или даже так. Компилятор автоматически восстановит тип данных из типов констант 1, 2, 3.
            var array3 = new[] { 1, 2, 3 };

            //Это касается, конечно, всех типов, не только числовых.
            var array4 = new[] { "a", "b", "c" };

            //Здесь компилятор выдаст ошибку, поскольку он не может определить тип массива.
            //var array5 = new[] { 1, "2", 3 };

            //Но это можно исправить, если указать тип явно. object - это прародитель всех типов. 
            //Все есть object.
            var array6 = new object[] { 1, "2", 3 };
            //Массив, как и строка, может быть равен null
            int[] localArray = null;

            //И, соответственно, неинициализированные глобальные переменные типа массивов
            //также равны null
            if (globalArray == null)
                Console.WriteLine("globalArray is null");

            //Этот код вызовет NullReferenceException
            Console.WriteLine(globalArray[0]);

            var intArray = new int[10];
            //Этот код выведет 0, поскольку массив чисел инициализирован нулями
            Console.WriteLine(intArray[0].ToString());

            var stringArray = new string[10];
            //Этот код вызовет exception, поскольку массив строк инициализирован значениями null
            Console.WriteLine(stringArray[0].ToString());

            //Почему так? Есть некая фундаментальная разница между массивами и строками с одной стороны
            //и числами - с другой. 


            // МНОГОМЕРНЫЕ МАССИВЫ
            
            
            //Двумерные массивы имеют тип int[,] (соответственно, double[,], string[,] и т.д.)
            int[,] twoDimensionalArray = new int[2, 3];

            //Адресация двумерных массивов также идет через запятую
            twoDimensionalArray[1, 2] = 1;

            for (int i = 0; i < twoDimensionalArray.GetLength(0); i++)
                for (int j = 0; j < twoDimensionalArray.GetLength(1); j++)
                    twoDimensionalArray[i, j] = 10 * i + j;
            //В памяти значения хранятся в следующем порядке: 0,1,2,10,11,12
            Console.WriteLine(twoDimensionalArray.Length);
            //Метод выше напечатает 6. Длины размерностей нужно получать через метод GetLength
            //Могут быть массивы и бо́льшей размерности
            int[,,] threeDimensionalArray = new int[2, 3, 4];

            //Это - массив массивов. Поскольку массив является типом (как int или string),
            //то можно делать массивы этого типа, т.е. - массивы массивов
            int[][] array;
            array = new int[2][];

            //Так можно - array инициализирован
            Console.WriteLine(array.Length);

            //Выдаст исключение, ведь нулевой массив в этом массиве массивов не инициализирован
            Console.WriteLine(array[0].Length);

            array[0] = new int[3];
            //Теперь это сработает, потому что мы проинициализировали нулевой элемент
            Console.WriteLine(array[0].Length);
            //А это по-прежнему вызовет исключение, потому что первый элемент не инициализирован
            Console.WriteLine(array[1].Length);

            //В отличие от многомерного массива, индексация производится двумя парами скобок
            array[0][0] = 1;

            //В отличие от многомерного массива, являющегося прямоугольником или параллелепипедом,
            //в массиве массивов все хранимые массивы могут быть разной длины
            array[1] = new int[10];

            //Могут быть массивы массивов массивов...
            int[][][] array1 = new int[2][][];

            //или массивы двумерных массивов
            int[][,] array2 = new int[2][,];

            //а также двумерные массивы массивов
            int[,][] array3 = new int[2, 3][];

            //Самое главное - если есть тип, 
            //то из него можно сделать массив, который тоже будет типом.

        }

        static int GetBound()
        {
            Console.Write("!");
            return 5;
        }

        /* Допустим, мы хотим читать из консоли числа и суммировать их, 
	 * пока не будет введена пустая строка. Как это сделать?
	 * 
	 * Хочется написать как-то так:
		while (line != "")
		{
			string line = Console.ReadLine(); 
			sum += int.Parse(line);
			line = Console.ReadLine();
		}
	 * но нельзя, потому что line видна только внутри блока while, но не в его условии
	 */

        static void FirstWay()
        {
            var sum = 0;
            string line = Console.ReadLine();
            while (line != "")
            {
                sum += int.Parse(line);
                line = Console.ReadLine();
            }
            // неудобное определение переменной + дублирование кода!
        }

        static void SecondWay()
        {
            var sum = 0;
            string line = null;
            while ((line = Console.ReadLine()) != "")
                sum += int.Parse(line);

            // неудобочитаемо
        }

        static void RightWay()
        {
            int sum = 0;
            while (true)
            {
                var line = Console.ReadLine();
                //break прерывает выполнение инструкций цикла и выходит из него:
                if (line == "") break;
                sum += int.Parse(line);
            }
            //Оптимальный вариант - все читаемо и логика цикла понятна
        }
    }
}
