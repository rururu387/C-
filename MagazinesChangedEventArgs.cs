using System;
using System.Collections.Generic;
using System.Text;

namespace Goose1
{
    public class MagazinesChangedEventArgs<TKey> : System.EventArgs
    {
        string CollectionName
        {
            get;
            set;
        }
        public Update Status
        {
            get;
            set;
        }
        public string EventSourceFunc
        {
            get;
            set;
        }
        public TKey ElementKey
        {
            get;
            set;
        }
        public MagazinesChangedEventArgs(string _collectionName, Update _status, string _eventSourceFunc, TKey _elementKey)
        {
            CollectionName = _collectionName;
            Status = _status;
            EventSourceFunc = _eventSourceFunc;
            ElementKey = _elementKey;
        }
        public override string ToString()
        {
            return "Collection name: " + CollectionName + "\tStatus: " + Status + "\tSource function: " + EventSourceFunc + "\tElement key: " + ElementKey;
        }
    }
}
