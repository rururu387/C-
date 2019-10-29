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
                return mg.Name + mg.Date.ToString();
            }
            MagazineCollection <string> someMagCollection = new MagazineCollection<string>();
            Magazine myMag2 = new Magazine();
            someMagCollection.AddMagazines(KeySelector, myMag, myMag2);
            Console.WriteLine(someMagCollection.ToString());
            Console.WriteLine(someMagCollection.MaxIntremedRating);
            int j = 0;
            string str = "All magazines from collection where Frequency is monthly:\n";
            foreach (KeyValuePair<string, Magazine> somePair in someMagCollection.frequencyGroupWhere(Frequency.monthly))
            {
                str += "\t\t\t\t" + j + ")\n\n" + "Key: " + somePair.Key + "\tValue: " + somePair.Value.ToString();
                str += "\n\n\n\n";
                //That's bad
                j++;
            }
            Console.WriteLine(str);
            j = 0;
            str = "Grouped magazines by frequency:\n";
            IGrouping<int, KeyValuePair<string, Magazine>> groups = someMagCollection.FrequencyGroupBy;
            IEnumerable<KeyValuePair<string, Magazine>> smths = groups.SelectMany(group => group);
            List<KeyValuePair<string, Magazine>> newList = smths.ToList();
            /*foreach (IGrouping <string, KeyValuePair<string, Magazine>> somePair in someMagCollection.FrequencyGroupBy)
            {
                str += "\t\t\t\t" + j + ")\n\n" + "Key: " + somePair.Key + "\tValue: " + somePair.Value.ToString();
                str += "\n\n\n\n";
                //That's bad
                j++;
            }*/
            //Console.WriteLine(someMagCollection.frequencyGroupWhere(Frequency.monthly).ToString());
            //Console.WriteLine(someMagCollection.FrequencyGroupBy);


            /*Magazine myMag = new Magazine();
            Person pers1 = new Person();
            Person pers2 = new Person("Igor", "Murashev", new DateTime(2019, 10, 8, 17, 42, 0));
            Person pers3 = new Person("SerGey", "Pogranichnyi", new DateTime(2019, 10, 8, 20, 42, 0));
            Article art1 = new Article();
            Article art2 = new Article(pers3, "My little gosling", 9.99);
            myMag.addArticles(art1, art2);
            myMag.addEditors(pers1, pers2);
            myMag.Name = "myGoose";
            myMag.Date = new System.DateTime(2019, 10, 19, 14, 3, 00);
            myMag.Amount = 88888888;

            MagazineCollection magCollection = new MagazineCollection();
            magCollection.AddDefaultMagazines(5);

            magCollection.AddMagazines(myMag);

            string str = magCollection.ToString();
            Console.WriteLine(str);

            magCollection.sortEdition();
            str = magCollection.ToString();
            Console.WriteLine(str);
            magCollection.sortDate();
            str = magCollection.ToString();
            Console.WriteLine(str);
            magCollection.sortAmount();
            str = magCollection.ToString();
            Console.WriteLine(str);

            Console.WriteLine(magCollection.MaxIntremedRating);
            Console.WriteLine("!!!");
            MagazineCollection sortedFreqColl = new MagazineCollection (magCollection.FrequencyMagazine);
            Console.WriteLine(sortedFreqColl.ToString());
            Console.WriteLine("!!!");
            MagazineCollection sortedRatingColl = new MagazineCollection(magCollection.RatingGroup(0));
            Console.WriteLine(sortedRatingColl.ToString());

            TestCollections test1 = new TestCollections(4000000, 4000000, 4000000, 4000000);
            test1.countTime(3999900);*/

            /*Edition ed1 = new Edition();
            Edition ed2 = new Edition();
            ed2.Name = "Geese are beautiful";
            ref Edition ed1Ref = ref ed1;
            ref Edition ed2Ref = ref ed1;
            Console.WriteLine("First edition: " + ed1.ToString() + " Hash: " + ed1.GetHashCode());
            Console.WriteLine("Second edition: " + ed2.ToString() + " Hash: " + ed1.GetHashCode());
            if (ed1 != ed2)           //Как проверить, что ссылки на объекты не равны?
                Console.WriteLine("Refs don't match");
            try
            {
                ed1.Amount = -1;
            }
            catch(IndexOutOfRangeException ex)
            {
                Console.WriteLine(ex);
            }
            Magazine myMag = new Magazine();
            Person pers1 = new Person();
            Person pers2 = new Person("Igor", "Murashev", new DateTime(2019, 10, 8, 17, 42, 0));
            Person pers3 = new Person("SerGey", "Pogranichnyi", new DateTime(2019, 10, 8, 20, 42, 0));

            Article art1 = new Article();
            Article art2 = new Article(pers3, "My little gosling", 9.99);
            myMag.addArticles(art1, art2);

            myMag.addEditors(pers1, pers2);
            Console.WriteLine (myMag.ToString());

            Console.WriteLine(myMag.Eq);
            Console.WriteLine("\n");
            Magazine newMag = (Magazine)myMag.DeepCopy();
            myMag.Name = "Goose";
            myMag.Amount = 99999999;
            myMag.Date = new DateTime(2019, 10, 8, 0, 8, 0);
            Console.WriteLine("Object copy: " + newMag.ToString());
            Console.WriteLine("Object: " + myMag.ToString());
            /*foreach (Article art in myMag.getRatedArts(3.5))
            {
                Console.WriteLine(art);
            }
            Console.WriteLine("\n");
            foreach (Article art in myMag.getNamedArts("Geese"))
            {
                Console.WriteLine(art);
            }
            Console.WriteLine("!!\n");
            Console.WriteLine("\nThird party publishers articles:");
            foreach (Article artThirdPartyAuthor in myMag.thirdPartyPublishers())
            {
                Console.WriteLine("\t" + artThirdPartyAuthor);
            }
            Console.WriteLine("\nEditors publishers articles:");
            foreach (Article publisherAuthor in myMag.editorsPublishers())
            {
                Console.WriteLine("\t" + publisherAuthor);
            }
            Console.WriteLine("\nEditors not publishers:");
            foreach (Person editorNotAuthor in myMag.editorsNoPublishers())
            {
                Console.WriteLine("\t" + editorNotAuthor);
            }*/
        }
    }
}
