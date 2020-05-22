using System;
using System.Collections.Generic;
using System.Text;

namespace lab_13
{
    public class JournalEntry<T>
    {
        public string NameSource { get; set; }
        public string Changes { get; set; }
        public string ObjectCollection { get; set; }
        public JournalEntry()
        {
            NameSource = default;
            Changes = default;
            ObjectCollection = default;
        }
        public JournalEntry(string ns, string c, string nc)
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
