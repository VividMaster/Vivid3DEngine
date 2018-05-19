using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using StarEngine.Data;
using StarEngine.Effect;
namespace StarEngine.Visuals
{
    public class VRLMultiPass : VRenderLayer
    {
        public EMultiPass3D fx = null;
        public override void Init()
        {
            fx = new EMultiPass3D();
        }
        public override void Render(VMesh m, VVisualizer v)
        {

            m.Mat.Bind();
            Lighting.GraphLight3D.Active.ShadowFB.Cube.Bind(2);
            fx.Bind();
            v.SetMesh(m);
            v.Bind();
            v.Visualize();
            v.Release();
            fx.Release();
            Lighting.GraphLight3D.Active.ShadowFB.Cube.Release(2);
            m.Mat.Release();
        }
    }
}
