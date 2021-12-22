using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace HomeWork.LastHWIn2021
{
    public struct FootballMatch : IComparable
    {
        public string Name;
        public DateTime Date;
        private int points;
        public int Points 
        {
            get { return points; } 
            set {
                    if (value >= 0) 
                        points = value;
                } 
        }
        public FootballMatch(string name, DateTime date, int points) : this()
        {
            Name = name;
            Date = date;
            Points = points;
        }
        public static FootballMatch[] ReadFromFile(string x)
        {
            string[] lines = File.ReadAllLines(x);
            List<FootballMatch> list = new List<FootballMatch>();
            foreach (var l in lines)
            {
                if (string.IsNullOrEmpty(x))
                    continue;
                var currentline = x.Split(' ');
                if (currentline.Length != 3)
                    continue;
                var date = currentline[1].Split('.');
                list.Add(new FootballMatch(currentline[0], new DateTime(ToInt(date[0]), ToInt(date[1]), ToInt(date[2]), ToInt(date[3]), ToInt(date[4]), 0), ToInt(currentline[2])));
                int ToInt(string a)
                {
                    return int.Parse(a);
                }
            }
            return list.ToArray();
        }
        public static void Winner(DateTime date1,DateTime date2, FootballMatch[] arr)
        {
            var list = arr.ToList();
            if (date1 > date2)
                (date1, date2) = (date2, date1);
            for (int i = 0; i < list.Count;i++)
            {
                if (list[i].Date < date1 || list[i].Date > date2)
                    list.Remove(list[i]);
            }
            list.Sort();
            Console.WriteLine(list[list.Count-1]);
        }
        public static FootballMatch[] Sort(FootballMatch[] matches)
        {
            FootballMatch temp;
            for (int i = 0; i < matches.Length-1;i++)
            {
                for (int j = i +1; j < matches.Length;j++)
                {
                    if (matches[i].points > matches[j].points)
                    {
                        temp = matches[i];
                        matches[i] = matches[j];
                        matches[j] = temp;
                    }
                }
            }
            return matches;
        }
        public int CompareTo(object? obj)
        {
            var obje = (FootballMatch)obj;
            if (obj == null) return -1;
            if (obj != null)
            {
                if (obje.points < this.points) return -1;
                else if (obje.points > this.points) return 1;
                else return 0;
            }
            throw new Exception("Nel'za sravnit;");
        }
    }
}
