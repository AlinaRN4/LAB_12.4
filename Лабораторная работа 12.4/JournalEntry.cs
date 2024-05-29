using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Channels;
using System.Threading.Tasks;
using ClassLibrary10lab;
namespace lab13
{
    public class JournalEntry
    {
        public string CollectionName { get; }
        public string ChangeType { get; }
        public string ChangedItemData { get; }

        public JournalEntry(string collectionName, string changeType, string changedItemData)
        {
            CollectionName = collectionName;
            ChangeType = changeType;
            ChangedItemData = changedItemData;
        }

        public override string ToString()
        {
            return $"{CollectionName} - {ChangeType}: {ChangedItemData}";
        }
    }
}