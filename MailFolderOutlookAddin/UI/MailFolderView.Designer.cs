
namespace MailFolderOutlookAddin.UI
{
    partial class MailFolderView
    {
        /// <summary> 
        /// 必要なデザイナー変数です。
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        #region コンポーネント デザイナーで生成されたコード

        /// <summary> 
        /// デザイナー サポートに必要なメソッドです。このメソッドの内容を 
        /// コード エディターで変更しないでください。
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            this.imageList1 = new System.Windows.Forms.ImageList(this.components);
            this.progressBar1 = new System.Windows.Forms.ProgressBar();
            this.labelProgress = new System.Windows.Forms.Label();
            this.tableLayoutPanelProgress = new System.Windows.Forms.TableLayoutPanel();
            this.toolStrip = new System.Windows.Forms.ToolStrip();
            this.toolStripButtonSetting = new System.Windows.Forms.ToolStripButton();
            this.labelDots = new System.Windows.Forms.Label();
            this.tableLayoutPanelDots = new System.Windows.Forms.TableLayoutPanel();
            this.treeViewFolder = new MailFolderOutlookAddin.UI.BufferedTreeView();
            this.tableLayoutPanelProgress.SuspendLayout();
            this.toolStrip.SuspendLayout();
            this.tableLayoutPanelDots.SuspendLayout();
            this.SuspendLayout();
            // 
            // imageList1
            // 
            this.imageList1.ColorDepth = System.Windows.Forms.ColorDepth.Depth32Bit;
            this.imageList1.ImageSize = new System.Drawing.Size(20, 20);
            this.imageList1.TransparentColor = System.Drawing.Color.Transparent;
            // 
            // progressBar1
            // 
            this.progressBar1.Location = new System.Drawing.Point(3, 25);
            this.progressBar1.Name = "progressBar1";
            this.progressBar1.Size = new System.Drawing.Size(308, 10);
            this.progressBar1.TabIndex = 2;
            // 
            // labelProgress
            // 
            this.labelProgress.AutoSize = true;
            this.labelProgress.BackColor = System.Drawing.Color.Transparent;
            this.labelProgress.Location = new System.Drawing.Point(3, 0);
            this.labelProgress.Name = "labelProgress";
            this.labelProgress.Padding = new System.Windows.Forms.Padding(0, 0, 0, 3);
            this.labelProgress.Size = new System.Drawing.Size(53, 22);
            this.labelProgress.TabIndex = 3;
            this.labelProgress.Text = "label1";
            // 
            // tableLayoutPanelProgress
            // 
            this.tableLayoutPanelProgress.AutoSize = true;
            this.tableLayoutPanelProgress.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.tableLayoutPanelProgress.BackColor = System.Drawing.Color.Transparent;
            this.tableLayoutPanelProgress.ColumnCount = 1;
            this.tableLayoutPanelProgress.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanelProgress.Controls.Add(this.progressBar1, 0, 1);
            this.tableLayoutPanelProgress.Controls.Add(this.labelProgress, 0, 0);
            this.tableLayoutPanelProgress.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.tableLayoutPanelProgress.Location = new System.Drawing.Point(0, 247);
            this.tableLayoutPanelProgress.Name = "tableLayoutPanelProgress";
            this.tableLayoutPanelProgress.RowCount = 2;
            this.tableLayoutPanelProgress.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.tableLayoutPanelProgress.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.tableLayoutPanelProgress.Size = new System.Drawing.Size(314, 38);
            this.tableLayoutPanelProgress.TabIndex = 4;
            // 
            // toolStrip
            // 
            this.toolStrip.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.toolStrip.GripStyle = System.Windows.Forms.ToolStripGripStyle.Hidden;
            this.toolStrip.ImageScalingSize = new System.Drawing.Size(32, 32);
            this.toolStrip.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.toolStripButtonSetting});
            this.toolStrip.Location = new System.Drawing.Point(0, 189);
            this.toolStrip.Name = "toolStrip";
            this.toolStrip.Size = new System.Drawing.Size(314, 39);
            this.toolStrip.TabIndex = 5;
            this.toolStrip.Text = "toolStrip1";
            // 
            // toolStripButtonSetting
            // 
            this.toolStripButtonSetting.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.toolStripButtonSetting.Image = global::MailFolderOutlookAddin.Properties.Resources.Settings_x32;
            this.toolStripButtonSetting.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.toolStripButtonSetting.Name = "toolStripButtonSetting";
            this.toolStripButtonSetting.Size = new System.Drawing.Size(36, 36);
            this.toolStripButtonSetting.Text = "toolStripButton1";
            this.toolStripButtonSetting.Click += new System.EventHandler(this.toolStripButtonSetting_Click);
            // 
            // labelDots
            // 
            this.labelDots.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.labelDots.AutoSize = true;
            this.labelDots.Location = new System.Drawing.Point(140, 0);
            this.labelDots.Name = "labelDots";
            this.labelDots.Size = new System.Drawing.Size(33, 19);
            this.labelDots.TabIndex = 6;
            this.labelDots.Text = "・・・";
            // 
            // tableLayoutPanelDots
            // 
            this.tableLayoutPanelDots.AutoSize = true;
            this.tableLayoutPanelDots.ColumnCount = 1;
            this.tableLayoutPanelDots.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanelDots.Controls.Add(this.labelDots, 0, 0);
            this.tableLayoutPanelDots.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.tableLayoutPanelDots.Location = new System.Drawing.Point(0, 228);
            this.tableLayoutPanelDots.Margin = new System.Windows.Forms.Padding(0);
            this.tableLayoutPanelDots.Name = "tableLayoutPanelDots";
            this.tableLayoutPanelDots.RowCount = 1;
            this.tableLayoutPanelDots.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.tableLayoutPanelDots.Size = new System.Drawing.Size(314, 19);
            this.tableLayoutPanelDots.TabIndex = 7;
            this.tableLayoutPanelDots.Visible = false;
            // 
            // treeViewFolder
            // 
            this.treeViewFolder.Dock = System.Windows.Forms.DockStyle.Fill;
            this.treeViewFolder.DrawMode = System.Windows.Forms.TreeViewDrawMode.OwnerDrawText;
            this.treeViewFolder.Font = new System.Drawing.Font("Meiryo UI", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            this.treeViewFolder.ImageIndex = 0;
            this.treeViewFolder.ImageList = this.imageList1;
            this.treeViewFolder.Location = new System.Drawing.Point(0, 0);
            this.treeViewFolder.Name = "treeViewFolder";
            this.treeViewFolder.SelectedImageIndex = 0;
            this.treeViewFolder.Size = new System.Drawing.Size(314, 189);
            this.treeViewFolder.TabIndex = 1;
            this.treeViewFolder.DrawNode += new System.Windows.Forms.DrawTreeNodeEventHandler(this.treeViewFolder_DrawNode);
            this.treeViewFolder.AfterSelect += new System.Windows.Forms.TreeViewEventHandler(this.treeViewFolder_AfterSelect);
            this.treeViewFolder.MouseMove += new System.Windows.Forms.MouseEventHandler(this.treeViewFolder_MouseMove);
            // 
            // MailFolderView
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(120F, 120F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Dpi;
            this.Controls.Add(this.treeViewFolder);
            this.Controls.Add(this.toolStrip);
            this.Controls.Add(this.tableLayoutPanelDots);
            this.Controls.Add(this.tableLayoutPanelProgress);
            this.Font = new System.Drawing.Font("Meiryo UI", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            this.Name = "MailFolderView";
            this.Size = new System.Drawing.Size(314, 285);
            this.tableLayoutPanelProgress.ResumeLayout(false);
            this.tableLayoutPanelProgress.PerformLayout();
            this.toolStrip.ResumeLayout(false);
            this.toolStrip.PerformLayout();
            this.tableLayoutPanelDots.ResumeLayout(false);
            this.tableLayoutPanelDots.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private BufferedTreeView treeViewFolder;
        private System.Windows.Forms.ImageList imageList1;
        private System.Windows.Forms.ProgressBar progressBar1;
        private System.Windows.Forms.Label labelProgress;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanelProgress;
        private System.Windows.Forms.ToolStrip toolStrip;
        private System.Windows.Forms.ToolStripButton toolStripButtonSetting;
        private System.Windows.Forms.Label labelDots;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanelDots;
    }
}
