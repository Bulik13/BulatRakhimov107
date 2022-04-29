using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infa2Semestr
{
    public class PowerPlant
    {
        // номер станции
        private int numberOfStation;
        public int NumberOfStation { get { return numberOfStation; } }
        public PowerPlant(int number) { numberOfStation = number; }

        public event EventHandler<PowerPlantsEventArgs> PowerplantsDelegate;

        public void Safety(int tempnow, int crittemp, DateTime _time)
        {
            var param = new PowerPlantsEventArgs(tempnow, crittemp, _time);
            var powPlantsParamCopy = PowerplantsDelegate;
            int x = 1;
            int _temp = tempnow;
            int _crittemp = crittemp;

            if (powPlantsParamCopy != null)
            {
                while (_temp != _crittemp)
                {
                    _temp += 1;
                    Console.WriteLine($"температура в норме, попытка номер: {x}");
                    x++;
                }

                powPlantsParamCopy(this, param);
            }
        }
    }
}
