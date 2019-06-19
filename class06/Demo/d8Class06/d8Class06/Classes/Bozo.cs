using System;
using System.Collections.Generic;
using System.Text;

namespace d8Class06.Classes
{
    // Bozo is derived from Clown (base)
    class Bozo : Clown
    {
        // Takes the behavior of Talk from Clown
        public override string Talk()
        {
            return base.Talk();
        }
    }
}
