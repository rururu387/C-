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

            /*Console.WriteLine("Insert column and row amount:");
            int ncolumn, nrow;
            ncolumn = Convert.ToInt32 (Console.ReadLine());
            nrow = Convert.ToInt32(Console.ReadLine());

            Magazine[] oneDim = new Magazine[ncolumn * nrow];
            for (int i = 0; i < oneDim.Length; i++)
            {
                Magazine someMag = new Magazine();
                oneDim[i] = someMag;
            }

            Magazine[,] twoDim = new Magazine[ncolumn, nrow];
            for (int i = 0; i < ncolumn; i++)
            {
                for (int j = 0; j < nrow; j++)
                {
                    Magazine someMag = new Magazine();
                    twoDim[i, j] = someMag;
                }
            }

            Magazine[][] ladderDim = new Magazine[ncolumn][];
            for (int i = 0; i < ncolumn; i++)
            {
                Magazine[] oneDimInternal = new Magazine[nrow];
                for (int j = 0; j < nrow; j++)
                {
                    oneDimInternal[j] = new Magazine();                    
                }
                ladderDim[i] = oneDimInternal;
            }

            System.Diagnostics.Stopwatch SW = new System.Diagnostics.Stopwatch();
            SW.Start();
            for (int i = 0; i < ncolumn * nrow; i++)
            {
                oneDim[i].Amount = 10000;
            }
            SW.Stop();
            Console.WriteLine("Running time for one dimension:");
            Console.Write (SW.ElapsedMilliseconds);
            Console.Write('\n');

            SW.Restart();
            for (int i = 0; i < ncolumn; i++)
            {
                for (int j = 0; j < nrow; j++)
                    twoDim[i, j].Amount = 10000;
            }
            SW.Stop();
            Console.WriteLine("Running time for two dimension:");
            Console.Write(SW.ElapsedMilliseconds);
            Console.Write('\n');

            SW.Restart();
            for (int i = 0; i < ncolumn; i++)
            {
                for (int j = 0; j < nrow; j++)
                    ladderDim[i][j].Amount = 10000;
            }
            SW.Stop();
            Console.WriteLine("Running time for ladder dimension:");
            Console.Write(SW.ElapsedMilliseconds);
            Console.Write('\n');*/

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
