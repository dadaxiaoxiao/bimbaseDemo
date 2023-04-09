using BIMBaseCS.ApplicationService;
using BIMBaseCS.Attributes;
using BIMBaseCS.UI;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClientDemo
{
    [BPExternalAplication]
    public class Entry : IExternalApplication
    {
        public const string RIBBON_CATEGROY_NAME = "图为技术Demo";
        public const string RIBBON_PANEL_NAME = "图为工具栏";
      
        public const string RIBBON_BTNPICKPOINT_NAME = "捕捉点";
        public const string RIBBON_PRINT_NAME = "打印消息";
        public const string TARGET_DISCIPLINE = "BIMBase";

        private static bool m_isLoaded = false;

        public Entry()
        {
           
        }

        public override void onStartup(BPUIApplication uiApp)
        {
          
            AppDomain.CurrentDomain.AssemblyResolve += CurrentDomain_AssemblyResolve;
            AppDomain.CurrentDomain.AppendPrivatePath(System.IO.Path.GetDirectoryName(System.Reflection.Assembly.GetExecutingAssembly().Location));

            uiApp.application.DisciplineOpened += Application_DisciplineOpened;
            uiApp.application.DisciplinePreClose += Application_DisciplinePreClose;

            base.onStartup(uiApp);
            
        }

        private void Application_DisciplinePreClose(object sender, BIMBaseCS.Events.BPDisciplinePreCloseEventArgs e)
        {
            if (e.domainKeyName == TARGET_DISCIPLINE)
            {
                var app = BPUIApplication.singleton();

                app.uiManager.uiRibbonPanel.ribbonRemoveButton(RIBBON_CATEGROY_NAME, RIBBON_PANEL_NAME, RIBBON_BTNPICKPOINT_NAME);
                app.uiManager.uiRibbonPanel.ribbonRemovePanel(RIBBON_CATEGROY_NAME, RIBBON_PANEL_NAME);
                app.uiManager.uiRibbonPanel.ribbonRemoveCategory(RIBBON_CATEGROY_NAME);
            }
        }

        private void Application_DisciplineOpened(object sender, BIMBaseCS.Events.BPDisciplineOpenedEventArgs e)
        {
            if (e.domainKeyName == TARGET_DISCIPLINE)
            {
                var sizeSmallImage = new tagsize()
                {
                    cx = 16,
                    cy = 1
                };
                var sizeLargeImage = new tagsize()
                {
                    cx = 32,
                    cy = 1
                };
                var btnIcon = Properties.Resources.logo.GetHicon();
                var app = BPUIApplication.singleton();
                app.uiManager.uiRibbonPanel.ribbonAddCategory(RIBBON_CATEGROY_NAME, 16, 16, sizeSmallImage, sizeLargeImage, -1);
                app.uiManager.uiRibbonPanel.ribbonAddPanel(RIBBON_CATEGROY_NAME, RIBBON_PANEL_NAME, btnIcon, 0, -1);
                app.uiManager.uiRibbonPanel.ribbonAddButton(RIBBON_CATEGROY_NAME, RIBBON_PANEL_NAME, RIBBON_BTNPICKPOINT_NAME, TestPickPointCommand.COMMAND_NAME, btnIcon);
                app.uiManager.uiRibbonPanel.ribbonAddButton(RIBBON_CATEGROY_NAME, RIBBON_PANEL_NAME, RIBBON_PRINT_NAME, ShowMessageCommand.COMMAND_NAME, btnIcon);
            }
        }

        private System.Reflection.Assembly CurrentDomain_AssemblyResolve(object sender, ResolveEventArgs args)
        {

            return null;
        }
    }
}
