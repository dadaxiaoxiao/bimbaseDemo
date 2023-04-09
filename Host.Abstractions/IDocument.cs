using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Host
{
    public interface IDocument
    {
        IView ActiveView();
        void ExitPickPointMode();
        void PickPoint(Action<Host.Ge.Point3d> callback);
    }
}
