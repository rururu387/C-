using System;
using System.Collections.Generic;
using System.Text;

namespace Goose1
{
    public class Magazine
    {
        string name;
        Frequency freq;
        System.DateTime date;
        int amount;
        Article []artList;

        public Magazine(string _name, Frequency _freq, System.DateTime _date, int _amount)
        {
            name = _name;
            freq = _freq;
            date = _date;
            amount = _amount;
        }

        public Magazine()
        {
            name = "Geese on weekends";
            freq = (Frequency)0;
            date = new System.DateTime(2019, 8, 9, 1, 0, 0);
            amount = 10000000;
            int n = 2;
            artList = new Article[n];
            for (int i = 0; i < n; i++)
            {
                artList[i] = new Article();
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
        public System.DateTime Date
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

        public double IntermedRate
        {
            get
            {
                double sumRate = 0;
                int len = artList.Length;
                for (int i = 0; i < len; i++)
                {
                    sumRate += artList[i].Rate;
                }
                return sumRate / len;
            }
        }
        public bool this [Frequency i]
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
        public void addArticles (params Article []articleList)
        {
            int len1 = artList.Length;
            int len2 = articleList.Length;
            Array.Resize(ref artList, len1 + len2);                     //Второй способ
            /*Article []artList2 = new Article[len1 + len2];
            for (int i = 0; i < len1; i++)
            {
                artList2[i] = artList[i];
            }*/
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
        }

        public override string ToString()
        {
            string s = name + " " + freq + " " + date.ToString() + " " + amount + "\nArticle list:\n";
            for (int i = 0; i < artList.Length; i++)
                s = s + artList[i].ToString() + "\n";                //Careful! Shitcode!!!

            return s;
        }
    }
}
