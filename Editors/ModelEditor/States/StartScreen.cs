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
using StarEngine.State;
using ModelEditor.Forms;
namespace ModelEditor.States
{
    public class StartScreen : StarState 
    {

        public override void InitState()
        {

            InitUI();

            SUI.Root = new StartScreenForm().Set(0, 0, StarApp.W, StarApp.H);
            

        }

        public override void UpdateState()
        {

            SUI.Update();

        }


        public override void DrawState()
        {

            SUI.Render();

        }

    }
}
