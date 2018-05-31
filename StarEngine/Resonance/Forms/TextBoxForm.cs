using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Vivid3D.Texture;
using Vivid3D.Draw;
using OpenTK;

namespace Vivid3D.Resonance.Forms
{
    public class TextBoxForm : UIForm
    {
        public int ClaretI = 0;
        public bool Active = false;
        public int StartI = 0;
        public bool ShowClaret = false;
        public int NextClaret;
        public TextBoxForm()
        {

       
            void UpdateFunc()
            {
                if (Active)
                {
                    if (Environment.TickCount > NextClaret)
                    {
                        ShowClaret = ShowClaret ? false : true;
                        NextClaret =Environment.TickCount + 450;
                        Console.WriteLine("Claret:" + ShowClaret.ToString());
                    }
                }
               
            }

            Update = UpdateFunc;

            void ActiveFunc()
            {
                Active = true;
            }

            void DeactiveFunc()
            {
                Active = false;
            }

            Deactivate = DeactiveFunc;
            Activate = ActiveFunc;

            void DrawFunc()
            {

                DrawFormSolid(Col);
                int tw = 0;
                int ii = 0;
                for (int i = StartI; i < Text.Length; i++)
                {
                    tw = UI.Font.Width(Text.Substring(StartI, i+1));
                    if (tw > W - 10) break;
                    ii++;
                }

                string dis=Text.Substring(StartI, ii);

                DrawText(dis, 5, 0, new Vector4(0.2f, 0.2f, 0.2f, 0.9f));

                if(ShowClaret)
                {
                   // Console.WriteLine("Claret!");
                    DrawFormSolid(new Vector4(0.2f, 0.2f, 0.2f, 0.8f), ClaretI * 8+4,0,5, 20);
                }

            }

            Draw = DrawFunc;

        }

    }
}
