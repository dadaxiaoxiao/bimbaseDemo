using BIMBaseCS.Attributes;
using BIMBaseCS.UI;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ClientDemo
{
  
    [BPExternalCommand(name = COMMAND_NAME)]
    public class TestPickPointCommand : IBPFunctionCommand
    {
        public const string COMMAND_NAME = "TestPickPoint";


        public TestPickPointCommand()
        {

        }

        public override void onExcute(BPCommandContext context)
        {
            Host.BIMBase.Host.GetHost().ActiveDocument().PickPoint(new Action<Host.Ge.Point3d>((pt) =>
            {

                MessageBox.Show($"{pt.X},{pt.Y},{pt.Z}");
            }));
        }
    }


    [BPExternalCommand(name = COMMAND_NAME)]
    public class ShowMessageCommand : IBPFunctionCommand
    {
        public const string COMMAND_NAME = "showMesagger";


        public ShowMessageCommand()
        {

        }

        public override void onExcute(BPCommandContext context)
        {
            ShowMessage(new Action<string>((pt) =>
            {
                MessageBox.Show($"{pt}");
            }));
        }

        private void ShowMessage(Action<string> callback)
        {
          //  UnitTestingHelper.UnitTesting.printDemo(callback);
        }
    }


   

}
