using MailFolderOutlookAddin.Model;
using MailFolderOutlookAddin.Properties;
using Microsoft.Office.Interop.Outlook;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Outlook = Microsoft.Office.Interop.Outlook;

namespace MailFolderOutlookAddin.UI
{
    public partial class MailFolderView : UserControl
    {
        private Explorer currentExplorer = null;
        private TreeNodeMailFolder rootNode;

        public MailFolderView()
        {
            InitializeComponent();
            imageList1.Images.Add(Resources.FolderClosed);
            imageList1.Images.Add(Resources.FolderOpened);
            imageList1.Images.Add(Resources.NewFolder);

        }
        /// <summary> 
        /// 使用中のリソースをすべてクリーンアップします。
        /// </summary>
        /// <param name="disposing">マネージド リソースを破棄する場合は true を指定し、その他の場合は false を指定します。</param>
        protected override void Dispose(bool disposing)
        {
            disposeNodes(rootNode);
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }



        public async Task ConstuctTree(Outlook.Explorer explorer)
        {
            //Note: this method should call after showing.
            currentExplorer = explorer;
            showProgress();
            //InBox (メール受信ルート)を取得
            Outlook.Folder inBox 
                = (Outlook.Folder)currentExplorer.Session.GetDefaultFolder(Outlook.OlDefaultFolders.olFolderInbox);

            //ルートノードを作成(TreeNode)
            var root = new TreeNodeMailFolder(inBox);
            this.rootNode = root;
            setRootNode(root);

            //サブフォルダを取得
            var folders = inBox.Folders.Cast<Folder>();
            //サブサブフォルダを再帰的に取得
            await Task.Run(() => getItems(folders, root)).ConfigureAwait(true);

            hideProgress();
            Outlook.Folder inBox2
                = (Outlook.Folder)currentExplorer.Session.GetDefaultFolder(Outlook.OlDefaultFolders.olFolderSentMail);
            var sentMailNode = new TreeNodeMailFolder(inBox2);
            root.Nodes.Add(sentMailNode);
        }
        public void UpdateScaleDpiFont()
        {
            using (var g = treeViewFolder.CreateGraphics())
            {
                MailFolderViewSetting.CurrentGraphicsDpi = g.DpiX;
            }
            var font_old = this.Font;
            var font_old_small = labelDots.Font;
            //this.Font = scaleFont(Font, oldDpi.Width, newDpi.Width);
            this.Font = new Font(Font.Name, MailFolderViewSetting.ScaledGraphicFontSize, Font.Style, GraphicsUnit.Point);
            treeViewFolder.Font = this.Font;
            labelDots.Font = new Font(Font.Name, MailFolderViewSetting.ScaledGraphicSmallFontSize, Font.Style, GraphicsUnit.Point);
            int size = (int)(32 * MailFolderViewSetting.CurrentGraphicsScale);
            toolStrip.ImageScalingSize = new Size(size, size);
            float iconSize = Font.SizeInPoints / 72 * MailFolderViewSetting.CurrentGraphicsDpi;
            size = (int)(treeViewFolder.ItemHeight * MailFolderViewSetting.CurrentGraphicsScale);
            imageList1.ImageSize = new Size(size, size);
            imageList1.Images.Clear();
            imageList1.Images.Add(Resources.FolderClosed);
            imageList1.Images.Add(Resources.FolderOpened);
            imageList1.Images.Add(Resources.NewFolder);
            //font_old.Dispose();
            //font_old_small.Dispose();
        }
        //private Font scaleFont(Font font, float oldDpi, float newDpi)
        //{
        //    if (newDpi == MailFolderViewSetting.BaseDpi)
        //    {
        //        if(newDpi != MailFolderViewSetting.CurrentGraphicsDpi)
        //        {
        //            float fontSize = MailFolderViewSetting.BaseFontSize * (newDpi / MailFolderViewSetting.CurrentGraphicsDpi);
        //            return new Font(font.Name, fontSize, font.Style, GraphicsUnit.Point);
        //        }
        //        else
        //            return new Font(font.Name, MailFolderViewSetting.BaseFontSize, font.Style, GraphicsUnit.Point);
        //    }
        //    float fontSizePx = font.SizeInPoints / 72 * oldDpi;
        //    float fontSizePt = fontSizePx * (newDpi / oldDpi) * 72 / oldDpi;
        //    return new Font(font.Name, fontSizePt, font.Style, GraphicsUnit.Point);
        //}

        private void disposeNodes(TreeNodeMailFolder rootNode)
        {
            foreach (TreeNodeMailFolder node in rootNode.Nodes)
            {
                disposeNodes(node);
            }
            rootNode.Dispose();
        }

        private void setRootNode(TreeNode node)
        {
            clearNodes();
            treeViewFolder.Nodes.Add(node);
        }
        private void getItems(IEnumerable<Folder> folders, TreeNodeMailFolder parentNode)
        {
            int numFolder = 0, readCount = 0;
            getItems(folders, parentNode, ref numFolder, ref readCount);
        }
        private void getItems(IEnumerable<Folder> folders, TreeNodeMailFolder parentNode,ref int numFolder, ref int readCount)
        {
            numFolder += folders.Count();
            foreach (var f in folders)
            {
                //System.Diagnostics.Debug.WriteLine($"{f.Name}[{f.UnReadItemCount}]");
                var node = new TreeNodeMailFolder(f);
                Invoke((MethodInvoker)(() =>
                {
                    parentNode.AddChildFolder(node);
                }));
                getItems(f.Folders.Cast<Folder>(), node,ref numFolder, ref readCount);
            }
            int _readCount = readCount;
            int _numFolder = numFolder;
            Invoke((MethodInvoker)(() => setReadProgress(_readCount, _numFolder)));
            readCount++;

        }


        private void setReadProgress(int readCount, int numFolders)
        {
            //System.Diagnostics.Debug.WriteLine($"{readCount}/{numFolders}");
            labelProgress.Text = $"{readCount}/{numFolders}";
            int progressValue = (readCount * 100) / numFolders;
            progressBar1.Value = progressValue;
        }

        private void showProgress()
        {
            tableLayoutPanelProgress.Visible = true;
        }
        private void hideProgress()
        {
            tableLayoutPanelProgress.Visible = false;
        }
        private void treeViewFolder_AfterSelect(object sender, TreeViewEventArgs e)
        {

            if (e.Node is TreeNodeMailFolder n)
            {
                n.DisplayFolder();
            }
        }

        private void clearNodes()
        {
            foreach (TreeNode n in treeViewFolder.Nodes)
                _clearNodes(n);
        }

        private void _clearNodes(TreeNode targetNode)
        {
            foreach (TreeNode n in targetNode.Nodes)
            {
                _clearNodes(n);

            }
            if (targetNode is TreeNodeMailFolder nf)
                nf.Dispose();
        }

        private void treeViewFolder_DrawNode(object sender, DrawTreeNodeEventArgs e)
        {
            if (e.Bounds.X < 0)
                return;
            e.Graphics.SmoothingMode = System.Drawing.Drawing2D.SmoothingMode.HighQuality;
            e.Graphics.TextRenderingHint = System.Drawing.Text.TextRenderingHint.ClearTypeGridFit; 
            using (var brush = new SolidBrush(treeViewFolder.ForeColor)) {
                //e.Graphics.TextRenderingHint = System.Drawing.Text.TextRenderingHint.ClearTypeGridFit;
                //e.Graphics.SmoothingMode = System.Drawing.Drawing2D.SmoothingMode.HighQuality;
                if ((e.State & TreeNodeStates.Selected) != 0)
                    e.Graphics.DrawString(e.Node.Text, treeViewFolder.Font, Brushes.White, e.Bounds.X,  e.Bounds.Y);
                else
                    e.Graphics.DrawString(e.Node.Text, treeViewFolder.Font, brush, e.Bounds.X,  e.Bounds.Y);
                if (e.Node is TreeNodeMailFolder mf)
                {
                    //文字列を描画するときの大きさを計測する
                    Size strSize = TextRenderer.MeasureText(e.Graphics, e.Node.Text, treeViewFolder.Font);
                    e.Graphics.DrawString(mf.Text2, treeViewFolder.Font, Brushes.Blue, e.Bounds.X + strSize.Width, e.Bounds.Y);
                }
            }
        }

        private void treeViewFolder_MouseMove(object sender, MouseEventArgs e)
        {
            if (e.Y >= Height - toolStrip.Height)
            {
                toolStrip.Visible = true;
                tableLayoutPanelDots.Visible = false;
            }
            else
            {
                toolStrip.Visible = false;
                tableLayoutPanelDots.Visible = true;
            }
        }

        private void toolStripButtonSetting_Click(object sender, EventArgs e)
        {
            using (SettingForm form = new SettingForm())
            {
                if(form.ShowDialog(this) == DialogResult.OK)
                {
                    UpdateScaleDpiFont();
                }
            }
        }
    }
}
