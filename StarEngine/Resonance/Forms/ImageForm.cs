using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Vivid3D.Resonance;
using Vivid3D.Texture;
namespace Vivid3D.Resonance.Forms
{

    public class ImageForm : UIForm
    {

        public ImageForm()
        {

            
            void DrawFunc()
            {
                DrawForm(CoreTex);
            }

            Draw = DrawFunc;

        }

    }
}
