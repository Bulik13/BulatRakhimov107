using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace HomeWork.LastHWIn2021
{
    public class DataTime
    {
        public void TextTimeData()
        {
            File.WriteAllText(@"C:\File1.txt", $"{DateTime.Now}");
            File.WriteAllText(@"C:\File2.txt", $"{DateTime.Now}");
            File.WriteAllText(@"C:\File3.txt", $"{DateTime.Now}");
            var array = Directory.GetFiles(@"C:\");
            var max = array[0];
            foreach (var x in array) 
            {
                if (File.GetLastWriteTime(max) < File.GetLastWriteTime(x))
                    max = x; 
            }
            Console.WriteLine(File.GetLastWriteTime(max));
        }
    }
}
