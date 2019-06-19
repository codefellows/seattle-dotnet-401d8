using d8Class06.Interfaces;
using System;
using System.Collections.Generic;
using System.Text;

namespace d8Class06.Classes
{
    // Clown is derived from Person
    class Clown : Person
    {
        public bool IsScary { get; set; } = false;
        public string ColorOfNose { get; set; }

        public string CreateBalloonAnimal(string animal)
        {
            return $"The animal {animal} has been created!";
        }

        public override string Eat()
        {
            return "Nom nom nom nom";
        }


        // Override the virtual method talk from the Person class
        public override string Talk()
        {
            return $"I say what i want!";
        }

        public void Drive(IDrivable vehivle)
        {
            vehivle.Start();
            vehivle.Accelerate();
            vehivle.Brake();
            vehivle.Stop();
        }
    }
}
