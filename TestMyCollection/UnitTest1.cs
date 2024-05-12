using ClassLibrary10lab;
using System.Collections.Generic;
using Лабораторная_работа_12._4;
namespace TestMyCollection
{
    [TestClass]
    public class UnitTest1
    {
        [TestMethod]
        public void TestMakeRandomData()
        {
            MyList<MusicalInstrument> list = new MyList<MusicalInstrument>();
            Point<MusicalInstrument> point = list.MakeRandomData();
            Assert.IsNotNull(point);
            Assert.IsNotNull(point.Data);
        }

        [TestMethod]
        public void TestMakeRandomItem()
        {
            MyList<MusicalInstrument> list = new MyList<MusicalInstrument>();
            MusicalInstrument item = list.MakeRandomItem();
            Assert.IsNotNull(item);
        }      

        [TestMethod]
        public void TestGetEnumerator()
        {
            MyCollection<MusicalInstrument> collection = new MyCollection<MusicalInstrument>();
            IEnumerator<MusicalInstrument> enumerator = collection.GetEnumerator();
            Assert.IsNotNull(enumerator);
        }
        [TestMethod]
        public void GetEnumerator_NotNull()
        {
            var collection = new MyCollection<MusicalInstrument>();
            var enumerator = collection.GetEnumerator();
            Assert.IsNotNull(enumerator);
        }
        [TestMethod]
        public void MoveNext_ReturnsTrue()
        {
            MyCollection<MusicalInstrument> collection = new MyCollection<MusicalInstrument>(1);
            collection.MakeRandomData();

            var enumerator = new MyEnumerator<MusicalInstrument>(collection);
            bool result = enumerator.MoveNext();
            Assert.IsTrue(result); 
        }
       
        [TestMethod]
        public void TestMoveNext_ReturnsFalse()
        {
            MyCollection<MusicalInstrument> collection = new MyCollection<MusicalInstrument>();
            var enumerator = new MyEnumerator<MusicalInstrument>(collection);
            bool result = enumerator.MoveNext();
            Assert.IsFalse(result); // Проверяем, что при пустой коллекции MoveNext вернет false
        }
       
        [TestMethod]
        public void Clear()
        {
            MyList<MusicalInstrument> list = new MyList<MusicalInstrument>();
            list.MakeRandomData();

            list.Clear();

            Assert.IsNull(list.head);
            Assert.IsNull(list.tail);
        }

        [TestMethod]
        public void RemoveLastItemWithSpecifiedData()
        {
            MyList<MusicalInstrument> list = new MyList<MusicalInstrument>();

            Assert.ThrowsException<Exception>(() => list.RemoveLastItemWithSpecifiedData(x => x.Name, 5));
        }
        [TestMethod]
        public void RemoveLastItemWithSpecifiedData_EmptyList()
        {
            MyList<MusicalInstrument> list = new MyList<MusicalInstrument>();

            Assert.ThrowsException<Exception>(() => list.RemoveLastItemWithSpecifiedData(x => x.Name, "Piano"));
        }


        [TestMethod]
        public void TestReset()
        {
            MyCollection<MusicalInstrument> collection = new MyCollection<MusicalInstrument>();
            MyEnumerator<MusicalInstrument> enumerator = new MyEnumerator<MusicalInstrument>(collection);
            enumerator.Reset();
            Assert.AreEqual(collection.head, enumerator.Current); // Проверяем, что Reset устанавливает текущий элемент в начало коллекции
        }

        [TestMethod]
        public void TestToString()
        {
            Point<MusicalInstrument> point = new Point<MusicalInstrument>(new MusicalInstrument());
            string result = point.ToString();
            Assert.IsFalse(string.IsNullOrEmpty(result));
        }

        [TestMethod]
        public void TestGetHashCode()
        {
            Point<MusicalInstrument> point = new Point<MusicalInstrument>(new MusicalInstrument());
            int hash = point.GetHashCode();
            Assert.AreNotEqual(0, hash);
        }

        [TestMethod]
        [ExpectedException(typeof(Exception))]
        public void TestRemoveLastItemWithSpecifiedData_EmptyList()
        {
            MyList<MusicalInstrument> list = new MyList<MusicalInstrument>();
            list.RemoveLastItemWithSpecifiedData(x => x, "data");
        }
        

        [TestMethod]
        public void Equals_True()
        {
            MyList<MusicalInstrument> list = new MyList<MusicalInstrument>(0);
            MyList<MusicalInstrument> list1 = new MyList<MusicalInstrument>(0);

            Assert.IsTrue(list.Equals(list1));
        }

        [TestMethod]
        public void Add_AddsNewItemToList()
        {
            MyList<MusicalInstrument> list = new MyList<MusicalInstrument>();
            list.Add();
            Assert.AreEqual(1, list.Count);
        }

        [TestMethod]
        public void MakeList_CreatesListWithGivenLength()
        {
            MyList<MusicalInstrument> list = new MyList<MusicalInstrument>();
            list.MakeList(5, list);
            Assert.AreEqual(5, list.Count);
        }

        [TestMethod]
        public void AddToEnd_AddsItemToEndOfList()
        {
            MyList<MusicalInstrument> list = new MyList<MusicalInstrument>();
            MusicalInstrument instrument = new MusicalInstrument();
            list.AddToEnd(instrument);
            Assert.AreEqual(1, list.Count);
        }

        [TestMethod]
        public void Clone_CreatesACopyOfList()
        {
            MyList<MusicalInstrument> originalList = new MyList<MusicalInstrument>(3);
            MyList<MusicalInstrument> clonedList = originalList.Clone();
            Assert.AreEqual(originalList.Count, clonedList.Count);
        }

        [TestMethod]
        public void FindItem_ReturnsCorrectItem()
        {
            MyList<MusicalInstrument> list = new MyList<MusicalInstrument>(2);
            MusicalInstrument instrument = new MusicalInstrument();
            list.AddToEnd(instrument);
            var foundItem = list.FindItem(instrument);
            Assert.IsNotNull(foundItem);
        }
        [TestMethod]
        public void ClearList()
        {
            MyList<MusicalInstrument> list = new MyList<MusicalInstrument>();
            list.MakeList(5, list);

            list.Clear();

            Assert.IsNull(list.head);
            Assert.IsNull(list.tail);
        }

        [TestMethod]
        [ExpectedException(typeof(Exception))]
        public void RemoveLastItemWithSpecifiedData_ThrowsExceptionIfListEmpty()
        {
            MyList<MusicalInstrument> list = new MyList<MusicalInstrument>();
            list.RemoveLastItemWithSpecifiedData(inst => inst.Name, "Guitar");
        }
    }
}