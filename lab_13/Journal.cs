using System;
using System.Collections.Generic;
using System.Text;

namespace lab_13
{
    public class Journal<T>
    {
        private List<JournalEntry<T>> journal = new List<JournalEntry<T>>();
        public void CollectionCountChanged(object sourse, CollectionHandlerEventArgs<T> e)
        {
            JournalEntry<T> je = new JournalEntry<T>(e.NameSource, e.Changes, e.ObjectCollection.ToString());
            journal.Add(je);

        }
        public void CollectionReferenceChanged(object sourse, CollectionHandlerEventArgs<T> e)
        {
            JournalEntry<T> je = new JournalEntry<T>(e.NameSource, e.Changes, e.ObjectCollection.ToString());
            journal.Add(je);
        }
        public override string ToString()
        {
            string s = "";
            foreach (JournalEntry<T> p in journal)
                s += p.ToString() + Environment.NewLine;
            return s;
        }
    }


}
