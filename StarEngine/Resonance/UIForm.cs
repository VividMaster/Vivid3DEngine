using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Vivid3D.Texture;
using Vivid3D.Draw;
using OpenTK;
using Vivid3D.Logic;
using Vivid3D.Font;
namespace Vivid3D.Resonance
{
    public delegate void Draw();
    public delegate void Update();
    public delegate void MouseEnter();
    public delegate void MouseLeave();
    public delegate void MouseMove(int x,int y,int mx,int my);
    public delegate void MouseDown(int but);
    public delegate void MouseUp(int but);
    public delegate void MousePressed(int but);
    public delegate void FormLogic();
    public delegate void Click(int b);
    public delegate void Drag(int x, int y);
    public delegate void ChangedInfo();
    public class UIForm
    {

        public Logics Logics = new Logics();
        public Logics Graphics = new Logics();

        public Vector4 Col = new Vector4(1, 1, 1, 0.7f);

        public ChangedInfo Changed = null;
        public Draw Draw=null;
        public Update Update=null;
        public MouseEnter MouseEnter = null;
        public MouseLeave MouseLeave = null;
        public MouseMove MouseMove = null;
        public MouseDown MouseDown = null;
        public MouseUp MouseUp = null;
        public MousePressed MousePressed = null;
        public FormLogic FormLogic = null;
        public Click Click = null;
        public Drag Drag = null;

        public VTex2D CoreTex = null;

        public int X = 0, Y = 0;
        public int W = 0, H = 0;
        public string Text = "";

        public UIForm Root = null;
        public List<UIForm> Forms = new List<UIForm>();

        public UIForm Add(UIForm form)
        {
            Forms.Add(form);
            form.Root = this;
            return form;
        }

        public int GX
        {
            get
            {
                int x = 0;
                if (Root != null)
                {
                    x = x + Root.GX;
                }
                x = x + X;
                return x;
            }
        }

        public int GY
        {
            get
            {
                int y = 0;
                if (Root != null)
                {
                    y = y + Root.GY;
                }
                y = y + Y;
                return y;
            }
        }

        public virtual void DesignUI()
        {

        }

        public bool InBounds(int x,int y)
        {

            if(x>=GX && y>=GY && x<=(GX+W) && y <= (GY + H))
            {
                return true;
            }
            return false;

        }
        public void DrawForm(VTex2D tex, int x = 0, int y = 0, int w = -1, int h = -1)
        {

            VPen.BlendMod = VBlend.Alpha;

            int dw = W;
            int dh = H;

            if (w != -1)
            {
                dw = w;
                dh = h;
            }

            VPen.Rect(GX + x, GY + y, dw, dh,tex, Col);

        }
        public void DrawForm(VTex2D tex,Vector4 col, int x = 0, int y = 0, int w = -1,int h=-1)
        {

            VPen.BlendMod = VBlend.Alpha;

            int dw = W;
            int dh = H;

            if (w != -1)
            {
                dw = w;
                dh = h;
            }

            VPen.Rect(GX+x, GY+y, dw, dh, tex, col);

        }

        public void DrawText(string txt,int x,int y)
        {

            VFontRenderer.Draw(UI.Font, txt, GX+x, GY+y);

        }

        public UIForm Set(int x,int y,int w,int h,string text = "")
        {
            X = x;
            Y = y;
            W = w;
            H = h;
            Text = text;
            Changed?.Invoke();
            return this;
        }

        public UIForm()
        {
            DesignUI();
        }

        public UIForm SetImage(VTex2D tex)
        {
            CoreTex = tex;
            return this;
        }
    }


}
