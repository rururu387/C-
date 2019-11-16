using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Goose1
{
    class TestCollections<TKey, TValue>
    {
        public delegate KeyValuePair<TKey, TValue> generateElements(int value);
        generateElements elementGen;
        System.Collections.Generic.List<TKey> testListKey;
        System.Collections.Generic.List<string> testListStr;
        System.Collections.Generic.Dictionary<TKey, TValue> testKeyDictionary;
        System.Collections.Generic.Dictionary<string, TValue> testStrDictionary;
        public TestCollections (int listKeyAm, int listStrAm, int testKeyDictionaryAm, int testStrDictionaryAm, generateElements _elementGen)
        {
            elementGen = _elementGen;
            testListKey = new List<TKey>();
            testListStr = new List<string>();
            testKeyDictionary = new Dictionary<TKey, TValue>();
            testStrDictionary = new Dictionary<string, TValue>();
            for (int i = 0; i < listKeyAm; i++)
                testListKey.Add(elementGen(i).Key);
            for (int i = 0; i < listStrAm; i++)
                testListStr.Add(i.ToString());
            for (int i = 0; i < testKeyDictionaryAm; i++)
                testKeyDictionary.Add(elementGen(i).Key, elementGen(i).Value);
            for (int i = 0; i < testStrDictionaryAm; i++)
                testStrDictionary.Add(i.ToString(), elementGen(i).Value);
        }
        public void countTime(int i)
        {
            System.Diagnostics.Stopwatch SW = new System.Diagnostics.Stopwatch();
            SW.Start();
            testListKey.FindAll(someEd => someEd.Equals(elementGen(i).Value));
            SW.Stop();
            Console.WriteLine("Duration of search of all in List<Edition>:" + SW.ElapsedMilliseconds + " Miliseconds");
            SW.Reset();
            SW.Start();
            testListStr.FindAll(someStr => someStr == i.ToString());
            SW.Stop();
            Console.WriteLine("Duration of search of all in List<String>:" + SW.ElapsedMilliseconds + " Miliseconds");
            SW.Reset();
            TValue tempMag;
            SW.Start();
            try
            {
                tempMag = testKeyDictionary[elementGen(i).Key];
            }
            catch
            {}
            SW.Stop();
            Console.WriteLine("Duration of search of all in Dictionary<Edition, Magazine>:" + SW.ElapsedMilliseconds + " Miliseconds");
            SW.Restart();
            try
            {
                tempMag = testStrDictionary[i.ToString()];
            }
            catch {}
            SW.Stop();
            Console.WriteLine("Duration of search of all in Dictionary<String, Magazine>:" + SW.ElapsedMilliseconds + " Miliseconds");
        }
    }
}