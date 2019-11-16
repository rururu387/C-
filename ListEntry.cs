using System;
using System.Collections.Generic;
using System.Text;

namespace Goose1
{
    class ListEntry
    {
        string CollectionName
        {
            get;
            set;
        }
        Update Status
        {
            get;
            set;
        }
        string MagName
        {
            get;
            set;
        }
        string KeyName
        {
            get;
            set;
        }
        public ListEntry()
        {
            CollectionName = "";
            Status = Update.add;
            MagName = "";
            KeyName = "";
        }
        public ListEntry(string _collectionName, Update _status, string _magName, string _keyName)
        {
            CollectionName = _collectionName;
            Status = _status;
            MagName = _magName;
            KeyName = _keyName;
        }
        public override string ToString()
        {
            return "Collection name: " + CollectionName + "\tStatus: " + Status + "\tMagazine name: " + MagName + "\tKey name: " + KeyName;
        }
    }
}
