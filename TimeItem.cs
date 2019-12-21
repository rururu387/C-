using System;
using System.Collections.Generic;
using System.Text;

namespace Goose3.NET
{
    [Serializable]
    class TimeItem
    {
        public long timeC_
        {
            get;
            set;
        }
        public long timeCpp
        {
            get;
            set;
        }
        public double coef
        {
            get;
            set;
        }
        public TimeItem(long _timeC_, long _timeCpp, double _coef)
        {
            timeC_ = _timeC_;
            timeCpp = _timeCpp;
            coef = _coef;
        }
        public override string ToString()
        {
            if (coef != -100)
                return "C# running time: " + timeC_.ToString() + "\tC++ running time: " + timeCpp + "\tC++ is aproximately " + coef.ToString() + " times quicker than C#";
            else
            {
                return "C# running time: " + timeC_.ToString() + "\tC++ running time: " + timeCpp + "\tCouldn't determine the ratio of time elapsed during calculations because C++ time is less than 1 millisecond. Try bigger matrix=)";
            }
        }
    }
}
