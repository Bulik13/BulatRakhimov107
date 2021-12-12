using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HomeWork
{
    public interface IPlayer
    {
        public void Play();
    }
    public class FootballPlayer : IPlayer
    {
        public string FIO;
        public int Age
        { get; set; }
        public FootballPlayer(string fio, int age)
        {
            FIO = fio;
            Age = age;
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
        public Musician(string fio, Instrument i)
        {
            FIO = fio;
            Instrument = i;
        }
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
        {
            foreach (var player in x)
            {
                if (player is Musician)
                {
                    if (((Musician)player).Instrument == Instrument.Violin)
                        player.Play();
                }
                if (player is FootballPlayer)
                {
                    if (((FootballPlayer)player).Age < 20)
                        player.Play();
                }
            }
        }
    }
}
