using MailFolderOutlookAddin;
using MailFolderOutlookAddin.Model;
using MailFolderOutlookAddin.UI;
using Microsoft.Office.Core;
using Microsoft.Office.Interop.Outlook;
using Microsoft.Office.Tools.Ribbon;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace MailFolderOutlookAddin
{
    public partial class Ribbon
    {
        private MailFolderView view;
        private MailFolderViewForm form;
        private Microsoft.Office.Tools.CustomTaskPane taskPane = null;
        private Explorer currentExplorer;

        private bool initialized => currentExplorer != null;
        

        private void Ribbon_Load(object sender, RibbonUIEventArgs e)
        {

        }

        private async void button1_Click(object sender, RibbonControlEventArgs e)
        {
            if (!initialized)
                initialize();
            if(taskPane == null) {
                view = new MailFolderView();
                taskPane = Globals.ThisAddIn.CustomTaskPanes.Add(view, "メールフォルダ");
                taskPane.DockPosition = MsoCTPDockPosition.msoCTPDockPositionLeft;
                taskPane.Visible = true;
                await view.ConstuctTree(currentExplorer);
                //Globals.ThisAddIn.Application.Explorers.fol;
                //Microsoft.Office.Interop.Outlook.OlDefaultFolders.olFolderInbox
                //System.Diagnostics.Debug.WriteLine(inBox.Name);
                //inBox.Items.ItemChange += (obj)
                //    => System.Diagnostics.Debug.WriteLine( obj.ToString());
                //inBox.Folders[userName].Display();
            }
            else
                taskPane.Visible = true;
        }

        private void initialize()
        {
                currentExplorer = Globals.ThisAddIn.Application.ActiveExplorer();
        }

        private async void button2_Click(object sender, RibbonControlEventArgs e)
        {
            if (form != null)
                return;
            if (!initialized)
                initialize();
            form = new MailFolderViewForm();
            form.Disposed += (seder, _) => this.form = null;
            form.Show();
            await form.Construct(currentExplorer);
        }
    }
}
