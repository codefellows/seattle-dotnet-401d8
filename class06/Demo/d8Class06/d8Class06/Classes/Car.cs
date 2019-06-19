using d8Class06.Interfaces;
using System;
using System.Collections.Generic;
using System.Text;

namespace d8Class06.Classes
{
    class Car : Vehicle, IDrivable
    {
        public string Accelerate()
        {
            Console.WriteLine("FASTER");
            return "FASTER!";

        }

        public string Brake()
        {
            Console.WriteLine("BRAKE!");

            return "STOOOOPPP BRAKE!";
        }

        public string Park()
        {
            Console.WriteLine("Park");

            return "I'm Parked!";
        }

        public bool Start()
        {
            Console.WriteLine("START");

            return true;
        }

        public string Stop()
        {
            Console.WriteLine("Stop!");

            return "I'm Stopping";
        }
    }
}
