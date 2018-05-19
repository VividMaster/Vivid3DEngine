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
namespace ReboundGame.States
{
    public class LogosState : StarState
    {

        public int LS = 0;
        public float LogoAlpha = 0.0f;
        public StarEngine.Texture.VTex2D LogoTex = null;
        public StarEngine.Texture.VTex2D PresTex = null;
        public StarEngine.Texture.VTex2D GameTex = null;
        public StarEngine.Sound.VSound ms;
        public override void InitState()
        {

            Console.WriteLine("Loading logo tex.");
            LogoTex = new StarEngine.Texture.VTex2D("Data\\2D\\Logo\\DarkArtLogo.png", LoadMethod.Single);
            PresTex = new VTex2D("Data\\2D\\Logo\\Presents.png", LoadMethod.Single);
            GameTex = new VTex2D("Data\\2D\\Logo\\ArenaLogo.png", LoadMethod.Single);
            Console.WriteLine("Loaded.");

            ms = StarSoundSys.Play2DFile("Data\\Music\\Logo\\LogoTheme1.wav");
            
            VPen.SetProj(0, 0, StarApp.W, StarApp.H);

            bool AlphaUp()
            {
                LogoAlpha = LogoAlpha + 0.015f;
                if (LogoAlpha > 1.0f) return true;
                return false;
            }

            int waitStart = 0;

            void WaitInit()
            {
                waitStart = Environment.TickCount;
            }

            bool WaitABit()
            {
                if (Environment.TickCount > waitStart + 2000)
                {
                    return true;
                }
                return false;
            }

            bool logoDone = false;
        
            bool AlphaDown()
            {
                LogoAlpha -= 0.01f;
                if (LogoAlpha < 0.0f)
                {
                    logoDone = true;
                    LogoAlpha = 0.0f;
                    return true;
                }
                return false;
            }

            void TestDo()
            {

            }

            void DoPresent()
            {
                LogoAlpha = 0.0f;
                PresentLogo = true;
          

            }

            void DoGame(){

                LogoAlpha = 0.0f;
                GameLogo = true;
            

            }

           
          void Done()
            {
                ms.Stop();
                ToMenu = true;
            }
        
            Logics.Flow(null,AlphaUp);
            Logics.Flow(WaitInit, WaitABit);
            Logics.Flow(null, AlphaDown,DoPresent);
            Logics.Flow(null, AlphaUp);
            Logics.Flow(WaitInit, WaitABit);
            Logics.Flow(null, AlphaDown, DoGame);
            Logics.Flow(null, AlphaUp);
            Logics.Flow(WaitInit, WaitABit);
            Logics.Flow(null, AlphaDown, Done);
  

            bool StateDone()
            {
                return logoDone;
            }

            void NextState()
            {
                ms.Stop();
                PresentLogo = true;
            }

            bool UnlessMusic()
            {
                return ms.Playing;
            }

            Logics.When(StateDone, NextState,UnlessMusic);


        }
        bool ReboundLogo = false;
        private bool PresentLogo = false;
        bool GameLogo = false;
        bool ToMenu = false;
        public override void UpdateState()
        {
            return;
            /*
            switch (LS)
            {
                case 0:
                    if (LogoAlpha < 1.0f)
                    {
                        LogoAlpha += 0.05f;
                    }
                    else
                    {

                        void Wait()
                        {
                            LS = 1;
                        }
                        In(200, Wait, true);
                    }
                    break;
                case 1:
                    void Change()
                    {
                        LS = 2;
                    }
                    In(2000, Change, true);
                    break;
                case 2:
                  //  LogoAlpha = 0;
                    LS = 3;

                    void FadeAway()
                    {
                        LogoAlpha -= 0.04f;
                    }

                    bool FadeDone()
                    {
                        return (LogoAlpha < 0.01f);
                    }

                    In(FadeAway, FadeDone);

                    break;
            }
            */
        }

        public override void DrawState()
        {

            bool RenderDarkLogo()
            {
                VPen.Rect(0, 0, StarApp.W, StarApp.H, LogoTex, new OpenTK.Vector4(LogoAlpha, LogoAlpha, LogoAlpha, LogoAlpha));
                return PresentLogo;
            }

            bool RenderPresLogo()
            {
                VPen.Rect(0, 0, StarApp.W, StarApp.H, this.PresTex, new OpenTK.Vector4(LogoAlpha, LogoAlpha, LogoAlpha, LogoAlpha));
                return GameLogo;
            }

            bool RenderGameLogo()
            {
                //Console.WriteLine("Rendering!"); 

                VPen.Rect(0, 0, StarApp.W, StarApp.H, GameTex, new OpenTK.Vector4(LogoAlpha, LogoAlpha, LogoAlpha, LogoAlpha));
                return ToMenu;
            }

            void DoMenu()
            {

          
                LogoAlpha = 0.0f;
                ms.Stop();

                StarApp.PushState(new MainMenuState());


            }


            bool CheckInput()
            {
                if (ToMenu) return true;
                if (VInput.MB[0])
                {
                    return true;
                }
                if (VInput.KeyIn(OpenTK.Input.Key.Enter) || VInput.KeyIn(OpenTK.Input.Key.Space))
                {
                    return true;
                }
                return false;
            }

            //Logics.Do(TestDo);

            Graphics.When(CheckInput, DoMenu, null);

            Graphics.Flow(null, RenderDarkLogo);
            Graphics.Flow(null, RenderPresLogo);
            Graphics.Flow(null, RenderGameLogo);

            Graphics.SmartUpdate();

            return;

            void DarkLogo()
            {
                VPen.Rect(0, 0, StarApp.W, StarApp.H, LogoTex, new OpenTK.Vector4(LogoAlpha, LogoAlpha, LogoAlpha, LogoAlpha));
            }

            bool DarkLogoUntil()
            {

              

                return PresentLogo;

            }


            void PresLogo()
            {
                VPen.Rect(0, 0, StarApp.W, StarApp.H, LogoTex, new OpenTK.Vector4(LogoAlpha, LogoAlpha, LogoAlpha, LogoAlpha));
            }


            bool PresentLogoUntil(){

                return ReboundLogo;

            }

            void DoPresent()
            {

                Graphics.Do(PresLogo, PresentLogoUntil);

            }




            Graphics.Do(DarkLogo, DarkLogoUntil,DoPresent);

            Graphics.InternalUpdate();


        }
    

    }
}
