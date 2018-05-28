using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Vivid3D.Texture;
using Vivid3D.Draw;
using OpenTK;
using Vivid3D.App;
namespace Vivid3D.Resonance.Forms
{
    public class ItemForm : UIForm
    {
        public VTex2D Pic = null;
        public bool Render = true;
         public ItemForm()
        {

            void DrawFunc()
            {
                if (!Render) return;
                if (Pic != null)
                {

                    DrawForm(Pic, 0, 0, 28, 20);
                    DrawText(Text, 38, 0);
                }
                else
                {
                    DrawText(Text, 0, 0);
                }
            }

            void DoubleClickFunc(int b)
            {
                Console.WriteLine("DoubleClicked:" + Text);
            }

            Draw = DrawFunc;

        }

    }
}
