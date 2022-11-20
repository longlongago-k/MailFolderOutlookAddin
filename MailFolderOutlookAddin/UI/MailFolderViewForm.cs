using MailFolderOutlookAddin.HighDpiSupport;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Outlook = Microsoft.Office.Interop.Outlook;

namespace MailFolderOutlookAddin.UI
{
    public partial class MailFolderViewForm : DpiAwareWindowsForm
    {
        public MailFolderViewForm() : base()
        {
            InitializeComponent();
            DPIHelper.SetThreadDpiAwarenessContext(DPIHelper.DPI_AWARENESS_CONTEXT_PER_MONITOR_AWARE_V2);
            StartPosition = FormStartPosition.CenterParent;
            HandleCreated += MailFolderViewForm_HandleCreated;
        }

        private void MailFolderViewForm_HandleCreated(object sender, EventArgs e)
        {
            if (MailFolderViewSetting.BaseDpi != CurrentDpi.Width)
            {
                MailFolderViewSetting.CurrentAwarenessDpi = CurrentDpi.Width;
                mailFolderView.UpdateScaleDpiFont();
            }
        }

        public async Task Construct(Outlook.Explorer currentExplorer)
            => await mailFolderView.ConstuctTree(currentExplorer);

        protected override void ScaleAllChildControls(RECT newRect, SizeF oldDpi, SizeF newDpi)
        {
            MailFolderViewSetting.CurrentAwarenessDpi = newDpi.Width;
            mailFolderView.UpdateScaleDpiFont();
        }
        private void MailFolderViewForm_FormClosed(object sender, FormClosedEventArgs e)
        {
            mailFolderView?.Dispose();
            mailFolderView = null;
        }
    }
}
