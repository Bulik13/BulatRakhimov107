using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HomeWork.HW_String_ICloneable_IComparable_
{
    public static class StringExtension
    {
        public static string Connection(this string firstline, string secondline)

        {

            if (firstline == null && secondline != null)

                return secondline;

            else if (firstline != null && secondline == null)

                return firstline;




            string[] line1 = firstline.Split(' ');

            string[] line2 = secondline.Split(' ');




            string result = "";




            if (line1.Length >= line2.Length)

            {

                for (int i = 0; i < line1.Length; i++)

                {

                    result += line1[i];

                    if (i + 1 < line2.Length)

                        result += line2[i + 1];

                }

            }

            else

            {

                for (int i = 1; i < line2.Length; i++)

                {

                    if (i - 1 < line1.Length)

                        result += line1[i - 1];

                    result += line2[i];

                }

            }

            return result;

        }
    }
}
