using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Vivid3D.Texture;
using Vivid3D.Draw;
using OpenTK;
using Vivid3D.App;
namespace Vivid3D.Resonance.Forms
{
    public class RequestFileForm : WindowForm 
    {

        public RequestFileForm(string title="")
        {
            if (title == "") title = "Select file";
            Set(VividApp.W / 2 - 200, VividApp.H / 2 - 300, 400, 600, title);

            var files = new ListForm().Set(10, 40, 360, 350, "");
            Add(files);

        }

    }
}
