using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infa2Semestr.SecondKR
{
    public class FireFighters
    {
        private int depatment_number;

        public int Department_number { get { return depatment_number; } }

        public FireFighters(int _numb)
        {
            depatment_number = _numb;
        }

        protected void GoToFire(object f, GoFireEventArgs param)
        {
            if(f is Forest)
            {
                var forest = (Forest)f;

                Console.WriteLine($"Бригада номер:{Department_number}" +
                    $"выезжает на пожар расположенный в {forest.Location}" +
                    $" площадью {forest.Square}" +
                    $" время вызова {param.CallTime.ToShortTimeString}");
            }
        }

        public void Subscribe(Forest f)
        {
            f.GoFireDelegate += GoToFire;
        }

        public void UnSubscribe(Forest f)
        {
            f.GoFireDelegate -= GoToFire;
        }
    }
}
