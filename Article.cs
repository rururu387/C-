using System;
using System.Collections.Generic;
using System.Collections;
using System.Text;

namespace Goose1
{
    [Serializable]
    public class Article : IRateAndCopy, IComparable, IComparer<Article>
    {
        public Person Author
        {
            get;
            set;
        }
        public string ArtName
        {
            get;
            set;
        }
        public double Rating
        {
            get;
            set;
        }

        public Article(Person _author, String _artName, double _rate)
        {
            Author = _author;
            ArtName = _artName;
            Rating = _rate;
        }
        public Article()
        {
            Author = new Person();
            ArtName = "Geese in Europe";
            Rating = 10.0;
        }
        public override string ToString()
        {
            string s = Author.ToString() + " " + ArtName + " " + Rating;
            return s;
        }
        public object DeepCopy()
        {
            Article someArt = new Article();
            someArt.ArtName = ArtName;
            someArt.Rating = Rating;
            Person somePers = (Person)Author.DeepCopy();
            return someArt;
        }
        public int CompareTo(object obj)
        {
            if (obj.GetType() != this.GetType())
                throw new System.ArgumentException("Couldn't compare object to Article because it has other type");
            Article art = (Article)obj;
            for (int i = 0; i < this.ArtName.Length && i < art.ArtName.Length; i++)
            {
                if (Char.ToLower(this.ArtName[i]) > Char.ToLower(art.ArtName[i]))
                    return 1;
                if (Char.ToLower(this.ArtName[i]) < Char.ToLower(art.ArtName[i]))
                    return -1;
                if (Char.IsUpper(this.ArtName[i]) && Char.ToLower(this.ArtName[i]) == art.ArtName[i])
                    return -1;
                if (Char.IsUpper(art.ArtName[i]) && Char.ToLower(art.ArtName[i]) == art.ArtName[i])
                    return 1;
            }
            if (this.ArtName.Length < art.ArtName.Length)
                return -1;
            if (this.ArtName.Length > art.ArtName.Length)
                return 1;
            return 0;
            //return this.ArtName.CompareTo(((Article)obj).ArtName);
        }
        public int Compare(Article obj1, Article obj2)
        {
            if (obj1.GetType() != obj2.GetType())
                throw new System.ArgumentException("Couldn't compare objects because they have different types");
            return ((Article)obj1).Author.SecondName.CompareTo(((Article)obj2).Author.SecondName);
        }
        public Article getFromConsole()
        {
            Console.WriteLine("Enter an article to add in an article list (article's author data: name_second name_Year o birth_Month_Day and then article data: name_rating). Use enter to split data: ");
            Author.Name = Console.ReadLine();
            Author.SecondName = Console.ReadLine();
            bool flag = false;
            do
            {
                try
                {
                    flag = false;
                    Author.BirthDate = Convert.ToDateTime(Console.ReadLine());
                }
                catch
                {
                    flag = true;
                    Console.WriteLine("You have entred an unvalid date. Retry:");
                }
            }
            while (flag);
            ArtName = Console.ReadLine();
            do
            {
                try
                {
                    flag = false;
                    Rating = System.Convert.ToDouble(Console.ReadLine());
                }
                catch
                {
                    flag = true;
                    Console.WriteLine("You have entred an unvalid rating. Retry:");
                }
            }
            while (flag);
            return this;
        }
    }
}
