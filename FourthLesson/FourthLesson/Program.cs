using System;
using System.Diagnostics;
using System.Text;
using System.Collections.Generic;
using System.IO;

namespace FourthLesson
{
    class Program
    {
        /**Конкатена́ция(лат.concatenatio «присоединение цепями; сцепле́ние») — 
         * операция склеивания объектов линейной структуры,
         * обычно строк.**/
        static void WrongConcatenation()
        {
            //Если нам нужно сконкатенировать большое количество строк
            //то конкатенация "в лоб" потребует очень много памяти в куче, 
            //и будет работать медленно

            var str = "";

            for (int i = 0; i < 50000; i++)
            {
                str += i.ToString() + ", ";
            }
        }

        static void RightConcatenation()
        {
            //Конкатенация со StringBuilder работает в сотни раз быстрее
            //Однако, в случае 3-4 строк вы не почувствуете разницы, поэтому 
            //в этом случае пользоваться StringBuilder не обязательно
            var builder = new StringBuilder();

            for (int i = 0; i < 50000; i++)
            {
                builder.Append(i);
                builder.Append(", ");
            }
        }

        static void Main(string[] args)
        {
            //СРАВНЕНИЕ СТРОК И МАССИВОВ
            string str = "abc";

            // У строки есть специфические методы:
            Console.WriteLine(str.Substring(1, 2)); // bc
            Console.WriteLine(str.ToUpper()); // ABC

            //Если раскомментировать эту строку, возникнет ошибка: строки нельзя модифицировать.
            //Не существует никакого способа изменить состояние конкретной строки.
            //str[0] = 'a';

            var oldStr = str;
            str += "def";
            Console.WriteLine(oldStr == str); // False. str — это новая строка.

            //Длину массива нельзя изменить
            //Иногда хочется, чтобы массив динамически рос, потому что мы не знаем заранее,
            //сколько в нем элементов
            //В этом случае, нужно использовать List
            //Обратите внимание на пространство имен System.Collections.Generic
            //Угловые скобки пока - волшебные слова. 
            //На самом деле это дженерик-тип, но мы поговорим об этом позже.
            List<int> list = new List<int>();

            list.Add(0);
            list.Add(2);
            list.Add(3);
            list.Insert(1, 1);
            list.RemoveAt(0);

            foreach (var e in list)
                Console.WriteLine(e);

            //StringBuilder - это класс, представляющий собой изменяемую строку
            var builder = new StringBuilder();

            //Он содержит различные методы вставки, добавления, удаления и т.д.
            builder.Append("Some ");
            builder.Append("string ");
            builder.Append("#15");
            builder.Remove(0, 5);
            builder.Insert(0, "test ");

            //Также можно манипулировать отдельными символами
            builder[0] = 'T';

            //StringBuilder можно превратить в строку
            var str = builder.ToString();
            Console.WriteLine(str);
            //Не нужно полностью заменять строки на StringBuilder,
            //Только в тех случаях, когда действительно выполняется много преобразований

            //Символ перевода строки
            Console.WriteLine("First line\nSecond line");

            //Символ возврата каретки
            Console.WriteLine("10%\r20%\r30%");

            //Символ табуляции - плохой способ делать таблички
            Console.WriteLine("10\t100\n10000\t1");

            //Вывод кавычки
            Console.WriteLine("This is \" quotes");

            //Так писать нельзя, поскольку компилятор пытается воспринять \U как спецсимвол
            //Console.WriteLine("C:\Users\admin"); // ошибка компиляции

            //Поэтому бэкслеш надо экранировать
            Console.WriteLine("C:\\Users\\admin");

            //Или использовать особую строку, в которой спецсимволы не допускаются
            Console.WriteLine(@"C:\Users\admin");

            //Такую строку удобно использовать для того, чтобы набивать в шарпе длинные строки,
            //фрагменты документов или кода
            Console.WriteLine(
                @"
                \section{Section 1}
                Some {\i LaTeX} text here.");

            //Единственный символ, который нужно экранировать внутри особой строки - кавычки. 
            //Они экранируются удвоением.
            Console.WriteLine(@"This is "" quotes");

            // Запись текста в файл:
            File.WriteAllText("1.txt", "Hello, world!");

            // Записать строки в файл,
            // разделив их символом конца строки (\r\n для Windows и \n для Linux и MacOS)
            File.WriteAllLines("2.txt", new[] { "Hello", "world" });

            // Чтение данных из файла
            string text = File.ReadAllText("1.txt");
            string[] lines = File.ReadAllLines("2.txt");


            var watch = new Stopwatch();
            watch.Start();
            WrongConcatenation();
            watch.Stop();
            Console.WriteLine(watch.ElapsedMilliseconds);

            watch = new Stopwatch();
            watch.Start();
            RightConcatenation();
            watch.Stop();
            Console.WriteLine(watch.ElapsedMilliseconds);
            
        }
    }
}

/*
 * На заметочку. Форматирование строк
 * var a = 13;
	var b = 14.3456789;

	//Всегда можно писать так:
	Console.WriteLine(a + " " + b);

	//Но для больших документов это не удобно. Кроме того, не получится настроить, 
	//например, количество цифр после запятой
	//Используйте форматированный вывод
	Console.WriteLine("{0} {1}", a, b); // 13 14,3456789

	//Для того, чтобы отформатировать строку без вывода, используйте string.Format
	//На самом деле, Console.WriteLine просто вызывает string.Format.
	var formattedString = string.Format("{0} {1}", a, b);

	//Форматированный вывод позволяет настроить точность округления
	Console.WriteLine("{0:0.000} {1:0.0000}", 1.23456, 1.23456); // 1,235 1,2346

	//Вывод завершающих нулей
	Console.WriteLine("{0:0.000} {1:0.###}", 1.2, 1.2); // 1,200 1,2

	//Добивание нулями слева
	Console.WriteLine("{0:D4}", 42); //0042

	//Разбиение на колонки и выравнивание по правому
	Console.WriteLine("{0,10}|\n{1,10}|", 12345, 123);
		//		12345|
		//		  123|

	//или левому краю
	Console.WriteLine("{0,-10}|\n{1,-10}|", 12345, 123);
		// 12345	|
		// 123		|

	//А также комбинации выравнивания и округления
	Console.WriteLine("{0,10:0.00}|\n{1,10:0.000}|", 1.45, 21.345);
		//		1,45|
		//	  21,345|

	//Форматирование времени и даты
	Console.WriteLine("{0:hh:mm:ss}", DateTime.Now); // 06:01:54

	// MM и mm — это Месяцы и минуты. Различаются только регистром.
	Console.WriteLine("{0:yy-MM-dd}", DateTime.Now); // 17-07-19

	// Можно менять количество букв и порядок:
	Console.WriteLine("{0:d-MM-yyyy}", DateTime.Now); // 1-12-2014

	//Фигурные скобки НЕ ЯВЛЯЮТСЯ спецсимволами шарпа:
	Console.WriteLine("{}"); //Это будет работать! 

	//Но они являются спецсимволами метода string.Format, и их нельзя использовать просто так,
	//если вызывается этот метод
	//Console.WriteLine("{0}{}", a); //Это скомпилируется, но выбросит исключение

	//Надо их экранировать удвоением
	Console.WriteLine("{0}{{}}", a); // 13{}
    */
