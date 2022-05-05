using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infa2Semestr.SecondKR
{
    public class MoES
    {
        private int moes_number;

        public int MoES_number { get { return MoES_number; } }

        protected void EvacuationOfPeople(object f, GoFireEventArgs param)
        {
            if(param.IsNearbyLocality == true && f is Forest)
            {
                var forest = (Forest)f;
                Console.WriteLine($"Бригада номер:{MoES_number}" +
                    $"выезжает на пожар расположенный в {forest.Location}" +
                    $" площадью {forest.Square}" +
                    $" время вызова {param.CallTime.ToShortTimeString}" +
                    "для эвакуации населения");
            }                
        }

        public void Subscribe(Forest f)
        {
            f.GoFireDelegate += EvacuationOfPeople;
        }

        public void UnSubscribe(Forest f)
        {
            f.GoFireDelegate -= EvacuationOfPeople;
        }
    }
}
