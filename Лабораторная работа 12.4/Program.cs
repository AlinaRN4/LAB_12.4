using ClassLibrary10lab;

namespace Лабораторная_работа_12._4
{
    internal class Program
    {
        static void Main(string[] args)
        {
            MyCollection<MusicalInstrument> m1 = new MyCollection<MusicalInstrument>(10);
            foreach (MusicalInstrument m in m1)
            {
                Console.WriteLine(m);
            }
        }
    }
}
