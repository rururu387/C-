using System;
using System.Collections.Generic;
using System.Text;

namespace Goose1
{
    class MagazineCollection
    {
        System.Collections.Generic.List<Magazine> magazineList;
        public void AddDefaults(int addAmount)
        {
            for (int i = 0; i < addAmount; i++)
            {
                Magazine newMag = new Magazine();
                magazineList.Add(newMag);
            }
        }
        public void AddMagazines(params Magazine []magData)
        {
            for (int i = 0; i < magData.Length; i++)
                magazineList.Add(magData[i]);
        }
        public override string ToString()
        {
            string str = "Magazine list contains:\n";
            for (int i = 0; i < magazineList.Count; i++)
            {
                str += i + ":\n\n" + magazineList[i].ToString();
                //That's bad
            }
            return str;
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
                magazineList.Sort((x, y)=>y.Compare(x, y));
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
        double maxIntremedRating
        {
            get
            {

                return System.Linq.Enumerable.Max(magazineList, );
            }
        }
    }
}
