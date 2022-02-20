using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;


namespace Infa2Semestr
{
    class Program
    {
        static void Main()
        {
            var list = new CustomList();
            list.WriteToConsole();

            var list1 = new CustomList(5);
            list1.WriteToConsole();

            list.Add(1);
            list.WriteToConsole();
            list.Add(2);
            list.WriteToConsole();
            list.Add(3);
            list.WriteToConsole();
            list.AddToHead(0);
            list.WriteToConsole();

            list.Add(5, 1);
            list.WriteToConsole();
            list.Add(11, 3);
            list.WriteToConsole();
            
            list.DeleteHead();
            list.WriteToConsole();
            list.DeleteTail();
            list.WriteToConsole();
            list.Delete(2);
            list.WriteToConsole();
        }
    }
}
