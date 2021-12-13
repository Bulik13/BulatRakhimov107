using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HomeWork.HW_abstarctclass_
{
    public abstract class DecorationObjectcs
    {
        public double Area { get; set; }
        public int Socket { get; set; }
        public DecorationObjectcs(double area,int socket)
        {
            Area = area;
            Socket = socket;
        }
    }
    public class ChristmassTree : DecorationObjectcs
    {
        public double Height;
        public ChristmassTree(double area,int socket,double height)
            : base(area,socket)
        {
            Height = height;
        }
    }
    public class Showcase : DecorationObjectcs
    {
        public Showcase(double area, int socket)
            : base(area, socket) { }
    }
    public abstract class Decoration
    {
        public double AreaDec;
        public bool IsSocketNeed;
        public Decoration(double area,bool socket)
        {
            IsSocketNeed = socket;
            AreaDec = area;
        }
    }
    public class Garland : Decoration
    {
        public int NumberOfColor;
        public int NumberOfMode;
        public Garland(double area,bool socket, int color,int mode)
            :base(area,socket)
        {
            NumberOfColor = color;
            NumberOfMode = mode;
        }
    }
    public class Toys : Decoration
    {
        public double Weight;
        public bool Fragility;
        public Toys(double area,bool socket,double weight,bool fragility)
            :base (area,socket)
        {
            Weight = weight;
            Fragility = fragility;
        }
    }

    public class Decorating
    {
        public void DecoratingObj(DecorationObjectcs x, Garland[] garland, Toys[] toy)
        {
            int x1 = 0;
            int x2 = 0;
            int i = 0;
            while (x.Area > 0 && x.Socket > 0 && i <= garland.Length && x.Area > garland[i].AreaDec)
            {
                x.Area -= garland[i].AreaDec;
                x.Socket--;
                i++;
                x1++;
            }
            i = 0;
            while (x.Area > 0 &&  i <= toy.Length && x.Area > toy[i].AreaDec)
            {
                x.Area -= toy[i].AreaDec;
                i++;
                x2++;
            }

            Console.WriteLine($"Объект {x} украсили {x1} гирляндами и {x2} игрушками." +
                $" Оставшаяся площадь {x.Area}. Оставшихся розеток {x.Socket}");
        }
    }
}
