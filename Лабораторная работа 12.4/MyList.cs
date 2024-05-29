using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ClassLibrary10lab;
namespace lab13
{
    public class MyList<T> where T : IInit, ICloneable, new()
    {
        public Point<T>? head = null;
        public Point<T>? tail = null;
        public Point<T>? beg = null;

        int count = 0;

        public int Count => count;

        public Point<T> MakeRandomData()
        {
            T data = new T();
            data.RandomInit();
            return new Point<T>(data);
        }

        public T MakeRandomItem()
        {
            T data = new T();
            data.RandomInit();
            return data;
        }
        public Point<T> MakePoint() // создаем элемент
        {
            T instrument = Activator.CreateInstance<T>();
            instrument.RandomInit();
            return new Point<T>(instrument);
        }
        public void Add() // добавляем элемент в список
        {
            Point<T> node = MakePoint();
            if (head is null) { head = node; } // Если список пуст, устанавливаем новый элемент как первый
            else
            {
                tail.Next = node; // У текущего последнего элемента списка (Tail) устанавливается ссылка на новую точку
                node.Prev = tail; // У новой точки устанавливается ссылка на предыдущий элемент списка
            }
            tail = node; // Новая точка становится последним элементом списка
            count++;
        }

        public void MakeList(int length, MyList<T> list) // Создаём список
        {
            if (length <= 0) { Console.WriteLine("Длина должна быть натуральным числом!"); }
            for (int i = 0; i < length; i++)
            {
                list.Add();
            }
        }

        public void AddToEnd(T item)
        {
            Point<T> newItem = new Point<T>();
            count++;
            if (tail != null)
            {
                tail.Next = newItem;
                newItem.Prev = tail;
                tail = newItem;
            }
            else
            {
                head = newItem;
                tail = head;
            }
        }
        public MyList() { }
        public MyList(int size)
        {
            if (size <= 0) throw new Exception("размер меньше нуля");
            head = MakeRandomData();
            tail = head;
            for (int i = 1; i < size; i++)
            {
                T newItem = MakeRandomItem();
                AddToEnd(newItem);
            }
            count = size;
        }
        public void PrintList()
        {
            if (count == 0)
                Console.WriteLine("Лист пустой");
            Point<T>? current = head;
            for (int i = 0; current != null; i++)
            {
                Console.WriteLine(current);
                current = current.Next;
            }
        }
        public Point<T>? FindItem(T item)
        {
            Point<T>? current = head;
            while (current != null)
            {
                if (current.Data == null)
                    throw new Exception("Data is null");
                if (current.Data.Equals(item))
                    return current;
                current = current.Next;
            }
            return null;
        }
        public MyList<T> Clone()
        {
            MyList<T> newList = new MyList<T>();

            // Копируем элементы из текущего списка в новый список
            Point<T>? current = head;
            while (current != null)
            {
                T newData = (T)current.Data.Clone(); // Глубокое копирование данных
                newList.AddToEnd(newData);
                current = current.Next;
            }

            return newList;
        }
        public void Clear()
        {
            head = null;
            tail = null;
            count = 0;
        }
        public bool Remove(T item)
        {
            Point<T>? current = head;
            while (current != null)
            {
                if (current.Data.Equals(item))
                {
                    if (current.Prev != null)
                    {
                        current.Prev.Next = current.Next;
                    }
                    else
                    {
                        head = current.Next;
                    }

                    if (current.Next != null)
                    {
                        current.Next.Prev = current.Prev;
                    }
                    else
                    {
                        tail = current.Prev;
                    }

                    //Count--;
                    
                    return true;
                }
                current = current.Next;
            }
            return false;
        }
        public override bool Equals(object? obj)
        {
            if (obj is MyList<T> p)
            {
                return this.head == p.head && this.tail == p.tail && this.count == p.count;
            }
            else { return false; }
        }
    }
}
