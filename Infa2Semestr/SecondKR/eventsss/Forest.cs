using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infa2Semestr.SecondKR
{
    public class Forest
    {
        private string location;
        private int square;

        public string Location { get { return location; } }
        public int Square { get { return square; } }

        public Forest(string _location, int _square)
        {
            location = _location;
            square = _square;
        }

        public event EventHandler<GoFireEventArgs> GoFireDelegate;

        public void DepartureToTheFire(DateTime _call, bool isNearby)
        {
            var param = new GoFireEventArgs(_call, isNearby);
            var goFireParamCopy = GoFireDelegate;

            if (goFireParamCopy != null)
                goFireParamCopy(this, param);
        }
    }
}
