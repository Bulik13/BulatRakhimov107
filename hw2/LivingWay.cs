using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp3.hw2_LivingWay_
{
    class LivingWay
    {
        double cost;
        int minArenda;
        int maxArenda;
        bool isAdvanceNeed;

        void CheckIn() { }
        void CheckOut() { }

    }
    public enum RoomType
    {
        single,
        twin,
        family
    }

    public enum FoodSupply
    {
        breakfast,
        fullDay
    }

    class Hotel : LivingWay
    {
        public int roomNumber;
        public RoomType roomType;
        public FoodSupply foodSupply;
    }

    public enum TypeOfHousing
    {
        room,
        flat,
        house
    }

    class PrivateHouse : LivingWay
    {
        public TypeOfHousing typeOfHousing;
        public bool isCleaningIncluded;
        public bool isSecondKeysIncluded;
        public bool isInternetIncluded;
    }
}
