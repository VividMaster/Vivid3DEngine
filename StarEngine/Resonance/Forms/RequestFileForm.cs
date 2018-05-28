using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Vivid3D.Texture;
using Vivid3D.Draw;
using OpenTK;
using System.IO;
using Vivid3D.App;
namespace Vivid3D.Resonance.Forms
{
    public class RequestFileForm : WindowForm 
    {

        public ListForm Files;
        public VTex2D FolderPic = new VTex2D("Data\\UI\\folder1.png", LoadMethod.Single, true);
        public VTex2D FilePic = new VTex2D("Data\\UI\\file1.png", LoadMethod.Single, true);
        public RequestFileForm(string title="",string defdir="")
        {
            if (defdir == "")
            {
                defdir = System.Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments);              
            }

            if (title == "") title = "Select file";
            Set(VividApp.W / 2 - 200, VividApp.H / 2 - 250, 400, 500, title);

            Files = new ListForm().Set(10, 40, 370, 350, "") as ListForm;
            Add(Files);
            Scan(defdir);


        }
        public void Scan(string folder)
        {
            var di = new DirectoryInfo(folder);
            foreach(var fold in di.GetDirectories())
            {
                var ni=Files.AddItem(fold.Name, FolderPic);
                void DoubleClickFunc(int b)
                {
                    Console.WriteLine("Scanning:" + fold.FullName);
                    Forms.Remove(Files);
                    Files = new ListForm().Set(10, 40, 370, 350, "") as ListForm;
                    Add(Files);
                    Scan(fold.FullName);
                 //   Files.Changed?.Invoke();
                }
                ni.DoubleClick = DoubleClickFunc;

            }
            foreach(var file in di.GetFiles())
            {
                Files.AddItem(file.Name, FilePic);
            }
            Files.Changed?.Invoke();
        }

    }
}
