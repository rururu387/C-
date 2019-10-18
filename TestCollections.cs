using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Goose1
{
    class TestCollections
    {
        System.Collections.Generic.List<Edition> testListKey;
        System.Collections.Generic.List<string> testListStr;
        System.Collections.Generic.Dictionary<Edition, Magazine> testKeyDictionary;
        System.Collections.Generic.Dictionary<string, Magazine> testStrDictionary;
        public static Magazine generateMag(int value)
        {
            string str = "Goose";
            str += value;
            Magazine someMag = (new Magazine(str, (Frequency)(value % 3), new System.DateTime(value + 2000, value % 12, value % 28, value % 24, value % 60, value * 7 % 60), value * 10000));
            return someMag;
        }//Переменная someMag удалится после выхода. Как в c# вернутьссылку?
        TestCollections (int listKeyAm, int listStrAm, int testKeyDictionaryAm, int testStrDictionaryAm)
        {
            testListKey = new List<Edition>(listKeyAm);
            testListStr = new List<string>(listStrAm);
            testKeyDictionary = new Dictionary<Edition, Magazine>(testKeyDictionaryAm);
            testStrDictionary = new Dictionary<string, Magazine>(testStrDictionaryAm);
            for (int i = 0; i < listKeyAm; i++)
                testListKey[i] = new Edition();
            for (int i = 0; i < listStrAm; i++)
                testListStr[i] = "This is an element of list";
            for (int i = 0; i < testKeyDictionaryAm; i++)
                testListKey[i].Equals(new Tuple <Edition, Magazine> (new Edition(), new Magazine()));
            for (int i = 0; i < testStrDictionaryAm; i++)
                testListKey[i].Equals(new Tuple<string, Magazine>("This is a dictionary key", new Magazine()));
        }
        public void countTime()
        {
            System.Diagnostics.Stopwatch SW = new System.Diagnostics.Stopwatch();
            Edition defaultEd = new Edition();
            SW.Start();
            testListKey.FindAll(someEd => someEd.Amount == defaultEd.Amount && someEd.Date == defaultEd.Date && someEd.Name == defaultEd.Name);
            SW.Stop();
            Console.WriteLine("Duration of search of all in List<Edition>:");
            Console.Write(SW.ElapsedMilliseconds + " Miliseconds");
            SW.Reset();
            SW.Start();
            testListStr.FindAll(someStr => someStr == "This is an element of list");
            SW.Stop();
            Console.WriteLine("Duration of search of all in List<Edition>:");
            Console.Write(SW.ElapsedMilliseconds + " Miliseconds");
            SW.Reset();
            //Доделатб
        }
    }
}