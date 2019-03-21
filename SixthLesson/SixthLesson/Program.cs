using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SixthLesson
{
    public class ListStack
    {
        List<int> list = new List<int>();
        public void Push(int value)
        {
            list.Add(value);
        }
        public int Pop()
        {
            if (list.Count == 0) throw new InvalidOperationException();
            var result = list[list.Count - 1];
            list.RemoveAt(list.Count - 1);
            return result;
        }
    }

    public class ListQueue
    {
        List<int> list = new List<int>();
        public void Enqueue(int value)
        {
            list.Add(value);
        }

        public int Dequeue()
        {
            if (list.Count == 0) throw new InvalidOperationException();
            var result = list[0];
            list.RemoveAt(0); //в этом месте реализация неэффективна,
                              //поскольку RemoveAt имеет линейную от размеров листа сложность
            return result;
        }
    }
    // Очередь через односвязный список
    public class QueueItem
    {
        public int Value { get; set; }
        public QueueItem Next { get; set; }
    }

    public class Queue
    {
        QueueItem head;
        QueueItem tail;

        public void Enqueue(int value)
        {
            if (head == null)
                tail = head = new QueueItem { Value = value, Next = null };
            else
            {
                var item = new QueueItem { Value = value, Next = null };
                tail.Next = item;
                tail = item;
            }
        }

        public int Dequeue()
        {
            if (head == null) throw new InvalidOperationException();
            var result = head.Value;
            head = head.Next;
            if (head == null)
                tail = null;
            return result;
        }
    }
    // Универсальная очеред
    public class QueueItemU
    {
        public object Value { get; set; }
        public QueueItemU Next { get; set; }
    }

    public class QueueU
    {
        QueueItemU head;
        QueueItemU tail;

        public bool IsEmpty { get { return head == null; } }

        public void Enqueue(object value)
        {
            if (IsEmpty)
                tail = head = new QueueItemU { Value = value, Next = null };
            else
            {
                var item = new QueueItemU { Value = value, Next = null };
                tail.Next = item;
                tail = item;
            }
        }

        public object Dequeue()
        {
            if (head == null) throw new InvalidOperationException();
            var result = head.Value;
            head = head.Next;
            if (head == null)
                tail = null;
            return result;
        }
    }

    public class Program
    {
        static void Main()
        {
            var myIntQueue = new QueueU();
            myIntQueue.Enqueue(10);
            myIntQueue.Enqueue(20);
            myIntQueue.Enqueue(30);

            //Но что, если кто-то напишет так?
            myIntQueue.Enqueue("Surprise!");

            int sum = 0;
            while (!myIntQueue.IsEmpty)
            {
                int value = (int)myIntQueue.Dequeue(); //здесь будет InvalidCastException
                sum += value;
            }

        }
    }

    // ДЖЕНЕРИК КЛАССЫ
    public class QueueItem<T> // T - это какой-то тип данных
    {
        //Внутри класса QueueItem, T может использоваться везде,
        //где может использоваться тип данных:
        //при объявлении свойств, в аргументах методов, и т.д.
        public T Value { get; set; }
        public QueueItem<T> Next { get; set; }
    }

    public class Queue<T>
    {
        QueueItem<T> head;
        QueueItem<T> tail;

        public bool IsEmpty { get { return head == null; } }

        public void Enqueue(T value)
        {
            if (IsEmpty)
                tail = head = new QueueItem<T> { Value = value, Next = null };
            else
            {
                var item = new QueueItem<T> { Value = value, Next = null };
                tail.Next = item;
                tail = item;
            }
        }

        public T Dequeue()
        {
            if (head == null) throw new InvalidOperationException();
            var result = head.Value;
            head = head.Next;
            if (head == null)
                tail = null;
            return result;
        }
    }

    static void Main()
    {
        var myIntQueue = new Queue<int>();
        // здесь мы создаем очередь с уже конкретным T=int.
        // всюду, где в определении класса Queue<T> был написан T,
        // для объекта myIntQueue будет как бы написан int.


        myIntQueue.Enqueue(10);
        myIntQueue.Enqueue(20);
        myIntQueue.Enqueue(30);

        // myIntQueue.Enqueue("Surprise"); 
        // - здесь будет ошибка компиляции, т.к. метод Enqueue принимает значение T
        // а T для myIntQueue равно int.
    }
}
