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
            Magazine someMag = (new Magazine(str, (Frequency)(value % 3), new System.DateTime(value + 2000 + 1, value % 11 + 1, value % 27 + 1, value % 24, value % 60, value * 7 % 60), value * 10000));
            return someMag;
        }//Переменная someMag удалится после выхода. Как в c# вернутьссылку?
        public TestCollections (int listKeyAm, int listStrAm, int testKeyDictionaryAm, int testStrDictionaryAm)
        {
            testListKey = new List<Edition>();
            testListStr = new List<string>();
            testKeyDictionary = new Dictionary<Edition, Magazine>();
            testStrDictionary = new Dictionary<string, Magazine>();
            for (int i = 0; i < listKeyAm; i++)
                testListKey.Add(new Edition(i.ToString(), new System.DateTime(i % 2000 + 1, i % 11 + 1, i % 27 + 1, i % 24, i % 60, i % 60), i));
            for (int i = 0; i < listStrAm; i++)
                testListStr.Add(i.ToString());
            for (int i = 0; i < testKeyDictionaryAm; i++)
                testKeyDictionary.Add(new Edition(i.ToString(), new System.DateTime(i % 2000 + 1, i % 11 + 1, i % 27 + 1, i % 24, i % 60, i % 60), i), new Magazine());
            for (int i = 0; i < testStrDictionaryAm; i++)
                testStrDictionary.Add(i.ToString(), new Magazine());
        }
        public void countTime(int i)
        {
            System.Diagnostics.Stopwatch SW = new System.Diagnostics.Stopwatch();
            Edition someEdKey = new Edition(i.ToString(), new System.DateTime(i % 2000 + 1, i % 11 + 1, i % 27 + 1, i % 24, i % 60, i % 60), i);
            SW.Start();
            testListKey.FindAll(someEd => someEd.Amount == someEdKey.Amount && someEd.Date == someEdKey.Date && someEd.Name == someEdKey.Name);
            SW.Stop();
            Console.WriteLine("Duration of search of all in List<Edition>:" + SW.ElapsedMilliseconds + " Miliseconds");
            SW.Reset();
            SW.Start();
            testListStr.FindAll(someStr => someStr == i.ToString());
            SW.Stop();
            Console.WriteLine("Duration of search of all in List<String>:" + SW.ElapsedMilliseconds + " Miliseconds");
            SW.Reset();
            SW.Start();
            Magazine tempMag = testKeyDictionary[someEdKey];
            SW.Stop();
            Console.WriteLine("Duration of search of all in Dictionary<Edition, Magazine>:" + SW.ElapsedMilliseconds + " Miliseconds");
            SW.Restart();
            tempMag = testStrDictionary[i.ToString()];
            SW.Stop();
            Console.WriteLine("Duration of search of all in Dictionary<String, Magazine>:" + SW.ElapsedMilliseconds + " Miliseconds");
        }
    }
}