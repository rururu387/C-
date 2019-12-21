using System;
using System.Collections.Generic;
using System.Text;

namespace Goose1
{
    public class Article : IRateAndCopy
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

        public Article(Person _author, string _artName, double _rate)
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
    }
}
