using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp3
{
    public interface IPlayer
    {
        public void Play();
    }

    public class FootballPlayer : IPlayer
    {
        public string FIO;
        public int Age
        {
            get { return Age; }
            set
            {
                if (value < 0)
                    throw new Exception();
                else
                    Age = value;
            }
        }
        public void Play()
        {
            Console.WriteLine($"{FIO} играет на поле");
        }
    }
    public class Musician : IPlayer
    {
        public string FIO;
        public Instrument Instrument;
        public void Play()
        {
            Console.WriteLine($"{FIO} играет на {Instrument}");
        }
    }
    public enum Instrument
    {
        Piano,
        Violin,
        Guitar,
        Drum
    }
    public class PlayerManager
    {
        public void Test(IPlayer[] x)

    }
}
