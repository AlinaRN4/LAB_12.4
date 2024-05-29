using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ClassLibrary10lab;
namespace lab13
{
    public class MyCollection<T> : MyList<T>, IEnumerable<T> where T : IInit, ICloneable, new()
    {
        public MyCollection() : base() { }
        public MyCollection(int size) : base(size) { }
        public int Count { get; set; }
        public IEnumerator<T> GetEnumerator()
        {
            return new MyEnumerator<T>(this);
        }
        IEnumerator IEnumerable.GetEnumerator()
        {
            throw new NotImplementedException();
        }

        
    }
    public class MyEnumerator<T> : IEnumerator<T> where T : IInit, ICloneable, new()
    {
        Point<T>? beg;
        Point<T>? current;

        public MyEnumerator(MyCollection<T> collection)
        {
            beg = collection.head;
            current = beg;
        }
        public T Current => current.Data;
        object IEnumerator.Current => throw new NotImplementedException();
        public void Dispose()
        {

        }
        public bool MoveNext()
        {
            if (current == null || current.Next == null || current.Data == null)
            {
                Reset();
                return false;
            }
            else
            {
                current = current.Next;
                return true;
            }
            
        }
        public void Reset()
        {
            current = beg;
        }

        
    }
}
