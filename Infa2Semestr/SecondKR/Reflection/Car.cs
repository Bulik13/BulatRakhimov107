using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Reflection;

namespace Infa2Semestr.SecondKR.Reflection
{
    class Car
    {
        public readonly string Name;
        public readonly int Price;

        public Car(string name, int price)
        {
            Name = name;
            Price = price;
        }

        public void Print()
        {
            Console.WriteLine(Name + " " + Price);
        }
    }

    class Program
    {
        static object CreateMyObject(Type myType, Type[] parameters, object[] values)
        {

            ConstructorInfo info = myType.GetConstructor(parameters);


            object myObj = info.Invoke(values);


            return myObj;
        }

        static void Main(string[] args)
        {
            Type myClass = typeof(Car);
            Type[] parameters = new Type[] { typeof(string), typeof(int) };
            object[] values = new object[] { "Ford", 400000 };
            object obj1 = CreateMyObject(myClass, parameters, values);
            ((Car)obj1).Print();
        }
    }
}
