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

        /*public string Person::getName()
        {

        }*/

    }
}
