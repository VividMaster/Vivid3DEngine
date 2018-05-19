using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using StarEngine.Data;
using StarEngine.Visuals;
using OpenTK;
using OpenTK.Graphics.OpenGL4;
using StarEngine.Material;
namespace StarEngine.Scene
{
    public class GraphEntity3D : GraphNode3D
    {
        public VRenderer Renderer = null;
        public List<VMesh> Meshes = new List<VMesh>();
        public override void Init()
        {
            Renderer = new VRMultiPass();
        }
        public void AddMesh(VMesh mesh)
        {
            Meshes.Add(mesh);
        }
        public void Clean()
        {
            Meshes = new List<VMesh>();
            Renderer = null;
        }
        public void SetMat(Material3D mat)
        {
            foreach(var m in Meshes)
            {
                m.Mat = mat;
            }
            foreach(var n in Sub)
            {
                if(n is GraphEntity3D)
                {
                    var ge = n as GraphEntity3D;
                    ge.SetMat(mat);
                }
            }
        }
        public override void PresentDepth(GraphCam3D c)
        {
            SetMats(c);
            Bind();
            PreRender();
            RenderDepth();
            PostRender();
            Release();
            foreach (var s in Sub)
            {
                s.PresentDepth(c);
            }
        }
        public override void Present(GraphCam3D c)
        {
            //  GL.MatrixMode(MatrixMode.Projection);
            // GL.LoadMatrix(ref c.ProjMat);
            SetMats(c);
            Bind();
            PreRender();
            Render();
            PostRender();
            Release();
            foreach (var s in Sub)
            {
                s.Present(c);
            }
        }

        private void SetMats(GraphCam3D c)
        {
            Effect.FXG.Proj = c.ProjMat;
            Effect.FXG.Cam = c;
            // GL.MatrixMode(MatrixMode.Modelview);
            Matrix4 mm = Matrix4.Identity;
            // mm = c.CamWorld;
            //mm = mm * Matrix4.Invert(Matrix4.CreateTranslation(c.WorldPos));


            mm = World * mm;
            var wp = WorldPos;
            mm = Matrix4.CreateTranslation(wp) * mm;
            //GL.LoadMatrix(ref mm);
            Effect.FXG.Local = mm;
        }

        /// <summary>
        /// To be called AFTER data asscoiation.
        /// </summary>

        public virtual void Bind()
        {

        }
        public virtual void PreRender()
        {
          
        }
        public virtual void RenderDepth()
        {
            Effect.FXG.Ent = this;
            foreach (var m in Meshes)
            {
                Effect.FXG.Mesh = m;
                Renderer.RenderDepth(m);
            }
        }
        public virtual void Render()
        {
            Effect.FXG.Ent = this;
            foreach(var m in Meshes)
            {
                Effect.FXG.Mesh = m;
                Renderer.Render(m);
            }
          
        }
        public virtual void PostRender()
        {

        }
        public virtual void Release()
        {

        }
    }
}
