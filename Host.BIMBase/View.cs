using BIMBaseCS.Core;
using BIMBaseCS.Geometry;
using Host.Ge;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;


namespace Host.BIMBase
{
    public class View : IView
    {
        private static readonly string s_default_font_name = "宋体";

        private BPViewport m_viewport;

        public View(BPViewport viewport)
        {
            m_viewport = viewport;
        }

      
    }
}
