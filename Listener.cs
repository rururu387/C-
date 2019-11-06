using System;
using System.Collections.Generic;
using System.Text;

namespace Goose1
{
    class Listener
    {
        List<ListEntry> listEntries;
        public Listener()
        {
            listEntries = new List<ListEntry>();
        }
        public void MagazinesChanged(object source, MagazinesChangedEventArgs<string> e)
        {
            MagazineCollection<string> a = new MagazineCollection<string>();
            if (source.GetType() != a.GetType())
                throw new FormatException("Event couldn't be handled");
            if (source.GetType() == a.GetType())
                listEntries.Add(new ListEntry(e.ElementKey.ToString(), e.Status, ((MagazineCollection<string>)source).CollectionName, e.ElementKey.ToString()));
        }
        public override string ToString()
        {
            string str = "";
            int i = 0;
            listEntries.ForEach(x => str += i++ + ":\t" + x.ToString() + "\n");
            return str;
        }
    }
}
