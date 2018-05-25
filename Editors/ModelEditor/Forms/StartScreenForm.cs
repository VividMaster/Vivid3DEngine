﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Vivid3D;
using Vivid3D.App;
using Vivid3D.Draw;
using Vivid3D.FX;
using Vivid3D.FXS;
using Vivid3D.Input;
using Vivid3D.Scene;
using Vivid3D.Tex;
using Vivid3D.Util;
using Vivid3D.VFX;
using Vivid3D.Sound;
using Vivid3D.Reflect;
using System.Reflection;
using Vivid3D.Archive;
using Vivid3D.Lighting;
using Vivid3D.PostProcess;
using Vivid3D.Import;
using Vivid3D.Material;
using Vivid3D.State;
using Vivid3D.Texture;
using Vivid3D.Logic;
using Vivid3D.Resonance;
using Vivid3D.App;
using OpenTK;
using Vivid3D.ParticleSystem;
using Vivid3D.PostProcess.Processes;
using Vivid3D.Resonance.Forms;
using Vivid3D.Physics;
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
