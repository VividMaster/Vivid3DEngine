using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using StarEngine.Scene;
namespace StarEngine.Import
{
    public class Importer
    {
        public string Ext = "";
        public virtual GraphNode3D LoadNode(string path)
        {
            return null;
        }
        public virtual SceneGraph3D LoadScene(string path)
        {

            return null;
        }
    }
}
