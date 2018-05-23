using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using OpenTK;
using StarEngine.Texture;
namespace StarEngine.ParticleSystem
{
    public class ParticleEmitter
    {
        public List<Particle> Particles = new List<Particle>();
        public void Emit(Particle bp, Vector3 pos, Vector3 inertia)
        {

            var np = new Particle();
            np.Tex = bp.Tex;
            np.Life = bp.Life;
            np.Alpha = bp.Alpha;
            np.Pos = pos;
            np.Inertia = inertia;
            Particles.Add(np);


        }

        public void Render()
        {

            List<Particle>[] chains = Sort();
            Console.WriteLine("Chains:" + chains.Length);
            foreach(var pl in chains)
            {
                Console.WriteLine("Chain:" + pl.Count);
            }

        }
        public void Update()
        {
            foreach(var p in Particles)
            {

                p.Pos = p.Pos + p.Inertia;


            }
        }
        private List<Particle>[] Sort()
        {
            Dictionary<VTex2D, List<Particle>> li = new Dictionary<VTex2D, List<Particle>>();
            List<VTex2D> up = new List<VTex2D>();
            foreach (var p in Particles)
            {
                if (up.Contains(p.Tex))
                {

                }
                else
                {
                    up.Add(p.Tex);
                    li.Add(p.Tex, new List<Particle>());
                }
            }

            foreach (var ut in up)
            {
                foreach(var p in Particles)
                {
                    if(p.Tex == ut)
                    {
                        li[p.Tex].Add(p);
                    }
                }
            }

            List<Particle>[] res = new List<Particle>[up.Count];
            for(int i = 0; i < up.Count; i++)
            {
                res[i] = new List<Particle>();
            }
            int ai = 0;
            foreach(var key in li.Keys)
            {
                foreach(var p in li[key])
                {
                    res[ai].Add(p);
                }
                ai++;
            }

            return res;



        }
    }
}
