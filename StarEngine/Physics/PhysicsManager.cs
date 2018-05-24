using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using PhysX;
using PhysX.VisualDebugger;
namespace StarEngine.Physics
{
    public class PhysicsManager
    {
         public class ECB : ErrorCallback
        {
            public override void ReportError(ErrorCode errorCode, string message, string file, int lineNumber)
            {
                Console.WriteLine("ErrCode:" + errorCode.ToString() + " Msg:" + message + " File:" + file + " line:" + lineNumber);
            }
        }
        public static PhysX.Physics py;
        public static SceneDesc SceneD;
        public static PhysX.Scene Scene;
        public static void InitSDK()
        {
            void er()
            {

            }
            Foundation fd = new Foundation(new ECB());
            py = new PhysX.Physics(fd);
            SceneD = new SceneDesc();
            SceneD.Gravity = new System.Numerics.Vector3(0, -9, 0);
            Scene = py.CreateScene(SceneD);
            //PhysX.Material dm = Scene.get


        }

    }
}
