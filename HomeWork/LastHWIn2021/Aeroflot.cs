using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HomeWork.LastHWIn2021
{
    public struct Aeroflot : IComparable
    {
        public string Destination;
        public int FlightNumb;
        public string TypeOfPlane;

        public static Aeroflot[] AddToArray()
        {
            Console.WriteLine("Введодите данные о каждом рейсе");
            Aeroflot[] Arr = new Aeroflot[7];
            for (int i = 0; i < 7; i++)
            {
                var str = Console.ReadLine().Split(' ');
                Arr[i] = new Aeroflot
                    (str[0], CheckingNumb(str[1]), str[2]);

            }
            Console.WriteLine(Arr.Length);
            return Arr;
        }


        static int CheckingNumb(string str1)  
        {
            int number = 0;
            while (!Int32.TryParse(str1, out number))
            {
                Console.WriteLine("Ввели некорректноне значение, введите новое");
                str1 = Console.ReadLine();
            }
            return number;
        }

        public Aeroflot(string destination, int flightNumber, string typeofplane)
        {
            Destination = destination;
            FlightNumb = flightNumber;
            TypeOfPlane = typeofplane;
        }

        public int CompareTo(object? obj)
        {
            var object1 = (Aeroflot)obj;
            if (obj == null) return -1;
            if (obj != null)
            {
                if (object1.FlightNumb < this.FlightNumb) return 1;
                else if (object1.FlightNumb > this.FlightNumb) return -1;
                else return 0;
            }

            throw new Exception("Невозможно сравнить значения");
        }

        public static void Print(Aeroflot member)
        {
            Console.WriteLine($"Рейс номер {member.FlightNumb}, летящий на самолете типа {member.TypeOfPlane}");
        }

        public static void Print(Aeroflot[] arr)
        {
            foreach (Aeroflot member in arr)
                Print(member);
        }

        public static void Displaying(Aeroflot[] arr, string destination)
        {
            int count = 0;
            foreach (Aeroflot member in arr)
            {
                if (member.Destination == destination)
                {
                    Print(member);
                    count++;
                }
            }

            if (count == 0) Console.WriteLine("Нет рейсов в данном направлении");
        }
    }
}
