using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Goose1
{
    public class MagazineCollection<TKey>
    {
        public delegate void MagazinesChangedHandler<TKey>(object source, MagazinesChangedEventArgs<TKey> args);
        public delegate TKey KeySelector(Magazine mg);
        Dictionary<TKey, Magazine> magazineDictionary;
        public event MagazinesChangedHandler<TKey> MagazinesChanged;
        public string CollectionName
        {
            get;
            set;
        }
        bool Replace (Magazine mold, Magazine mnew)
        {
            IEnumerable<KeyValuePair<TKey, Magazine>> oldMags = magazineDictionary.Where(x => x.Value == mold);
            if (!oldMags.Any())
                return false;
            foreach (KeyValuePair <TKey, Magazine> pair in oldMags)
            {
                MagazinesChanged(this, new MagazinesChangedEventArgs<TKey>(CollectionName, Update.replace, "Replace", pair.Key));
            }
            oldMags.Select(x => x = new KeyValuePair<TKey, Magazine> (x.Key, mnew));
            return true;
        }
        public void AddDefaultMagazines(int addAmount, KeySelector method)
        {
            for (int i = 0; i < addAmount; i++)
            {
                Magazine newMag = new Magazine(i.ToString(), ((Frequency)(i % 3)), new DateTime(i % 2000 + 1, i % 12, i % 28, i % 24, i % 60, i % 60), i % 10000);
                TKey key = method(newMag);
                MagazinesChanged(this, new MagazinesChangedEventArgs<TKey>(CollectionName, Update.add, "AddDefaultMagazines", key));
                magazineDictionary.Add(key, newMag);
            }
        }
        public void AddMagazines(KeySelector method, params Magazine[] magData)
        {
            for (int i = 0; i < magData.Length; i++)
            {
                TKey tempKey = method(magData[i]);
                magazineDictionary.Add(tempKey, magData[i]);
                MagazinesChanged(this, new MagazinesChangedEventArgs<TKey>(CollectionName, Update.add, "AddMagazines", tempKey));
            }
        }
        public MagazineCollection()
        {
            magazineDictionary = new Dictionary<TKey, Magazine>();
            CollectionName = "Goose collection";
        }
        public MagazineCollection(string name)
        {
            magazineDictionary = new Dictionary<TKey, Magazine>();
            CollectionName = name;
        }
        public override string ToString()
        {
            string str = "Magazine list contains:\n";
            int j = 0;
            foreach (KeyValuePair<TKey, Magazine> i in magazineDictionary)
            {
                str += "\t\t\t\t" + j + ")\n\n" + "Key: " + i.Key + "\tValue: " + i.Value.ToString();
                str += "\n\n\n\n";
                //That's bad
                j++;
            }
            return str;
        }
        public string ToShortString()
        {
            string str = "Magazine list contains:\n";
            int j = 0;
            foreach (KeyValuePair<TKey, Magazine> i in magazineDictionary)
            {
                str += "\t\t\t\t" + j + ")\n\n" + "Key: " + i.Key + "Value: " + i.Value.ToShortString();
                str += "\n\n\n\n";
                //That's bad
                j++;
            }
            return str;
        }
        public double MaxIntremedRating
        {
            get
            {
                if (magazineDictionary.Count == 0)
                    return 0;
                return magazineDictionary.Max(someMagazine => someMagazine.Value.IntermedRate);     //(x, y) => CompareIntermedRating(x, y));
            }
        }
        public IEnumerable<KeyValuePair<TKey, Magazine>> frequencyGroupWhere(Frequency value)
        {
            return magazineDictionary.Where(someMag => someMag.Value.Freq == value);
        }
        public IEnumerable<IGrouping<Frequency, KeyValuePair<TKey, Magazine>>> FrequencyGroupBy
        {
            get
            {
                return magazineDictionary.GroupBy(someMag => someMag.Value.Freq);
            }
        }
        /*System.Collections.Generic.List<Magazine> magazineList;
        public MagazineCollection()
        {
            magazineList = new List<Magazine>();
        }
        public MagazineCollection(List<Magazine> magList)
        {
            magazineList = new List<Magazine>();
            magazineList.AddRange(magList);
        }
        public string ToShortString ()
        {
            string str = "Magazine contains (shortly):";
            for (int i = 0; i < magazineList.Count; i++)
            {
                str += i + ":\n\n" + "Articles amount:\t" + magazineList[i].artList.Count + "Authors amount:\t" + magazineList[i].personList.Count + "\tIntermediate rating: " + magazineList[i].IntermedRate;
            }
            return str;
        }
        public void sortEdition()
        {
            if (magazineList != null)
                magazineList.Sort((x, y)=>x.CompareTo(y));
            else
                throw new Exception("Невозможно сравнить два объекта");
        }
        public void sortDate()
        {
            if (magazineList != null)
                magazineList.Sort((x, y) => y.Compare(x, y));
            else
                throw new Exception("Невозможно сравнить два объекта");
        }
        public void sortAmount()
        {
            EditionCompareAmount enc = new EditionCompareAmount();
            if (magazineList != null)
                magazineList.Sort(enc);
            else
                throw new Exception("Невозможно сравнить два объекта");
        }
        public List<Magazine> FrequencyMagazine
        {
            get
            {
                System.Collections.Generic.List<Magazine> magazineMonthly = new List<Magazine>();
                magazineMonthly.AddRange(magazineList.Where(someMagazine => someMagazine.Freq == Frequency.monthly));
                return magazineMonthly;
            }
        }
        public List<Magazine> RatingGroup(double value)
        {
            System.Collections.Generic.List<Magazine> magazineHigherRated = new List<Magazine>();
            magazineHigherRated = magazineList.FindAll(mag => mag.IntermedRate > value).ToList();           //Как имелось ввиду???? Очень долго пытался понять
            return magazineHigherRated;
        }*/
    }
}