using System;
using System.Collections.Generic;
using System.Text;

namespace Goose1
{
    public class Article
    {
        public Person Author
        {
            get;
            set;
        }
        public string Art
        {
            get;
            set;
        }
        public double Rate
        {
            get;
            set;
        }

        public Article(Person _author, string _art, double _rate)
        {
            Author = _author;
            Art = _art;
            Rate = _rate;
        }
        public Article()
        {
            Author = new Person();
            Art = "Geese in Europe";
            Rate = 10.0;
        }
        public override string ToString()
        {
            string s = Author.ToString() + " " + Art + " " + Rate;
            return s;
        }
    }
}
