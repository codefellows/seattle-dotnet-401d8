using System;
using System.Collections.Generic;
using System.Text;

namespace d8Class06.Classes
{
    // Laywer is derived from Person
    // Therefore, Lawyer IS A person
    class Lawyer : Person
    {
        public string Specialization { get; set; }

        public override string Eat()
        {
            throw new NotImplementedException();
        }

        public sealed override string Talk()
        {
            return "OBJECTION!!!";
        }


    }
}
