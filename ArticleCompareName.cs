using System;
using System.Collections.Generic;
using System.Text;

namespace Goose1
{
    class ArticleCompareName : IComparer<Article>
    {
        public int Compare(Article art1, Article art2)
        {
            if (art1.Rating > art2.Rating)
                return 1;
            if (art1.Rating < art2.Rating)
                return -1;
            return 0;
        }
    }
}
