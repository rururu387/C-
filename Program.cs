using System;
using System.Data;

namespace Goose1
{
    class Program
    {
        static void Main(string[] args)
        {
            Edition ed1 = new Edition();
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
            Console.WriteLine("!!\n");*/
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
            }
        }
    }
}
