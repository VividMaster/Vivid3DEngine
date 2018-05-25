﻿using System;
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
namespace ModelEditor
{
    class Program
    {
        static void Main(string[] args)
        {

            var startScreen = new States.StartScreen();

            StarApp.InitState = startScreen;

            var app = new ModelEditorApp(800, 600, false);

            app.Run(60, 60);

        }
    }
}
