using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Host
{
    public interface IHost
    {
        string HostName { get; }

        string HostDirectory { get; }

        string UserName { get; }

        Version HostVersion { get; }

        IDocument ActiveDocument();

        event EventHandler DocumentClosed;

        event EventHandler DocumentOpened;
    }
}
