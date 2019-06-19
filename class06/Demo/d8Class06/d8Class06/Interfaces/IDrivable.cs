using System;
using System.Collections.Generic;
using System.Text;

namespace d8Class06.Interfaces
{
    interface IDrivable
    {
        bool Start();

        string Stop();

        string Brake();

        string Accelerate();

        string Park();
    }
}
