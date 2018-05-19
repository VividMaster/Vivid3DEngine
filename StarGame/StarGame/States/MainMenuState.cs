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
using StarEngine.Resonance.Forms;
namespace ReboundGame.States
{
    public class MainMenuState : StarState
    {


        public UI UI = null;
        public ImageForm BG;
        private VTex2D MenuBG;
        public VSound Music;

        public GraphCam3D cam1 = null;
        public SceneGraph3D scene3d = null;
        public GraphNode3D ent1 = null;
        public GraphLight3D light1 = null;
        public PostProcessRender ppRen;

        public override void InitState()
        {



            MenuBG = new VTex2D("Data\\2D\\Backgrounds\\MainMenu\\menubg.jpg", LoadMethod.Single, false);

            Music = StarSoundSys.Play2DFile("Data\\Music\\Menu\\MainMenu\\MenuTheme1.mp3");

            UI = new UI();



            UI.Root = new ImageForm().Set(0, 0, StarEngine.App.StarApp.W, StarEngine.App.StarApp.H,"ImageForm").SetImage(MenuBG);

            WindowForm win1 = (WindowForm)(new WindowForm().Set(40, 100, 260, 400, "Rebound Arena"));

            win1.NoResize();


            

            UI.Root.Add(win1);


            win1.Add(new ButtonForm().Set(20, 30, 200, 25, "Versus AI"));
            win1.Add(new ButtonForm().Set(20,60,200,25,"Multiplayer"));


            var test = win1.Forms[0];




            test.Click = (b) =>
            {

                Console.WriteLine("Yep!");

            };

            ppRen = new StarEngine.PostProcess.PostProcessRender(512, 512);
            Console.WriteLine("Creating 3D Scene graph.");
            scene3d = new SceneGraph3D();

            ppRen.Scene = scene3d;

            Console.WriteLine("Importing mesh.");
            ent1 = Import.ImportNode("Data\\3D\\Logo\\Menu\\Rebound1.3ds");
            Console.WriteLine("Set up.");
            var mat1 = new Material3D();
            //Console.WriteLine("Loading texture.");
            mat1.TCol = new Tex2D("Data\\3D\\brick_2.png");
            mat1.TNorm = new Tex2D("Data\\3D\\brick_2_NRM.png");
            Console.WriteLine("Loaded.");


            var ge = ent1 as GraphEntity3D;

            ge.SetMat(mat1);
            cam1 = new GraphCam3D();
            cam1.LocalPos = new OpenTK.Vector3(0, 80, 450);


            cam1.LookAt(ent1);




            light1 = new StarEngine.Lighting.GraphLight3D();
            var l2 = new StarEngine.Lighting.GraphLight3D();
            var l3 = new StarEngine.Lighting.GraphLight3D();

            l3.LocalPos = new OpenTK.Vector3(300, 80, 450);
            l3.Diff = new OpenTK.Vector3(0, 1, 2);

            l2.LocalPos = new OpenTK.Vector3(5, 200, 500);
            l2.Diff = new OpenTK.Vector3(2, 2, 1);


            light1.LocalPos = new OpenTK.Vector3(0, 80, 350);

          //  ent1.Rot(new OpenTK.Vector3(0, 45, 0), Space.Local);



            scene3d.Add(ent1);

           scene3d.Add(l2);

            scene3d.Add(l3);

            scene3d.Add(light1);

            scene3d.Add(cam1);

            light1.Diff = new OpenTK.Vector3(3, 3, 3);


        }

        public override void UpdateState()
        {
            Console.WriteLine("Update");
            UI.Update();

        }
        public bool firstd = true;
        public int lx, ly;
        public override void DrawState()
        {
            Console.WriteLine("Draw");
            /*
            int move = 8;
            if (VInput.KeyIn(OpenTK.Input.Key.ShiftLeft))
            {
                move = 12;
            }
            if (VInput.KeyIn(OpenTK.Input.Key.W))
            {

                cam1.Move(new OpenTK.Vector3(0, 0, -move), Space.Local);

            }
            if (VInput.KeyIn(OpenTK.Input.Key.A))
            {
                cam1.Move(new OpenTK.Vector3(-move, 0, 0), Space.Local);
            }

            if (VInput.KeyIn(OpenTK.Input.Key.D))
            {
                cam1.Move(new OpenTK.Vector3(move, 0, 0), Space.Local);
            }

            if (VInput.KeyIn(OpenTK.Input.Key.S))
            {
                cam1.Move(new OpenTK.Vector3(0, 0, move), Space.Local);
            }
            if (VInput.MB[0])
            {
                light1.LocalPos = cam1.LocalPos;
            }
            int xd, yd;
            if (firstd)
            {
                lx = VInput.MX;
                ly = VInput.MY;
                firstd = false;
            }
            xd = VInput.MX - lx;
            yd = VInput.MY - ly;
            lx = VInput.MX;
            ly = VInput.MY;
            cam1.Turn(new OpenTK.Vector3(yd, xd, 0), Space.Local);
            */
            //scene3d.Render();

            UI.Render();


        }


    }
}
