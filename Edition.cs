using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Text;

namespace Goose1
{
    public class Edition : System.IComparable, System.Collections.Generic.IComparer<Edition>, INotifyPropertyChanged
    {
        protected string name;
        protected System.DateTime date;
        protected int amount;
        public event PropertyChangedEventHandler PropertyChanged;
        public int CompareTo(object obj)
        {
            return this.Name.CompareTo(((Edition)obj).Name);
        }
        public int Compare(Edition ed1, Edition ed2)
        {
            if (ed1.Date > ed2.Date)
                return 1;
            if (ed1.Date == ed2.Date)
                return 0;
            return -1;
        }
        public Edition()
        {
            name = "Goose edition";
            date = new System.DateTime(2019, 09, 21, 15, 46, 53);
            amount = 100000;
        }
        public Edition(string _name, System.DateTime _date, int _amount)
        {
            name = _name;
            date = _date;
            amount = _amount;
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
        public System.DateTime Date
        {
            get
            {
                return date;
            }
            set
            {
                System.DateTime newDate = new System.DateTime(value.Year, value.Month, value.Day, value.Hour, value.Minute, value.Second);
                PropertyChanged(this, new PropertyChangedEventArgs(string.Format("Date changed to: {0}", newDate)));
                date = newDate;
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
                if (value < 0)
                {
                    string str = "Index out of bounds";
                    throw new System.IndexOutOfRangeException(str);
                }
                PropertyChanged(this, new PropertyChangedEventArgs(string.Format("Amount changed to: {0}", value)));
                amount = value;
            }
        }
        public object DeepCopy()
        {
            Edition someEd = new Edition();
            someEd.Amount = Amount;
            System.DateTime newDate = new System.DateTime(someEd.Date.Year, someEd.Date.Month, someEd.Date.Day, someEd.Date.Hour, someEd.Date.Minute, someEd.Date.Second);
            someEd.Date = newDate;
            return someEd;
        }
        public override bool Equals(object obj)
        {
            if (obj.GetType() == this.GetType())
            {
                if (this.Name == ((Edition)obj).Name && this.Date == ((Edition)obj).Date && this.Amount == ((Edition)obj).Amount)
                {
                    return true;
                }
            }
            return false;
        }
        public static bool operator ==(Edition ed1, Edition ed2)
        {
            return ed1.Equals(ed2);
        }
        public static bool operator !=(Edition ed1, Edition ed2)
        {
            return !ed1.Equals(ed2);
        }

        public override int GetHashCode()
        {
            const int hashMax = 1000000;
            int hash = 0;
            for (int i = 0; i < Name.Length; i++)
                hash += (int)Name[i] % hashMax;
            hash = hash % hashMax;
            hash += ((Date.Year + Date.Month + Date.Day + Date.Hour + Date.Minute + Date.Second) * 100) % hashMax;
            return hash;
        }
        public override string ToString()
        {
            return name + " " + Date.ToString() + " " + amount;
        }
    }
}
