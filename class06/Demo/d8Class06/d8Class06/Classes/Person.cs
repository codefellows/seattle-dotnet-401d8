using d8Class06.Interfaces;
using System;
using System.Collections.Generic;
using System.Text;

namespace d8Class06.Classes
{
    abstract class Person : Human, IDrive
    {
        public string Name { get; set; }
        public int Age { get; set; }
        public int Height { get; set; }
        public bool License { get; set; }

        public Person(string name)
        {
            Name = name;
        }

        public Person()
        {

        }

        public virtual string Talk()
        {
            return "Blah, Blah, Blah";
        }

        public bool IsSleeping()
        {
            return true;
        }
        // No Code body allowed. Just method signature
        public abstract string Eat();

        public string FavoriteRadioStation()
        {
            return "The Cool station!";
        }

       
    }
}
