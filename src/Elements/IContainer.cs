﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Maquina.Elements
{
    public interface IContainer
    {
        EventDictionary<string, GenericElement> Children { get; set; }
        Orientation Orientation { get; set; }
    }
}