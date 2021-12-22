using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HomeWork.LastHWIn2021
{
    public struct Train : IComparable
    {
        public string Destination;
        public int TrainNumb;
        public string DepartureTime;

        public Train(string destination, int trainNumber, string departureTime)
        {
            Destination = destination;
            TrainNumb = trainNumber;
            DepartureTime = departureTime;
        }
        public static Train[] AddToArr()
        {
            Console.WriteLine("Введодите данные о каждом рейсе");
            Train[] Arr = new Train[8];
            for (int i = 0; i < 8; i++) 
            {
                var strings = Console.ReadLine().Split(' ');
                Arr[i] = new Train
                    (strings[0], CheckingNumb(strings[1]), strings[2]);

            }
            Console.WriteLine(Arr.Length);
            return Arr;
        }
        static int CheckingNumb(string str)  
        {
            int number = 0;
            while (!Int32.TryParse(str, out number))
            {
                Console.WriteLine("Ввели некорректноне значение, введите новое");
                str = Console.ReadLine();
            }
            return number;
        }
        public int CompareTo(object? obj)
        {
            var object1 = (Train)obj;
            if (obj == null) return -1;
            if (obj != null)
            {
                if (object1.TrainNumb < this.TrainNumb) return 1;
                else if (object1.TrainNumb > this.TrainNumb) return -1;
                else return 0;
            }

            throw new Exception("Невозможно сравнить значения");
        }
        public static void Print(Train member)
        {
            Console.WriteLine($"Поезд номер {member.TrainNumb} отправляется в {member.Destination} в пункт назначения {member.DepartureTime}");
        }
        public static void Print(Train[] arr)
        {
            foreach (Train member in arr) Print(member);
        }

        public static void Displaying(Train[] arr, string destination)
        {
            int count = 0;
            foreach (Train member in arr)
            {
                if (member.TrainNumb == CheckingNumb(destination))
                {
                    Print(member);
                    count++;
                }
            }

            if (count == 0) Console.WriteLine("Нет рейсов в это время");
        }
    }
}
