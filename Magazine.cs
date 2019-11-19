using System;
using System.Collections.Generic;
using System.Text;

namespace Goose1
{
    [Serializable]
    public class Magazine : Edition, IRateAndCopy, System.Collections.IEnumerable, IComparer<Magazine>
    {
        public Frequency freq;
        public System.Collections.Generic.List<Article> artList;
        public System.Collections.Generic.List<Person> personList;
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
        public Magazine(string _name, Frequency _freq, System.DateTime _date, int _amount)
        {
            name = _name;
            freq = _freq;
            date = _date;
            amount = _amount;
            artList = new System.Collections.Generic.List<Article>();
            personList = new System.Collections.Generic.List<Person>();
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
        /*public new object DeepCopy()
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
        }*/
        public static Magazine DeepCopy(Magazine someMag)
        {
            System.Runtime.Serialization.IFormatter formatter = new System.Runtime.Serialization.Formatters.Binary.BinaryFormatter();
            System.IO.MemoryStream ms = new System.IO.MemoryStream();
            formatter.Serialize(ms, someMag);
            ms.Position = 0;
            return (Magazine)formatter.Deserialize(ms);
            /*Magazine someMag = new Magazine();
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
            return someMag;*/
        }
        public bool Save(string filename)
        {
            System.Runtime.Serialization.IFormatter formatter = new System.Runtime.Serialization.Formatters.Binary.BinaryFormatter();
            try
            {
                System.IO.Stream stream = new System.IO.FileStream(filename, System.IO.FileMode.Create, System.IO.FileAccess.Write);
                formatter.Serialize(stream, this);
                /*formatter.Serialize(stream, Freq);
                formatter.Serialize(stream, artList);
                formatter.Serialize(stream, personList);*/
                stream.Close();
            }
            catch
            {
                Console.WriteLine("An error occured while saving");
                return false;
            }
            return true;
        }
        public bool Load(string filename)
        {
            System.Runtime.Serialization.IFormatter formatter = new System.Runtime.Serialization.Formatters.Binary.BinaryFormatter();
            try
            {
                System.IO.Stream stream = new System.IO.FileStream(filename, System.IO.FileMode.Create, System.IO.FileAccess.Read);
                Magazine tempMag = (Magazine)formatter.Deserialize(stream);
                Freq = tempMag.Freq;
                foreach (Article art in tempMag.artList)
                    artList.Add(art);
                //artList = tempMag.artList;
                foreach (Person person in tempMag.personList)
                    personList.Add(person);
                /*Freq = (Frequency)formatter.Deserialize(stream);
                artList = (List<Article>)formatter.Deserialize(stream);
                personList = (List<Person>)formatter.Deserialize(stream);*/
                stream.Close();
            }
            catch
            {
                Console.WriteLine("An error occured while loading");
                return false;
            }
            return true;
        }
        static public bool Save(string filename, Magazine someMag)
        {
            System.Runtime.Serialization.IFormatter formatter = new System.Runtime.Serialization.Formatters.Binary.BinaryFormatter();
            try
            {
                System.IO.Stream stream = new System.IO.FileStream(filename, System.IO.FileMode.Create, System.IO.FileAccess.Write);
                formatter.Serialize(stream, someMag);
                stream.Close();
            }
            catch
            {
                Console.WriteLine("An error occured while saving");
                return false;
            }
            return true;
        }
        static public bool Load(string filename, Magazine someMag)
        {
            System.Runtime.Serialization.IFormatter formatter = new System.Runtime.Serialization.Formatters.Binary.BinaryFormatter();
            try
            {
                System.IO.Stream stream = new System.IO.FileStream(filename, System.IO.FileMode.Open, System.IO.FileAccess.Read);
                someMag = (Magazine)formatter.Deserialize(stream);
                stream.Close();
            }
            catch
            {
                Console.WriteLine("An error occured while loading");
                return false;
            }
            return true;
        }
        public bool addFromConsole()
        {
            Article someArt = new Article();
            someArt.getFromConsole();
            artList.Add(someArt);
            return true;
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
