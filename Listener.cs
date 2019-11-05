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
        public void MagazinesChanged(MagazinesChangedEventArgs<Magazine> e)
        {
            listEntries.Add(new ListEntry(e.ElementKey.ToString(), e.Status, e.EventSourceFunc, e.ElementKey.ToString()));
        }
        public override string ToString()
        {
            string str = "";
            int i = 0;
            listEntries.ForEach(x => str += i++ + x.ToString() + "\n");
            return str;
        }
    }
}
