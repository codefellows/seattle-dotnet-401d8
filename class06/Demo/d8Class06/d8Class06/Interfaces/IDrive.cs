using System;
using System.Collections.Generic;
using System.Text;

namespace d8Class06.Interfaces
{
    interface IDrive
    {
        bool License { get; set; }

        string FavoriteRadioStation();
    }
}
