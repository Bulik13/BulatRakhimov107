using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infa2Semestr
{
    public class PowerPlantRunner
    {
        public void Run()
        {
            var pp1 = new PowerPlant(13);

            var ff1 = new Firefighters(10);

            var moes1 = new MoES(9);

            pp1.Safety(35, 50, new DateTime(2022, 04, 24));

            ff1.Subcribe(pp1);

            pp1.Safety(35, 50, new DateTime(2022, 04, 24));

            moes1.Subcribe(pp1);

            pp1.Safety(50, 60, new DateTime(2022, 04, 24));

            var ff2 = new Firefighters(19);

            ff1.UnSubcribe(pp1);
            ff2.Subcribe(pp1);
        }
    }
}
