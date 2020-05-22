using System;
using System.Collections.Generic;
using System.Text;

namespace lab_13
{
    public class CollectionHandlerEventArgs<T> : System.EventArgs
    {
        public string NameSource { get; set; }
        public string Changes { get; set; }
        public T ObjectCollection { get; set; }
        public CollectionHandlerEventArgs()
        {
            NameSource = default;
            Changes = default;
            ObjectCollection = default;
        }
        public CollectionHandlerEventArgs(string ns, string c, T nc)
        {
            NameSource = ns;
            Changes = c;
            ObjectCollection = nc;
        }
        public override string ToString()
        {
            return $"Коллекция: {NameSource}, изменение: {Changes}, объект: " + ObjectCollection.ToString();
        }
    }
}
