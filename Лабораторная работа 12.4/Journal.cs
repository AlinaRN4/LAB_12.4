using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ClassLibrary10lab;
namespace lab13
{
    public class Journal
    {
        public List<JournalEntry> Entries { get; private set; } = new List<JournalEntry>();

        public void AddEntry(object source, CollectionHandlerEventArgs args)
        {
            string collectionName = source.GetType().Name;
            var entry = new JournalEntry(collectionName, args.ChangeType, args.ChangedItem.ToString());
            Entries.Add(entry);
        }
        public void RemoveEntry(object source, CollectionHandlerEventArgs args)
        {
            string collectionName = source.GetType().Name;
            var entry = new JournalEntry(collectionName, args.ChangeType, args.ChangedItem.ToString());
            Entries.Remove(entry);
        }
        public void PrintEntries()
        {
            foreach (var entry in Entries)
            {
                Console.WriteLine(entry);
            }
        }
    }
}
