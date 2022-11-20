using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace MailFolderOutlookAddin.UI
{
    public partial class SettingForm : Form
    {
        public SettingForm()
        {
            InitializeComponent();
            StartPosition = FormStartPosition.CenterParent;
            textBoxFontSize.Text = $"{MailFolderViewSetting.BaseFontSize:F1}";
            //HandleCreated += SettingForm_HandleCreated;
        }
        private void SettingForm_Load(object sender, EventArgs e)
        {

        }

        private void textBoxFontSize_TextChanged(object sender, EventArgs e)
        {
            if (float.TryParse(textBoxFontSize.Text, out var _) == false)
            {
                buttonOK.Enabled = false;
            }
            else
                buttonOK.Enabled = true;

        }

        private void buttonOK_Click(object sender, EventArgs e)
        {
            DialogResult = DialogResult.OK;
            MailFolderViewSetting.BaseFontSize = float.Parse(textBoxFontSize.Text);
        }

        private void buttonCancel_Click(object sender, EventArgs e)
        {
            DialogResult = DialogResult.Cancel;
        }

        private void SettingForm_SizeChanged(object sender, EventArgs e)
        {

        }


        //private void SettingForm_HandleCreated(object sender, EventArgs e)
        //{
        //    //if (MailFolderViewSetting.BaseDpi != CurrentDpi.Width)
        //    //{
        //    //    ScaleDpiFont();
        //    //}
        //}

        //private void ScaleDpiFont()
        //{
        //    var font_old = this.Font;
        //    this.Font = new Font(Font.Name, MailFolderViewSetting.ScaledGraphicFontSize, Font.Style, GraphicsUnit.Point);
        //    this.labelFontSize.Font = this.Font;
        //    this.textBoxFontSize.Font = this.Font;
        //    this.buttonOK.Font = this.Font;
        //    this.buttonCancel.Font = this.Font;
        //    //font_old.Dispose();

        //}
        //protected override void ScaleAllChildControls(RECT newRect, SizeF oldDpi, SizeF newDpi)
        //{
        //    ScaleDpiFont();

        //}
    }
}
