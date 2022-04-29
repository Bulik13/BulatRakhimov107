using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infa2Semestr
{
    public class PowerPlantsEventArgs : EventArgs
    {
        private int tempNow;
        private int criticalTemp;

        // во сколько станция достигла критической температуры
        private DateTime time;

        public int TempNow { get { return tempNow; } set { } }
        public int CriticalTemp { get { return criticalTemp; } }
        public DateTime Time { get { return time; } }

        public PowerPlantsEventArgs(int tempnow, int crittemp, DateTime _time)
        {
            tempNow = tempnow;
            criticalTemp = crittemp;
            time = _time;
        }
    }
}
