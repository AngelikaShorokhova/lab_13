using System;
using System.Collections.Generic;
using System.Text;
using PersonLibrary;

namespace lab_13
{
    public delegate void CollectionHandler<T>(object source, CollectionHandlerEventArgs<T> args);
    
    public class NewCollection<T>: List<T>
    {
        public event CollectionHandler<T> CollectionCountChanged;
        public event CollectionHandler<T> CollectionReferenceChanged;

        public string Name { get; set; }

        public virtual void OnCollectionCountChanged(object source, CollectionHandlerEventArgs<T> args)
        {
            CollectionCountChanged?.Invoke(source, args);
        }
        public virtual void OnCollectionReferenceChanged(object source, CollectionHandlerEventArgs<T> args)
        {
            CollectionReferenceChanged?.Invoke(source, args);
        }

        public NewCollection(string s)
        {
            Name = s;
        }
        public bool Remove(int index)
        {
            if (index < 0 || index >= this.Count)
                return false;
            else
            {
                OnCollectionCountChanged(this, new CollectionHandlerEventArgs<T>(Name, "удаление элемента", this[index]));
                base.RemoveAt(index);
                return true;
            }
        }
        new public void Add(T obj)
        {
            OnCollectionCountChanged(this, new CollectionHandlerEventArgs<T>(Name, "добавление элемента", obj));
            base.Add(obj);
        }

        new public T this[int index]
        {
            get
            {
                return base[index];
            }
            set
            {
                OnCollectionReferenceChanged(this, new CollectionHandlerEventArgs<T>(this.Name, "изменение элемента", this[index]));
                base[index] = value;
            }
        }

    }
}
