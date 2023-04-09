using BIMBaseCS.Core;
using Host.Ge;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Host.BIMBase
{
    public class Document : IDocument
    {
        BPDocument m_doc;

        internal Document(BPDocument doc)
        {
            m_doc = doc;
        }

        public IView ActiveView()
        {
            return new View(m_doc.viewManager.getActivedViewport());
        }

        public override bool Equals(object obj)
        {
            if(obj is Document doc)
            {
                return m_doc == doc.m_doc;
            }
            return false;
        }

        public void ExitPickPointMode()
        {
           
        }

        public override int GetHashCode()
        {
            return m_doc?.GetHashCode() ?? 0;
        }


        public void PickPoint(Action<Point3d> callback)
        {
           BIMBaseHelper.IOUtil.pickPoint(callback);
        }

        public static bool operator ==(Document left, Document right)
        {
            if (left is null && right is null)
            {
                return true;
            }
            else if (left is null || right is null)
            {
                return false;
            }
            else
            {
                return left.Equals(right);
            }
        }

        public static bool operator !=(Document left, Document right)
        {
            return !(left == right);
        }
    }
}
