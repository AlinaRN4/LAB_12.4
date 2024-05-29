using ClassLibrary10lab;
using lab13;
namespace TestEvents
{
    [TestClass]
    public class UnitTest1
    {
        [TestMethod]
        public void JournalEntry_ToString_ReturnsCorrectString()
        {
            // Arrange
            string collectionName = "Collection1";
            string changeType = "Item Added";
            string changedItemData = "MusicalInstrument: Гитара";

            JournalEntry entry = new JournalEntry(collectionName, changeType, changedItemData);

            // Act
            string result = entry.ToString();

            // Assert
            Assert.AreEqual($"{collectionName} - {changeType}: {changedItemData}", result);
        }

       
        [TestMethod]
        public void MyObservableCollection_Add_RaisesCollectionCountChangedEvent()
        {
            // Arrange
            MyObservableCollection<MusicalInstrument> collection = new MyObservableCollection<MusicalInstrument>();
            bool eventRaised = false;

            collection.CollectionCountChanged += (sender, args) => eventRaised = true;

            // Act
            collection.Add(new MusicalInstrument("Гитара"));

            // Assert
            Assert.IsTrue(eventRaised);
        }

        [TestMethod]
        public void MyObservableCollection_Remove_RaisesCollectionCountChangedEvent()
        {
            // Arrange
            MyObservableCollection<MusicalInstrument> collection = new MyObservableCollection<MusicalInstrument>();
            var instrument = new MusicalInstrument("Гитара");
            collection.Add(instrument);
            bool eventRaised = false;

            collection.CollectionCountChanged += (sender, args) => eventRaised = true;

            // Act
            collection.Remove(instrument);

            // Assert
            Assert.IsTrue(eventRaised);
        }
        [TestMethod]
        public void AddEntry_AddsEntryToList()
        {
            MyObservableCollection<MusicalInstrument> collection1 = new MyObservableCollection<MusicalInstrument>();
            // Arrange
            var journal = new Journal();
            var args = new CollectionHandlerEventArgs("Add", "Item1");

            // Act
            journal.AddEntry(collection1, args);

            // Assert
            Assert.AreEqual(1, journal.Entries.Count);
        }

        [TestMethod]
        public void RemoveEntry_RemovesEntryFromList()
        {
            MyObservableCollection<MusicalInstrument> collection1 = new MyObservableCollection<MusicalInstrument>();
            // Arrange
            var journal = new Journal();
            var args = new CollectionHandlerEventArgs("Remove", "Item2");
            journal.AddEntry(collection1, args);

            // Act
            journal.RemoveEntry(collection1, args);

            // Assert
            Assert.AreEqual(0, journal.Entries.Count);
        }

        [TestMethod]
        public void Add_Item_AddsItemAndRaisesCollectionCountChangedEvent()
        {
            // Arrange
            MyObservableCollection<MusicalInstrument> collection = new MyObservableCollection<MusicalInstrument>();
            var item = new MusicalInstrument("Гитара");
            bool eventRaised = false;
            collection.CollectionCountChanged += (sender, args) => { eventRaised = true; };

            // Act
            collection.Add(item);

            // Assert
            Assert.IsTrue(collection.Contains(item));
            Assert.IsTrue(eventRaised);
        }

        [TestMethod]
        public void Remove_Item_RemovesItemAndRaisesCollectionCountChangedEvent()
        {
            // Arrange
            MyObservableCollection<MusicalInstrument> collection = new MyObservableCollection<MusicalInstrument>();
            var item = new MusicalInstrument("Гитара");
            collection.Add(item);
            bool eventRaised = false;
            collection.CollectionCountChanged += (sender, args) => { eventRaised = true; };

            // Act
            collection.Remove(item);

            // Assert
            Assert.IsFalse(collection.Contains(item));
            Assert.IsTrue(eventRaised);
        }

        [TestMethod]
        public void Remove_NonExistingItem_ReturnsFalseAndDoesNotRaiseEvent()
        {
            // Arrange
            MyObservableCollection<MusicalInstrument> collection = new MyObservableCollection<MusicalInstrument>();
            var item = new MusicalInstrument("Гитара");
            bool eventRaised = false;
            collection.CollectionCountChanged += (sender, args) => { eventRaised = true; };

            // Act
            bool result = collection.Remove(item);

            // Assert
            Assert.IsFalse(result);
            Assert.IsFalse(eventRaised);
        }
    }
}