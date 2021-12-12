using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HomeWork
{
    internal class ComplexNumber : ICloneable
    {
        private double Real { get; set; }

        private double Image { get; set; }



        public ComplexNumber()

        {

            Real = 0;

            Image = 0;

        }

        public ComplexNumber(double real, double image)

        {

            Real = real;

            Image = image;

        }




        public Object Clone()

        {

            return new ComplexNumber(this.Real, this.Image);

        }
    }
}
