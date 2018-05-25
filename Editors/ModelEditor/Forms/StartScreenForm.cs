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
using StarEngine.Sound;
using StarEngine.Reflect;
using System.Reflection;
using StarEngine.Archive;
using StarEngine.Lighting;
using StarEngine.PostProcess;
using StarEngine.Import;
using StarEngine.Material;
using StarEngine.State;
using StarEngine.Texture;
using StarEngine.Logic;
using StarEngine.Resonance;
using StarEngine.App;
using OpenTK;
using StarEngine.ParticleSystem;
using StarEngine.PostProcess.Processes;
using StarEngine.Resonance.Forms;
using StarEngine.Physics;
namespace ModelEditor.Forms
{
    public class StartScreenForm : UIForm
    {

        public override void DesignUI()
        {

            WindowForm win = new WindowForm().Set(0, 0, StarApp.W, StarApp.H, "Vivid3D - Model Editor - Start Screen") as WindowForm;

            win.LockedPos = true;
            win.LockedSize = true;

            Forms.Add(win);

        }

    }
}
