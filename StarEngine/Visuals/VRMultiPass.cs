using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StarEngine.Visuals
{
    public class VRMultiPass : VRenderer
    {
        public VRMultiPass()
        {

        }
        public override void Init()
        {
            Layers.Add(new VRLMultiPass());
        }
    }
}
