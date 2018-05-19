using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using StarEngine.Logic;
namespace StarEngine.State
{

    public class StarState
    {

        public Logic.Logics Logics = new Logics(1000 / 60, false);
        public Logic.Logics Graphics = new Logics(1000 / 60, false);

        public string Name
        {
            get;
            set;
        }

        public bool Running
        {
            get;
            set;
        }

        public StarState(string name = "")
        {
            Name = name;
            Running = false;
        }

        public virtual void InitState()
        {

        }

        public virtual void StartState()
        {

        }

        public virtual void UpdateState()
        {

        }

        public virtual void DrawState()
        {

        }

        public virtual void StopState()
        {

        }

        public virtual void ResumeState()
        {

        }

        public void InternalUpdate()
        {
            Logics.SmartUpdate();
            Graphics.SmartUpdate();

        }


    }

}
