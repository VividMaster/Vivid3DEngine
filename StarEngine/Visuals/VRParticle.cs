﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StarEngine.Visuals
{
    public class VRParticle : VRenderer
    {

        public override void Init()
        {
            Layers.Add(new VRLParticle());
        }

    }
}
