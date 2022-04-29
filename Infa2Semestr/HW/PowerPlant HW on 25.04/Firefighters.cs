using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infa2Semestr
{
    public class Firefighters
    {
        public int numberOfFireStation;
        public int NumberOfFireStation { get { return numberOfFireStation; } }

        public Firefighters(int numberOfStation) { numberOfFireStation = numberOfStation; }


        protected void DepartureOfFireBrigade(object pp,
            PowerPlantsEventArgs param)
        {
            if(pp is PowerPlant)
            {
                var powerPlant = (PowerPlant)pp;
                Console.WriteLine($"Пожарная Бригада номер {NumberOfFireStation}" +
                    $"выезжает к электрической станции номер {powerPlant.NumberOfStation}" +
                    $"по причине того, что температура стала критической." +
                    $"время выезда: {param.Time.ToShortDateString}");
            }
        }

        public void Subcribe(PowerPlant pp)
        { 
            pp.PowerplantsDelegate += DepartureOfFireBrigade;
        }

        public void UnSubcribe(PowerPlant pp)
        {
            pp.PowerplantsDelegate -= DepartureOfFireBrigade;
        }
    }
}
