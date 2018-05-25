using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using StarEngine.Texture;
using StarEngine.Draw;
using OpenTK;
namespace StarEngine.Resonance.Forms
{
    public class WindowForm : UIForm
    {

        public VTex2D TitleImg = null;
        public VTex2D BodyImg = null;
        private ButtonForm resize;

        public bool LockedPos = false;
        public bool LockedSize = false;

        public WindowForm()
        {

            TitleImg = new VTex2D("Data\\UI\\Skin\\wintitle.png", LoadMethod.Single, true);
            BodyImg = new VTex2D("Data\\UI\\Skin\\windowbg.png", LoadMethod.Single, true);


            var title = new ButtonForm().Set(0, 0, W, 20, "");

            var body = new ImageForm().Set(0, 22, W, H - 24, "").SetImage(BodyImg);

             resize = (ButtonForm)new ButtonForm().Set(W - 14, H - 14, 14, 14, "X");

            void ResizeDrag(int x,int y)
            {
                if (LockedSize) return;
                Set(X, Y, W + x, H + y, Text);
                body.Set(0, 22, W, H - 24, "");
                resize.X = W - 14;
                resize.Y = H - 14;

            }

            resize.Drag = ResizeDrag;

            void DragFunc(int x,int y)
            {
                if (LockedPos) return;
                X = X + x;
                Y = Y + y;

            }

            title.Drag = DragFunc;

            Add(title);
            Add(body);
            Add(resize);

            void ChangedFunc()
            {

                title.Text = Text;
                title.W = W;
                title.H = 20;
                body.H = H - 26;
                body.W = W;
                resize.X = W - 14;
                resize.Y = H - 14;


            }

            Changed = ChangedFunc;

     

            void DrawFunc()
            {

                //DrawForm(TitleImg, 0, 0, W, 20);

            }

            Draw = DrawFunc;

        }

        public WindowForm NoResize()
        {

            Forms.Remove(resize);
            return this;

        }
    }
}
