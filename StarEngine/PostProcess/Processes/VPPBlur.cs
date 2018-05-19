using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using StarEngine.Effect;
using StarEngine.Texture;
namespace StarEngine.PostProcess.Processes
{
    public class VPPBlur : VPostProcess
    {
        public VEBlur BFX = null;
        public override void Init()
        {
            BFX = new VEBlur();
        }
        public override void Bind(VTex2D bb)
        {

            bb.Bind(0);
            BFX.Bind();

        }
        public override void Render(VTex2D bb)
        {
            DrawQuad();
        }
        public override void Release(VTex2D bb)
        {
            BFX.Release();
            bb.Release(0);
        }
    }
    public class VEBlur : Effect3D
    {
        public float Blur = 0.5f;
        public VEBlur() : base("","blurVS.txt","blurFS.txt")
        {

        }
        public override void SetPars()
        {   
            SetTex("tR", 0);
            SetFloat("blur", Blur);
        }
    }
}
