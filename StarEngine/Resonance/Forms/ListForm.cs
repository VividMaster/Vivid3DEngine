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
    public class ListForm : UIForm
    {

        public ListForm()
        {

            void DrawFunc()
            {

                DrawFormSolid(new Vector4(1, 1, 1, 1));

            }

            Draw = DrawFunc;


        }



    }
}
