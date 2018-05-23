using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using OpenTK;
using StarEngine.Texture;
namespace StarEngine.ParticleSystem
{
    public class Particle
    {
        public float Theta = 0;
        public Vector3 Pos = Vector3.Zero;
        public Vector3 Inertia = Vector3.Zero;
        public float Alpha = 1.0f;
        public float Life = 1.0f;
        public VTex2D Tex = null;
    }
}
