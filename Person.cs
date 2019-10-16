using System;
using System.Collections.Generic;
using System.Text;

namespace Goose1
{
    public class Person
    {
        string name;
        string secondName;
        System.DateTime birthDate;
        public Person(string _name, string _secondName, System.DateTime _birthDate)
        {
            name = _name;
            secondName = _secondName;
            birthDate = _birthDate;
        }
        public Person()
        {
            name = "Aynur";
            secondName = "Badretdinov";
            birthDate = new System.DateTime(2001, 1, 24, 7, 54, 23);
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

        public string SecondName
        {
            get
            {
                return secondName;
            }
            set
            {
                secondName = value;
            }
        }

        public System.DateTime BirthDate
        {
            get
            {
                return birthDate;
            }
            set
            {
                birthDate = value;
            }
        }

        public int YearDate
        {
            get
            {
                return birthDate.Year;
            }
            set
            {
                birthDate = new System.DateTime(value, birthDate.Month, birthDate.Day, birthDate.Hour, birthDate.Minute, birthDate.Second);
            }
        }

        public override string ToString()
        {
            string personData = name + " " + secondName + " " + birthDate.ToString();
            //string personData = name + " " + secondName + " " + birthDate.Year + "." + birthDate.Month + "." + birthDate.Day + " in " + birthDate.Hour + ":" + birthDate.Minute + ":" + birthDate.Second;
            return personData;
        }

        public string ToShortString()
        {
            string personShortData = name + " " + secondName;
            return personShortData;
        }

        public override bool Equals(object obj)
        {
            if (obj.GetType() == this.GetType())
            {
                if (this.Name == ((Person)obj).Name && this.SecondName == ((Person)obj).SecondName && this.BirthDate == ((Person)obj).BirthDate)
                {
                    return true;
                }
            }
            return false;
        }

        public static bool operator ==(Person pers1, Person pers2)
        {
            return pers1.Equals(pers2);
        }
        public static bool operator !=(Person pers1, Person pers2)
        {
            return !pers1.Equals(pers2);
        }

        public override int GetHashCode()
        {
            const int hashMax = 1000000;
            int hash = 0;
            for (int i = 0; i < Name.Length; i++)
                hash += (int)Name[i] % hashMax;
            for (int i = 0; i < SecondName.Length; i++)
                hash += (int)SecondName[i] % hashMax;
            hash = hash % hashMax;
            hash += ((BirthDate.Year + BirthDate.Month + BirthDate.Day + BirthDate.Hour + BirthDate.Minute + BirthDate.Second) * 100) % hashMax;
            return hash;
        }

        public object DeepCopy()
        {
            Person somePers = new Person();
            somePers.Name = Name;
            somePers.SecondName = SecondName;
            System.DateTime newDate = new System.DateTime (BirthDate.Year, BirthDate.Month, BirthDate.Day, BirthDate.Hour, BirthDate.Minute, BirthDate.Second);
            somePers.BirthDate = newDate;
            return somePers;
        }
    }
}