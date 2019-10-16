using System;
using System.Collections.Generic;
using System.Text;

namespace Goose1
{
    interface IRateAndCopy
    {
        double Rating { get; }
        object DeepCopy();
    }
}
