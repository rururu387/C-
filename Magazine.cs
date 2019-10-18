using System;
using System.Collections.Generic;
using System.Text;

namespace Goose1
{
    public class Magazine : MagazineCollection, IRateAndCopy, System.Collections.IEnumerable, IComparer<Magazine>
    {
        /*string name;
        System.DateTime date;
        int amount;
        Article []artList;*/
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
        /*public System.Collections.IEnumerator GetEnumerator(int a)
        {
            if ()
            yield return ;
            //return new EditPublishEnumerator(this);
            //return new EditNoPublishEnumerator(this);
        }*/
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
        /*public class MagazineEnumerator : System.Collections.IEnumerator
        {
            private Magazine myMag;
            private int index = -1;
            public MagazineEnumerator(Magazine mag)
            {
                myMag = mag;
            }
            public bool MoveNext()
            {
                if (index + 1 >= myMag.artList.Count)
                {
                    return false;
                }
                index++;
                return true;
            }
            public object Current
            {
                get
                {
                    return myMag.artList[index];
                }
            }
            public void Reset()
            {
                index = -1;
            }
        }*/
        public Magazine() : base()
        {
            //name = "Geese on weekends";
            freq = (Frequency)0;
            //date = new System.DateTime(2019, 8, 9, 1, 0, 0);
            //amount = 10000000;
            artList = new System.Collections.Generic.List<Article>();
            personList = new System.Collections.Generic.List<Person>();
            /*artList = new Article[n];
            for (int i = 0; i < n; i++)
            {
                artList[i] = new Article();
            }*/
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
        public void addArticles(params Article []art)
        {
            for (int i = 0; i < art.Length; i++)
                ArtList.Add(art[i]);
        }
        public void addEditors(params Person []pers)
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
        /*public IEnumerable<Article> getRatedArts(double rateMin)
        {
            for (int i = 0; i < artList.Count; i++)
            {
                if (((Article)artList[i]).Rating > rateMin)
                    yield return (Article)artList[i];
            }
        }
        public IEnumerable<Article> getNamedArts(string name)
        {
            for (int i = 0; i < artList.Count; i++)
            {
                if (((Article)artList[i]).ArtName.IndexOf(name) != -1)
                    yield return (Article)artList[i];
            }
        }*/
        /*public System.DateTime Date
        {
            get
            {
                return date;
            }
            set
            {
                date = value;
            }
        }  
        public string Name
        {
            get
            {
                return name;
            }
            set
            {
                name = value;
            }
        }
        public int Amount
        {
            get
            {
                return amount;
            }
            set
            {
                amount = value;
            }
        }
        public Article[] ArtList
        {
            get
            {
                return artList;
            }
            set
            {
                artList = value;
            }
        }
        public void addArticles (params Article []articleList)
        {
            int len1 = artList.Length;
            int len2 = articleList.Length;
            Array.Resize(ref artList, len1 + len2);                     //Второй способ
            Article []artList2 = new Article[len1 + len2];
            for (int i = 0; i < len1; i++)
            {
                artList2[i] = artList[i];
            }
            for (int i = len1; i < len1 + len2; i++)
            {
                artList[i] = articleList[i - len1];
            }
            //artList = artList2;
        }
        public string ToShortString()
        {
            string s = name + " " + freq + " " + date.ToString() + " " + amount + " " + IntermedRate;

            return s;
        }*/
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
