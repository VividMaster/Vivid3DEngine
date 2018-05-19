using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using StarEngine.Resonance;
using StarEngine.Texture;
namespace StarEngine.Resonance.Forms
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
