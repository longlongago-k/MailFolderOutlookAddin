using Microsoft.Office.Interop.Outlook;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Outlook = Microsoft.Office.Interop.Outlook;

namespace MailFolderOutlookAddin.Model
{
    public class TreeNodeMailFolder : TreeNode, IDisposable
    {
        public event EventHandler<TreeNodeMailFolder> NodesChanged;
        public string Text2 { get; set; } = "";
        private int cachedUnreadItemCount;
        private int nodeId = 0;
        private static int __nodeIdCurrent = 0;

        private Outlook.Folder oFolder = null;
        private Outlook.Items oItems = null;
        public TreeNodeMailFolder()
        {
            nodeId = __nodeIdCurrent++;
            ImageIndex = 0;
            SelectedImageIndex = 1;
        }

        public TreeNodeMailFolder(Folder folder) : this()
        {
            //Globals.ThisAddIn._folders.Add(nodeId, folder);
            this.oFolder = folder;
            cachedUnreadItemCount = folder.UnReadItemCount;
            Text = folder.Name;
            if (cachedUnreadItemCount > 0)
                Text2 = $"[{cachedUnreadItemCount}]";
            var items = (Items)folder.Items;
            this.oItems = items;

           //Globals.ThisAddIn._folderItems.Add(nodeId, items);
            items.ItemAdd += Items_ItemChanged;
            items.ItemChange += Items_ItemChanged;
            items.ItemRemove += Items_ItemChanged;
        }

        private void Items_ItemChanged()
        {
            //var folder = Globals.ThisAddIn._folders[nodeId];
            //test
            //var items = Globals.ThisAddIn._folderItems[nodeId];
            var result = this.oItems.Restrict("[Unread]=true");
            cachedUnreadItemCount = result.Count;
            System.Diagnostics.Debug.WriteLine($"ItemChanged{this.oFolder.Name}:{cachedUnreadItemCount}/{this.oFolder.Items.Count}");
            updateText();
            CallNodeChanged();
        }

        private void Items_ItemChanged(object Item)
        {
            Items_ItemChanged();
        }

        public void DisplayFolder()
        {
            Globals.ThisAddIn.Application.ActiveExplorer().CurrentFolder = this.oFolder;
            //folder?.Display();
        }

        public void AddChildFolder(TreeNodeMailFolder node)
        {
            Nodes.Add(node);
            node.NodesChanged += Node_NodesChanged;
            updateText();
            CallNodeChanged();
        }

        private void Node_NodesChanged(object sender, TreeNodeMailFolder e)
        {
            updateText();
            CallNodeChanged();
        }

        private void updateText()
        {
         //   var folder = Globals.ThisAddIn._folders[nodeId];
            Text = this.oFolder.Name;
            if (Nodes.Count == 0)
            {
                if (cachedUnreadItemCount > 0)
                    Text2 = $"[{cachedUnreadItemCount}]";
            }
            else
            {
                int countChildren = getAllUnreadItemCounts(this) - cachedUnreadItemCount;
                if (cachedUnreadItemCount > 0 || countChildren > 0)
                    Text2 = $"[{cachedUnreadItemCount} /子:{countChildren}]";
            }
        }

        private int getAllUnreadItemCounts(TreeNodeMailFolder parent)
        {
            int cnt = parent.cachedUnreadItemCount;
            foreach (TreeNodeMailFolder f in parent.Nodes)
            {
                cnt += getAllUnreadItemCounts(f);
            }
            return cnt;
        }

        public void CallNodeChanged()
        {
            NodesChanged?.Invoke(this, this);
        }

        public void Dispose()
        {
            this.oItems.ItemAdd -= Items_ItemChanged;
            this.oItems.ItemChange -= Items_ItemChanged;
            this.oItems.ItemRemove -= Items_ItemChanged;
            this.oItems = null;
            this.oFolder = null;
            //Text = null; // shall not set value, due to setter calls update tree.
            Text2 = null;
            Nodes.Clear();
        }

    }
}
