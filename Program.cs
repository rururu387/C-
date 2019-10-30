using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;

namespace Goose1
{
    class Program
    {
        static void Main(string[] args)
        {
            Magazine myMag = new Magazine();
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
            Console.WriteLine(str);
        }
    }
}
