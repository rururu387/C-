using System;
using System.Collections.Generic;
using System.Data;
using System.ComponentModel;
using System.Linq;

namespace Goose1
{
    class Program
    {
        static void Main(string[] args)
        {
            /*Magazine myMag = new Magazine();
            Person pers1 = new Person();
            Person pers2 = new Person("Igor", "Murashev", new DateTime(2019, 10, 8, 17, 42, 0));
            Person pers3 = new Person("Sergey", "Pogranichnyi", new DateTime(2019, 10, 8, 20, 42, 0));
            Article art1 = new Article();
            Article art2 = new Article(pers3, "My little gosling", 9.99);
            myMag.addArticles(art1, art2);
            myMag.addEditors(pers1, pers2);
            myMag.Name = "myGoose";
            myMag.Date = new System.DateTime(2019, 10, 19, 14, 3, 00);
            myMag.Amount = 88888888;
            myMag.sortArtName();
            Console.WriteLine(myMag.ToString());
            myMag.sortArtAuthorSecondName();
            Console.WriteLine(myMag.ToString());
            myMag.sortRating();
            Console.WriteLine(myMag.ToString());
            string KeySelector(Magazine mg)
            {
                return mg.Name + " " + mg.Date.ToString();
            }
            MagazineCollection <string> someMagCollection = new MagazineCollection<string>();
            Magazine myMag2 = new Magazine();
            someMagCollection.AddMagazines(KeySelector, myMag, myMag2);
            Console.WriteLine(someMagCollection.ToString());
            Console.WriteLine(someMagCollection.MaxIntremedRating.ToString() + "\n");
            int j = 0;
            string str = "All magazines from collection where Frequency is weekly:\n";
            foreach (KeyValuePair<string, Magazine> somePair in someMagCollection.frequencyGroupWhere(Frequency.weekly))
            {
                str += "\t\t\t\t" + j + ")\n\n" + "Key: " + somePair.Key + "\tValue: " + somePair.Value.ToString();
                str += "\n\n\n\n";
                //That's bad
                j++;
            }
            Console.WriteLine(str);
            j = 0;
            str = "Grouped magazines by frequency:\n";
            List<IGrouping<Frequency, KeyValuePair<string, Magazine>>> groups = someMagCollection.FrequencyGroupBy.ToList();
            foreach (IGrouping < Frequency, KeyValuePair<string, Magazine> > group in groups)
            {
                str = "This is a group of frequency: ";
                str += "List of magazines comming " + group.Key.ToString() + ":\n\n";
                int k = 0;
                foreach (KeyValuePair<string, Magazine> pair in group)
                {
                    str += "\t\t\t\t" + k + ")\n";
                    str += "Magazine's real key is:\n" + pair.Key + "\n\n";
                    str += "Magazine itself:\n" + pair.Value.ToString() + "\n";
                    k++;
                }
                j++;
                str += j.ToString();
                str += "\n\n\n";
            }

            KeyValuePair<Edition, Magazine> generateElements(int value)
            {
                var a = new System.DateTime(value % 9000 + 1, value % 11 + 1, value % 27 + 1, value % 24, value % 60, value * 7 % 60);
                string str2 = "Goose";
                str2 += value;
                Edition someEd = new Edition(str2, new System.DateTime(value % 9000 + 1, value % 11 + 1, value % 27 + 1, value % 24, value % 60, value * 7 % 60), value * 10000);
                Magazine someMag = (new Magazine(str2, (Frequency)(value % 3), new System.DateTime(value % 9000 + 1, value % 11 + 1, value % 27 + 1, value % 24, value % 60, value * 7 % 60), value * 10000));
                return new KeyValuePair<Edition, Magazine>(someEd, someMag);
            }
            TestCollections<Edition, Magazine> someMagCollection2 = new TestCollections<Edition, Magazine>(300000, 300000, 300000, 300000, generateElements);
            Console.WriteLine("The first element:\n");
            someMagCollection2.countTime(0);
            Console.WriteLine("Element in the middle:\n");
            someMagCollection2.countTime(150000); 
            Console.WriteLine("The last element:\n");
            someMagCollection2.countTime(300000);
            Console.WriteLine("Element that does not exist:\n");
            someMagCollection2.countTime(300001);
            Console.WriteLine("str");*/

            /*Edition someEd2 = new Edition();
            someEd2.PropertyChanged += editionChanged;
            someEd2.Date = (new System.DateTime(1, 1, 1 , 1, 1, 1));*/

            MagazineCollection<string> gooseCollection1 = new MagazineCollection<string>("Goose1");
            MagazineCollection<string> gooseCollection2 = new MagazineCollection<string>("Goose2");
            Listener goose1Listener = new Listener();
            //MagazinesChangedHandler<string> goose1Listener2 = goose1Listener.MagazinesChanged;
            gooseCollection1.MagazinesChanged += goose1Listener.MagazinesChanged;
            string KeySelector(Magazine mg)
            {
                return mg.Name + " " + mg.Date.ToString();
            }
            gooseCollection1.AddDefaultMagazines(2, KeySelector);
            DateTime date = new DateTime(2019, 11, 6, 18, 40, 00);
            gooseCollection1.AddMagazines(KeySelector, new Magazine("In geese world", Frequency.yearly, date, 5555555));
            gooseCollection1["In geese world " + date.ToString()].Amount = 100000;
            gooseCollection1["In geese world " + date.ToString()].Name = "Handsome goose";
            gooseCollection1["In geese world " + date.ToString()].Date = new DateTime(2019, 11, 6, 20, 28, 00);
            int i = 0;
            gooseCollection1.Replace(new Magazine(i.ToString(), ((Frequency)(i % 3)), new System.DateTime(i % 9000 + 1, i % 11 + 1, i % 27 + 1, i % 24, i % 60, i * 7 % 60), i * 1000 + i * 100 + i * 10 + i % 1000000), new Magazine());
            gooseCollection1.Replace(new Magazine("In geese world", Frequency.yearly, date, 5555555), new Magazine());
            Console.WriteLine(goose1Listener.ToString());
        }
    }
}