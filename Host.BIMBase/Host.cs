using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Host.BIMBase
{
    public class Host : IHost
    {
        private static Host s_host;

        private static object s_lockObj = new object();

        private Document m_document;

        private BIMBaseCS.ApplicationService.BPApplication m_app;

        public event EventHandler DocumentClosed;

        public event EventHandler DocumentOpened;

        public string HostName { get; private set; }

        public string HostDirectory { get; private set; }

        public string UserName { get; private set; }

        public Version HostVersion { get; private set; }

        private Host()
        {
            m_app = BIMBaseCS.ApplicationService.BPApplication.singleton();
            HostName = "BIMBase";
            HostDirectory = m_app.getAppPath();
            UserName = "";
            HostVersion = new Version();
            m_app.DocumentClosed += M_app_DocumentClosed;
            m_app.DocumentOpened += M_app_DocumentOpened;
        }

        private void M_app_DocumentOpened(object sender, BIMBaseCS.Events.BPDocumentOpenedEventArgs e)
        {
            m_document = new Document(m_app.activeDocument);
            DocumentOpened?.Invoke(this, new EventArgs());
        }

        private void M_app_DocumentClosed(object sender, BIMBaseCS.Events.BPDocumentClosedEventArgs e)
        {
            m_document = null;
            DocumentClosed?.Invoke(this, new EventArgs());
        }

        public IDocument ActiveDocument()
        {
            return new Document(m_app.activeDocument);
        }

        public static Host GetHost()
        {
            if (s_host == null)
            {
                lock (s_lockObj)
                {
                    if (s_host == null)
                    {
                        s_host = new Host();
                    }
                }
            }
            return s_host;
        }
    }
}
