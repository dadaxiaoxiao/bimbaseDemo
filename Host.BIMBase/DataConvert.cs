using BIMBaseCS.Geometry;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Host.BIMBase
{
    internal static class DataConvert
    {
        public static GePoint3d ToGePoint3d(this global::Host.Ge.Point3d pt)
        {
            return new GePoint3d(pt.X, pt.Y, pt.Z);
        }
        public static GeVec3d ToGeVector3d(this global::Host.Ge.Vector3d v)
        {
            return new GeVec3d(v.X, v.Y, v.Z);
        }

       
    }
}
