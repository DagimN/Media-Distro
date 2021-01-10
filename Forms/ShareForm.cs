using System;
using System.IO;
using static System.IO.Path;
using Mobile_Service_Distribution.Managers;
using static Mobile_Service_Distribution.Managers.CartManager;
using System.ComponentModel;
using System.Drawing;
using System.Windows.Forms;


namespace Mobile_Service_Distribution.Forms
{
    public partial class ShareForm : Form
    {
        private mediaDistroFrame reference;
        private Control activeList;
        public CartManager cart;

        public ShareForm(mediaDistroFrame reference, HomeForm homeForm, StatsForm statsForm)
        {
            InitializeComponent();

            this.reference = reference; 

            activeList = cartsListView;
            progressListView.Link(this, homeForm, statsForm, reference);

            foreach (DriveInfo usbStorage in DriveInfo.GetDrives())
            {
                if (usbStorage.IsReady && usbStorage.DriveType == DriveType.Removable)
                {
                    ListViewItem usbDrive;

                    if (File.Exists(Combine(usbStorage.Name, "Distro List")))
                    {
                        usbDrive = new ListViewItem
                        {
                            Text = usbStorage.VolumeLabel + " " + usbStorage.Name,
                            Tag = usbStorage.Name,
                            ImageIndex = 3
                        };
                    }
                    else
                    {
                        usbDrive = new ListViewItem
                        {
                            Text = usbStorage.VolumeLabel + " " + usbStorage.Name,
                            Tag = usbStorage.Name,
                            ImageIndex = 2
                        };
                    }

                    deviceList.Items.Add(usbDrive);
                    sendToToolStripMenuItem.Enabled = true;
                    sendToToolStripMenuItem.DropDownItems.Add(usbStorage.Name).Tag = usbStorage.Name;
                }       
            }

            if (deviceList.Items.Count > 0)
                deviceLabel.Visible = false;
        }

        private void cartsButton_Click(object sender, EventArgs e)
        {
            activeList.Visible = false;
            activeList = cartsListView;
            activeList.Visible = true;
            cartsSelected.Visible = true;
            progressButton.ForeColor = SystemColors.WindowFrame;
            progressSelected.Visible = false;
            cartsButton.ForeColor = Media_Distro.Properties.Settings.Default.Active_Theme_TitleBar;
            if (cartsListView.Items.Count == 0) noCartLabel.Visible = true;
            detailPanel.Visible = true;
            panel1.Visible = true;
            progressLabel.Visible = false;
            activeList.Focus();
        }

        private void progressButton_Click(object sender, EventArgs e)
        {
            activeList.Visible = false;
            activeList = progressListView;
            activeList.Visible = true;
            progressSelected.Visible = true;
            progressButton.ForeColor = Media_Distro.Properties.Settings.Default.Active_Theme_TitleBar;
            cartsSelected.Visible = false;
            cartsButton.ForeColor = SystemColors.WindowFrame;
            detailPanel.Visible = false;
            panel1.Visible = false;
            noCartLabel.Visible = false;
            if (progressListView.Items.Count > 0)
                progressLabel.Visible = false;
            else
                progressLabel.Visible = true;
            activeList.Focus();
        }

        private void cartsListView_ItemActivate(object sender, EventArgs e)
        {
            CartManager cartDetails = (CartManager)cartsListView.FocusedItem.Tag;

            FillDetailList(cartDetails);
            cart = cartDetails;
        }

        private void cartsListView_Leave(object sender, EventArgs e)
        {
            if (!detailPanel.ContainsFocus)
            {
                cartSizeExtLabel.Text = "0";
                movieExtLabel.Text = null;
                musicExtLabel.Text = null;
                seriesExtLabel.Text = null;
                priceExtLabel.Text = null;
                detailListView.Items.Clear();
                panel1.Visible = true;
                emptyCartLabel.Visible = false;
            }
        }

        private void sharePanel_MouseClick(object sender, MouseEventArgs e)
        {
            panel1.Visible = true;
            detailListView.Items.Clear();
            cartSizeExtLabel.Text = "0";
            movieExtLabel.Text = null;
            musicExtLabel.Text = null;
            seriesExtLabel.Text = null;
            priceExtLabel.Text = "0";
            emptyCartLabel.Visible = false;
        }

        private void ShareForm_MouseClick(object sender, MouseEventArgs e)
        {
            panel1.Visible = true;
            detailListView.Items.Clear();
            cartSizeExtLabel.Text = "0";
            movieExtLabel.Text = null;
            musicExtLabel.Text = null;
            seriesExtLabel.Text = null;
            priceExtLabel.Text = "0";
            emptyCartLabel.Visible = false;
        }

        private void cartsContextMenuStrip_Opening(object sender, CancelEventArgs e)
        {
            if (cartsListView.SelectedItems.Count == 0) 
                e.Cancel = true;
            else
                cartsContextMenuStrip.Tag = cartsListView.FocusedItem.Tag;

            if (deviceList.Items.Count > 0 && sendToToolStripMenuItem.DropDownItems[0].Text == "0") 
                sendToToolStripMenuItem.DropDownItems.Remove(sendToToolStripMenuItem.DropDownItems[0]);
        }

        private void cartsListView_ItemSelectionChanged(object sender, ListViewItemSelectionChangedEventArgs e)
        {
            CartManager cartDetails;
            if (e.IsSelected && panel1.Visible)
            {
                cartDetails = (CartManager)e.Item.Tag;
                FillDetailList(cartDetails);
            }
            else if (!e.IsSelected)
            {
                panel1.Visible = true;
                detailListView.Items.Clear();
                cartSizeExtLabel.Text = "0";
                movieExtLabel.Text = null;
                musicExtLabel.Text = null;
                seriesExtLabel.Text = null;
                priceExtLabel.Text = "0";
                cartDetails = null;
                emptyCartLabel.Visible = false;
            }
            else cartDetails = null;

            cart = cartDetails;
        }

        private void FillDetailList(CartManager cartDetails)
        {
            const int GigaByte = 1000 * 1000 * 1000, MegaByte = 1000 * 1000;
            decimal price = 0.00M;
            int movieNum = 0, musicNum = 0, seriesNum = 0;
            LibraryManager[] cartList = cartDetails.ShowList();

            panel1.Visible = false;
            detailListView.Items.Clear();

            if (cartList.Length > 0)
            {
                emptyCartLabel.Visible = false;

                foreach (LibraryManager fileName in cartList)
                {
                    price += fileName.Price;

                    if (fileName.Type == LibraryManager.MediaType.Movie) movieNum++;
                    else if (fileName.Type == LibraryManager.MediaType.Music) musicNum++;
                    else if (fileName.Type == LibraryManager.MediaType.Series) seriesNum++;

                    detailListView.Items.Add(new ListViewItem
                    {
                        Text = fileName.Title,
                        Tag = fileName
                    });
                }
            }
            else
                emptyCartLabel.Visible = true;
            

            if (cartDetails.cartSize > GigaByte) cartSizeExtLabel.Text = String.Format("{0:F}", cartDetails.cartSize / GigaByte) + " GB";
            else if (cartDetails.cartSize > MegaByte) cartSizeExtLabel.Text = String.Format("{0:F}", cartDetails.cartSize / MegaByte) + " MB";
            else if (cartDetails.cartSize > 1024) cartSizeExtLabel.Text = String.Format("{0:F}", cartDetails.cartSize) + " KB";
            else cartSizeExtLabel.Text = "0";

            priceExtLabel.Text = price.ToString() + " ETB";
            movieExtLabel.Text = movieNum.ToString();
            musicExtLabel.Text = musicNum.ToString();
            seriesExtLabel.Text = seriesNum.ToString();
        }

        private void clearCartToolStripMenuItem_Click(object sender, EventArgs e)
        {
            CartManager cartDetails = (CartManager)cartsContextMenuStrip.Tag;
            cartDetails.Clear();
            cartSizeExtLabel.Text = null;
            movieExtLabel.Text = "0";
            musicExtLabel.Text = "0";
            seriesExtLabel.Text = "0";
            priceExtLabel.Text = null;
            detailListView.Items.Clear();
        }

        private void removeCartToolStripMenuItem_Click(object sender, EventArgs e)
        {
            CartManager cartDetails = (CartManager)cartsListView.SelectedItems[0].Tag;
            
            carts.Remove(cartDetails);
            foreach (ToolStripItem item in reference.cartsToolStripSplitButton.DropDownItems)
            {
                if (item.Tag == cartDetails)
                {
                    reference.cartsToolStripSplitButton.DropDownItems.Remove(item);
                    break;
                }
            }

            reference.customers--;
            if (reference.cartLabel.Tag == cartDetails) reference.cartLabel.Text = null;
            cartsListView.Items.Remove(cartsListView.SelectedItems[0]);

            if (reference.cartsToolStripSplitButton.DropDownItems.Count == 0)
            {
                reference.cartsToolStripSplitButton.ToolTipText = "No Carts";
                noCartLabel.Visible = true;
            }
              
        }

        private void cartsListView_DoubleClick(object sender, EventArgs e)
        {
            if(cartsListView.SelectedItems.Count != 0)
            {
                reference.activeItem.ImageIndex = 0;

                reference.cartLabel.Text = cartsListView.FocusedItem.Text;
                reference.cartLabel.Tag = cartsListView.FocusedItem.Tag;

                foreach (ListViewItem item in cartsListView.Items)
                    if (item.Tag == reference.cartLabel.Tag)
                    {
                        reference.activeItem = item;
                        reference.activeItem.ImageIndex = 1;
                    }
            }
        }

        private void cartsListView_KeyDown(object sender, KeyEventArgs e)
        {
            CartManager cartDetails;

            switch(e.KeyCode)
            {
                case Keys.Delete:

                    try
                    {
                        cartDetails = (CartManager)cartsListView.SelectedItems[0].Tag;

                        carts.Remove(cartDetails);
                        foreach (ToolStripItem item in reference.cartsToolStripSplitButton.DropDownItems)
                            if (item.Tag == cartDetails)
                            {
                                reference.cartsToolStripSplitButton.DropDownItems.Remove(item);
                                break;
                            }
                        if (reference.cartsToolStripSplitButton.DropDownItems.Count == 0)
                        {
                            reference.cartsToolStripSplitButton.ToolTipText = "No Carts";
                            noCartLabel.Visible = true;
                        }
                        reference.customers--;
                        if (reference.cartLabel.Tag == cartDetails) reference.cartLabel.Text = null;
                        cartsListView.Items.Remove(cartsListView.SelectedItems[0]);
                    }
                    catch (Exception) { }

                    break;
            }
        }

        private void sendToToolStripMenuItem_DropDownItemClicked(object sender, ToolStripItemClickedEventArgs e)
        {
            cartsContextMenuStrip.Close(ToolStripDropDownCloseReason.ItemClicked);
            DriveInfo usbStorage = new DriveInfo(e.ClickedItem.Tag.ToString());

            try
            {
                if (!cart.IsEmpty() && usbStorage.AvailableFreeSpace > cart.cartSize)
                    progressListView.Add(cart, cartsListView.SelectedItems[0].Text, usbStorage);
                else throw new Exception();
            }
            catch (Exception)
            {
                if(cart.IsEmpty())
                    MessageBox.Show("Cart is currently empty. Go to the library and pick some stuff up.", "Empty Cart", MessageBoxButtons.OK, MessageBoxIcon.Information);
                else if(usbStorage.AvailableFreeSpace < cart.cartSize)
                    MessageBox.Show("There is no available space in the storage device.", "Low Available Storage", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }

        private void cartsListView_VisibleChanged(object sender, EventArgs e)
        {
            if (!cartsListView.Visible)
            {
                ListViewItem temp = new ListViewItem();
                cartsListView.Items.Add(temp);
                cartsListView.Items.Remove(temp);
            }
        }

        private void removeButton_Click(object sender, EventArgs e)
        { 
            foreach(ListViewItem item in detailListView.SelectedItems)
            {
                cart.Remove((LibraryManager)item.Tag);
                detailListView.Items.Remove(item);
            }

            FillDetailList(cart);
        }

        private void detailListView_ItemSelectionChanged(object sender, ListViewItemSelectionChangedEventArgs e)
        {
            if (detailListView.SelectedItems.Count > 0)
                removeButton.Enabled = true;
            else
                removeButton.Enabled = false;
        }

        private void ShareForm_Leave(object sender, EventArgs e)
        {
            reference.Focus();
        }

        private void deviceList_ItemActivate(object sender, EventArgs e)
        {
            ListViewItem availableList = deviceList.SelectedItems[0];
            string[] listFile;
            DialogResult result;
            CartManager newCart;

            if(availableList.ImageIndex == 3)
            {
                listFile = File.ReadAllLines(Combine((string)availableList.Tag, "Distro List"));

                result = MessageBox.Show("This device contains the list of the customer's choice. Press YES to start the transaction automatically.", "Distro List Detected",
                    MessageBoxButtons.YesNo, MessageBoxIcon.Information);
                if (result == DialogResult.Yes)
                {
                    if (cartsListView.Items != null)
                    {
                        reference.cartsToolStripSplitButton.ToolTipText = null;
                        noCartLabel.Visible = false;
                    }

                    reference.cartsToolStripSplitButton.DropDownItems.Add("Customer " + ++reference.customers).Tag = newCart = new CartManager(reference.customers);
                    reference.cartLabel.Text = $"Customer {reference.customers}";
                    reference.cartLabel.Tag = newCart;

                    ListViewItem newItem = new ListViewItem
                    {
                        Text = reference.cartLabel.Text,
                        ImageIndex = 1,
                        Tag = reference.cartLabel.Tag
                    };

                    if (reference.activeItem == null)
                    {
                        cartsListView.Items.Add(newItem);
                        reference.activeItem = newItem;
                    }
                    else
                    {
                        reference.activeItem.ImageIndex = 0;
                        cartsListView.Items.Add(newItem);
                        reference.activeItem = newItem;
                    }
                }
            }
                
        }
    }
}
