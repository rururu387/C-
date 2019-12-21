using System;
using System.Collections.Generic;
using System.Text;
using System.Runtime.Serialization.Formatters.Binary;
using System.IO;

namespace Goose3.NET
{
    class TimeList
    {
        System.Collections.Generic.List<TimeItem> timeList;
        public void add (TimeItem item)
        {
            timeList.Add(item);
        }
        public void save(string filename)
        {
            BinaryFormatter formatter = new BinaryFormatter();
            if (timeList.Count != 0)
            {
                using (FileStream fs = new FileStream(filename, FileMode.OpenOrCreate))
                {
                    formatter.Serialize(fs, timeList);
                }
            }
        }
        public void load(string filename)
        {
            BinaryFormatter formatter = new BinaryFormatter();
            timeList.Clear();
            using (FileStream fs = new FileStream(filename, FileMode.OpenOrCreate))
            {
                if (fs.Length != 0)
                    timeList = (System.Collections.Generic.List<TimeItem>)formatter.Deserialize(fs);
                else
                    Console.WriteLine("Tried to deserealize empty stream");
            }
        }
        public TimeList()
        {
            timeList = new System.Collections.Generic.List<TimeItem>();
        }

        public override string ToString()
        {
            string str = "";
            System.Collections.Generic.List<TimeItem>.Enumerator enumerator = timeList.GetEnumerator();
            while (enumerator.MoveNext())
            {
                str += enumerator.Current.ToString() + '\n';
            }
            return str;
        }
    }
}
