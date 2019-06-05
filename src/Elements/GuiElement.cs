﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Maquina.Elements
{
    public abstract class GuiElement : GenericElement
    {
        // Constructor
        protected GuiElement(string name) : base (name)
        {
            ControlAlignment = ControlAlignment.Center;
        }

        public ControlAlignment ControlAlignment { get; set; }
        public override string ID
        {
            get { return "GENERIC_GUI"; }
        }
    }
}
