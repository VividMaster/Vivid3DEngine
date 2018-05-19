using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using StarEngine;
using StarEngine.App;
using StarEngine.Draw;
using StarEngine.FX;
using StarEngine.FXS;
using StarEngine.Input;
using StarEngine.Scene;
using StarEngine.Tex;
using StarEngine.Util;
using StarEngine.VFX;

using StarEngine.Reflect;
using System.Reflection;
using StarEngine.Archive;
using StarEngine.Lighting;
using StarEngine.PostProcess;
using StarEngine.Import;
using StarEngine.Material;
namespace ReboundGame
{
    public class ReboundApp : StarApp
    {
        public ReboundApp(int w, int h, bool full) : base("Rebound - Alpha", w, h, full)
        {

        }

        public override void InitApp()
        {
            AssImpImport.IPath = "Data\\3DTextures\\";
        }
        public override void DrawApp()
        {



        }

    }
}
