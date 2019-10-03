using System;
using System.Data;

namespace Goose1
{
    class Program
    {
        static void Main(string[] args)
        {
            Magazine goose = new Magazine();
            Console.WriteLine (goose.ToShortString() + "\n");

            Console.WriteLine(goose[(Frequency)0] + " ");
            Console.WriteLine(goose[(Frequency)1] + " ");
            Console.WriteLine(goose[(Frequency)2] + " ");

            goose.Name = "My geese today";
            goose.Freq = Frequency.monthly;
            goose.Date = new System.DateTime(2019, 9, 9, 0, 28, 0);
            goose.Amount = 99999999;
            Console.WriteLine(goose.ToShortString());       //Как посчитать средний рейтинг, если нет статей?
            Article[] artList = new Article[3];
            for (int i = 0; i < 3; i++)
                artList[i] = new Article();
            goose.addArticles(artList);
            Console.WriteLine(goose.ToString());

            /*//Console.WriteLine("Hello World!");
            Person Aynur = new Person();
            Aynur.YearDate = 2000;
            Console.WriteLine (Aynur.ToString());
            Console.WriteLine(Aynur.ToShortString());

            Frequency a = Frequency.monthly;
            //Frequency a = (Frequency)1;
            */

        }
    }
}
