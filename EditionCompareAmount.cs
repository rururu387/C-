using System;
using System.Collections.Generic;
using System.Text;

namespace Goose1
{
    class EditionCompareAmount : System.Collections.Generic.IComparer<Edition>
    {
        public int Compare(Edition ed1, Edition ed2)
        {
            if (ed1.Amount > ed2.Amount)
                return 1;
            if (ed1.Amount == ed2.Amount)
                return 0;
            return -1;
        }
    }
}
