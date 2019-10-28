using System;
using System.Collections.Generic;
using System.Text;

namespace Goose1
{
    public class Magazine : Edition, IRateAndCopy, System.Collections.IEnumerable, IComparer<Magazine>
    {
        public Frequency freq;

        public System.Collections.Generic.List<Article> artList;
        public System.Collections.Generic.List<Person> personList;
        public Magazine(string _name, Frequency _freq, System.DateTime _date, int _amount)
        {
            name = _name;
            freq = _freq;
            date = _date;
            amount = _amount;
            artList = new System.Collections.Generic.List<Article>();
            personList = new System.Collections.Generic.List<Person>();
        }
        public void sortArtName()
        {
            Article artComparer = new Article();
            artList.Sort(0, artList.Count, artComparer);
        }
        public void sortArtAuthorSecondName()
        {
            artList.Sort();
        }
        public void sortRating()
        {
            ArticleCompareName artComparer = new ArticleCompareName();
            artList.Sort(0, artList.Count, artComparer);
        }
        public System.Collections.IEnumerator GetEnumerator()
        {
            Console.WriteLine("&&&&!!!&&&");
            for (int i = 0; i < artList.Count; i++)
            {
                bool flag = true;
                for (int j = 0; j < personList.Count; j++)
                {
                    if (((Article)artList[i]).Author.Equals(((Person)personList[j]).Name))
                        flag = false;
                }
                if (flag)
                    yield return artList[i];
            }
            yield break;
        }
        public System.Collections.IEnumerable thirdPartyPublishers()
        {
            for (int i = 0; i < artList.Count; i++)
            {
                bool flag = true;
                for (int j = 0; j < personList.Count; j++)
                {
                    if (((Article)artList[i]).Author.Equals(((Person)personList[j])))
                        flag = false;
                }
                if (flag)
                    yield return artList[i];
            }
            yield break;
        }
        public System.Collections.IEnumerable editorsPublishers()
        {
            for (int i = 0; i < artList.Count; i++)
            {
                bool flag = true;
                for (int j = 0; j < personList.Count; j++)
                {
                    if (((Article)artList[i]).Author == (Person)personList[j])
                    {
                        flag = false;
                        break;
                    }
                }
                if (!flag)
                    yield return artList[i];
            }
            yield break;
        }
        public System.Collections.IEnumerable editorsNoPublishers()
        {
            for (int i = 0; i < personList.Count; i++)
            {
                bool flag = true;
                for (int j = 0; j < artList.Count; j++)
                {
                    if (((Article)artList[j]).Author == (Person)personList[i])
                    {
                        flag = false;
                        break;
                    }
                }
                if (flag)
                    yield return personList[i];
            }
            yield break;
        }
        public Magazine() : base()
        {
            freq = (Frequency)0;
            artList = new System.Collections.Generic.List<Article>();
            personList = new System.Collections.Generic.List<Person>();
            artList.Add(new Article());
            artList.Add(new Article());
            personList.Add(new Person());
            personList.Add(new Person());
        }
        public Frequency Freq
        {
            get
            {
                return freq;
            }
            set
            {
                freq = value;
            }
        }
        System.Collections.Generic.List<Article> ArtList
        {
            get
            {
                return artList;
            }
        }
        System.Collections.Generic.List<Person> PersonList
        {
            get
            {
                return personList;
            }
        }
        public void addArticles(params Article[] art)
        {
            for (int i = 0; i < art.Length; i++)
                ArtList.Add(art[i]);
        }
        public void addEditors(params Person[] pers)
        {
            for (int i = 0; i < pers.Length; i++)
                PersonList.Add(pers[i]);
        }
        public override string ToString()
        {
            string str = Eq.Name + " " + Eq.Date.ToString() + " " + Eq.Amount + " " + Freq.ToString();
            str += "\nAuthors: \n";
            for (int i = 0; i < artList.Count; i++)
                str += i + ":\t" + ((Article)artList[i]).ToString() + "\n";
            str += "\nEditors: \n";
            for (int i = 0; i < personList.Count; i++)
                str += i + ":\t" + ((Person)personList[i]).ToString() + "\n";
            //That's bad
            return str;
        }
        public string ToShortString()
        {
            return Freq.ToString() + " " + Rating;
        }
        public double Rating
        {
            get
            {
                return IntermedRate;
            }
        }
        public double IntermedRate
        {
            get
            {
                double sumRate = 0;
                int len = artList.Count;
                for (int i = 0; i < len; i++)
                {
                    sumRate += ((Article)artList[i]).Rating;
                }
                return sumRate / len;
            }
        }
        public new object DeepCopy()
        {
            Magazine someMag = new Magazine();
            someMag.Name = new String(Name);
            someMag.Freq = new Frequency();
            someMag.Freq = Freq;
            someMag.Date = new System.DateTime(Date.Year, Date.Month, Date.Day, Date.Hour, Date.Minute, Date.Second);
            someMag.Amount = Amount;
            for (int i = 0; i < artList.Count; i++)
            {
                someMag.ArtList.Add(artList[i]);
            }
            for (int i = 0; i < personList.Count; i++)
            {
                someMag.PersonList.Add(PersonList[i]);
            }
            return someMag;
        }
        public Edition Eq
        {
            get
            {
                Edition someEd = new Edition();
                someEd.Name = Name;
                someEd.Amount = Amount;
                return someEd;
            }
            set
            {
                base.Name = ((Edition)value).Name;
                base.Amount = ((Edition)value).Amount;
            }
        }
        public bool this[Frequency i]
        {
            get
            {
                if (i == freq)
                    return true;
                return false;
            }
            set
            {
                freq = i;
            }
        }
        public int Compare(Magazine mag1, Magazine mag2)
        {
            if (mag2.GetType() != mag1.GetType())
                throw new System.ArgumentException("Differnt types of argument, CompareTo, Magazine");
            if (mag2.Date > mag1.Date)
                return 1;
            if (mag2.Date == mag1.Date)
                return 0;
            return -1;
        }
    }
}
