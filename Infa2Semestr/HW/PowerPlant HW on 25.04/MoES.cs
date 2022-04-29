using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infa2Semestr
{
    public class MoES
    {
        public int numberOfMoES;
        public int NumberOfMoES { get { return numberOfMoES; } }

        public MoES(int numberOfStation) { numberOfMoES = numberOfStation; }


        protected void DepartureOfMoES(object pp,
            PowerPlantsEventArgs param)
        {
            if (pp is PowerPlant)
            {
                var powerPlant = (PowerPlant)pp;
                Console.WriteLine($"Бригада МЧС номер {NumberOfMoES}" +
                    $"выезжает к электрической станции номер {powerPlant.NumberOfStation}" +
                    $"по причине того, что температура стала критической." +
                    $"время выезда: {param.Time.ToShortDateString}");
            }
        }

        public void Subcribe(PowerPlant pp)
        {
            pp.PowerplantsDelegate += DepartureOfMoES;
        }

        public void UnSubcribe(PowerPlant pp)
        {
            pp.PowerplantsDelegate -= DepartureOfMoES;
        }
    }
}
