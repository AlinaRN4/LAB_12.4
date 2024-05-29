using ClassLibrary10lab;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace lab13
{
    public delegate void CollectionHandler(object source, CollectionHandlerEventArgs args);

    public class MyObservableCollection<T> : MyCollection<T> where T : IInit, ICloneable, IComparable, new()
    {
        public event CollectionHandler CollectionCountChanged;
        public event CollectionHandler CollectionReferenceChanged;

        public MyObservableCollection() : base() { }



        public new void Add(T item)
        {
            base.AddToEnd(item);
            OnCollectionCountChanged(new CollectionHandlerEventArgs("Item Added", item));
        }

        public new bool Remove(T item)
        {
            bool result = base.Remove(item);
            if (result)
            {
                OnCollectionCountChanged(new CollectionHandlerEventArgs("Item Removed", item));
            }
            return result;
        }

        protected virtual void OnCollectionCountChanged(CollectionHandlerEventArgs e)
        {
            CollectionCountChanged?.Invoke(this, e);
        }

        protected virtual void OnCollectionReferenceChanged(CollectionHandlerEventArgs e)
        {
            CollectionReferenceChanged?.Invoke(this, e);
        }

        
    }
}   
