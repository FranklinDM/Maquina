using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Maquina.UI
{
    [Flags]
    public enum WindowStates
    {
        IsFocused =           1 << 0, //  1 or 00000001
        IsMoving =            1 << 1, //  2 or 00000010
        IsMaximized =         1 << 2, //  4 or 00000100
        IsHidden =            1 << 3, //  8 or 00001000

        None = 0,
    }
}
