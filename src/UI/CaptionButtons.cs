using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Maquina.UI
{
    [Flags]
    public enum CaptionButtons
    {
        HasClose =          1 << 0, // 1 or 00000001
        HasCollapse =       1 << 1, // 2 or 00000010
        HasSetTransparent = 1 << 2, // 4 or 00000100

        None = 0,
        Default = HasClose | HasCollapse | HasSetTransparent,
    }
}
