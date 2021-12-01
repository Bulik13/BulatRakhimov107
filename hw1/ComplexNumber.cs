using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp3.hw1
{
    public class ComplexNumber
    {
        public int RealPart { get; set; }
        public int Image { get; set; }
        public ComplexNumber(int r, int i)
        {
            RealPart = r;
            Image = i;
        }
        public ComplexNumber()
        {
            RealPart = 0;
            Image = 0;
        }
        public ComplexNumber Add(ComplexNumber n)
        {
            ComplexNumber number = new ComplexNumber(RealPart + n.RealPart, n.Image + Image);
            return number;
        }
        public void Add_toYourself(ComplexNumber c)
        {
            RealPart += c.RealPart;
            Image += c.Image;
        }
        public ComplexNumber Sub(ComplexNumber c)
        {
            ComplexNumber number = new ComplexNumber(RealPart - c.RealPart, Image - c.Image);
            return number;
        }
        public void Sub_toYourself(ComplexNumber c)
        {
            RealPart -= c.RealPart;
            Image -= c.Image;
        }
        public ComplexNumber Mult(ComplexNumber c)
        {
            ComplexNumber number = new ComplexNumber(RealPart * c.RealPart - Image * c.Image, RealPart * c.Image + c.RealPart * Image);
            return number;
        }
        public void Mult_toYourself(ComplexNumber c)
        {
            RealPart = RealPart * c.RealPart - Image * c.Image;
            Image = RealPart * c.Image + c.RealPart * Image;
        }
        public ComplexNumber Div(ComplexNumber c)
        {
            ComplexNumber number = new ComplexNumber((RealPart * c.RealPart - Image * c.Image) / (c.RealPart * c.RealPart + c.Image * c.Image), (RealPart * c.Image + c.RealPart * Image) / (c.RealPart * c.RealPart + c.Image * c.Image));
            return number;
        }
        public void Div_toYourself(ComplexNumber c)
        {
            RealPart = (RealPart * c.RealPart + Image * c.Image)/(c.RealPart * c.RealPart + c.Image * c.Image);
            Image = (RealPart * c.Image - c.RealPart * Image)/(c.RealPart * c.RealPart + c.Image * c.Image);
        }
        public bool Eqauls(ComplexNumber n)
        {
            bool result = (RealPart == n.RealPart && Image == n.Image);
            return result;
        }
        public double Length()
        {
            return Math.Sqrt(RealPart * RealPart + Image * Image);
        }
        public double Arg()
        {
            double z;
            if (RealPart > 0)
                z = Math.Atan(Image / RealPart);
            else if (RealPart < 0 && Image >= 0)
                z = Math.PI + Math.Atan(Image / RealPart);
            else if (RealPart < 0 && Image < 0)
                z = -Math.PI + Math.Atan(Image / RealPart);
            else if (RealPart == 0 && Image > 0)
                z = Math.PI / 2;
            else
                z = -Math.PI / 2;
            return z;
        }
        public string TooString()
        {
            return $"{RealPart}+{Image}*i";
        } 
    }
}
