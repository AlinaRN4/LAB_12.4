using ClassLibrary10lab;

namespace lab13
{
    internal class Program
    {
        static void Main(string[] args)
        {
            // Создаем две коллекции MyObservableCollection
            MyObservableCollection<MusicalInstrument> collection1 = new MyObservableCollection<MusicalInstrument>();
            MyObservableCollection<MusicalInstrument> collection2 = new MyObservableCollection<MusicalInstrument>();

            // Создаем два объекта типа Journal
            Journal journal1 = new Journal();
            Journal journal2 = new Journal();

            // Подписываем первый Journal на события CollectionCountChanged и CollectionReferenceChanged из первой коллекции
            collection1.CollectionCountChanged += journal1.AddEntry;
            collection2.CollectionReferenceChanged += journal2.AddEntry;

            // Подписываем второй Journal на событие CollectionReferenceChanged из обеих коллекций
            collection1.CollectionReferenceChanged += journal1.AddEntry;
            collection2.CollectionReferenceChanged += journal2.AddEntry;

            // Демонстрация работы
            var instrument1 = new MusicalInstrument("Гитара");
            var instrument2 = new MusicalInstrument("Пианино");


            // Добавляем и изменяем элементы в коллекциях
            collection1.Add(instrument1);
            collection2.Add(instrument2);

            // Печать журнала
            Console.WriteLine("Journal 1 entries:");
            journal1.PrintEntries();

            Console.WriteLine("Journal 2 entries:");
            journal2.PrintEntries();


        }
    }
    
}
