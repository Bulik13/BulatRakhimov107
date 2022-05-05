using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infa2Semestr.SecondKR
{
    public class GoFireEventArgs : EventArgs
    {
        private DateTime call_Time;
        private bool isNearbyLocality;

        public DateTime CallTime { get { return call_Time; } }
        public bool IsNearbyLocality { get { return isNearbyLocality; } }

        public GoFireEventArgs(DateTime _call, bool isnearby)
        {
            call_Time = _call;
            isNearbyLocality = isnearby;
        }
    }
}
