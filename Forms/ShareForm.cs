using System;
using System.IO;
using static System.IO.Path;
using Mobile_Service_Distribution.Managers;
using static Mobile_Service_Distribution.LibraryManager;
using static Mobile_Service_Distribution.Managers.CartManager;
using System.Collections;
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
        public int iter = 1;

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

                    reference.shareToolStripSplitButton.DropDownItems.Add(usbDrive.Text).Tag = usbDrive.Tag;
                    reference.shareToolStripSplitButton.ToolTipText = null;
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

                int p = iter - 1;
                for (int i = p; i > 0; i--)
                    detailListView.LargeImageList.Images.RemoveAt(i);
                iter = 1;
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

            int p = iter - 1;
            for (int i = p; i > 0; i--)
                detailListView.LargeImageList.Images.RemoveAt(i);
            iter = 1;
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

            int p = iter - 1;
            for (int i = p; i > 0; i--)
                detailListView.LargeImageList.Images.RemoveAt(i);
            iter = 1;
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

                int p = iter - 1;
                for (int i = p; i > 0; i--)
                    detailListView.LargeImageList.Images.RemoveAt(i);
                iter = 1;
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

                    if (fileName.CoverArtDirectory != null && File.Exists(fileName.CoverArtDirectory))
                    {
                        detailListView.LargeImageList.Images.Add(Image.FromFile(fileName.CoverArtDirectory));

                        this.detailListView.Items.Add(new ListViewItem
                        {
                            Text = fileName.Title,
                            Tag = fileName,
                            ImageIndex = iter++
                        });
                    }
                    else
                    {
                        this.detailListView.Items.Add(new ListViewItem
                        {
                            Text = fileName.Title,
                            Tag = fileName,
                            ImageIndex = 0
                        });
                    }
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

            int p = iter - 1;
            for (int i = p; i > 0; i--)
                detailListView.LargeImageList.Images.RemoveAt(i);
            iter = 1;
        }

        private void removeCartToolStripMenuItem_Click(object sender, EventArgs e)
        {
            CartManager cartDetails = (CartManager)cartsListView.SelectedItems[0].Tag;
            ListViewItem removeItem = new ListViewItem();

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
            
            foreach (ListViewItem item in cartsListView.Items)
                if (item.Tag == cartDetails)
                    removeItem = item;
            cartsListView.Items.Remove(removeItem);

            if (reference.cartsToolStripSplitButton.DropDownItems.Count == 0)
            {
                reference.cartsToolStripSplitButton.ToolTipText = "No Carts";
                noCartLabel.Visible = true;
            }

            int p = iter - 1;
            for (int i = p; i > 0; i--)
                detailListView.LargeImageList.Images.RemoveAt(i);
            iter = 1;

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

            int p = iter - 1;
            for (int i = p; i > 0; i--)
                detailListView.LargeImageList.Images.RemoveAt(i);
            iter = 1;

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
            DriveInfo usbStorage;

            if (availableList.ImageIndex == 3)
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

                    foreach(string item in listFile)
                    {
                        if (item.Contains("-M ") || item.Contains("-A "))
                        {
                            string musicItem = item.Substring(3);
                            foreach(LibraryManager music in musicCatalogue)
                            {
                                if (item.Contains("-A ") && music.Title.ToLower().Contains(musicItem.ToLower()))
                                    newCart.AddMedia(music);
                                else if (item.Contains("=>") && music.Title.ToLower().Contains(musicItem.Substring(musicItem.IndexOf('>') + 1).Trim().ToLower()))
                                {
                                    foreach (string dir in music.AlbumList)
                                    {
                                        if (GetFileNameWithoutExtension(dir).ToLower().Contains(musicItem.Substring(0, musicItem.IndexOf('=') - 1).Trim().ToLower()))
                                        {
                                            LibraryManager singleMusic = new LibraryManager(dir, MediaType.Music, false, true);
                                            newCart.AddMedia(singleMusic);
                                            break;
                                        }
                                    }
                                }
                                else if (item.Contains("-M ") && music.Title.ToLower().Contains(musicItem.ToLower().Trim()))
                                    newCart.AddMedia(music);
                            }
                        }
                        else if (item.Contains("#"))
                        {
                            char[] id = item.Substring(1, 4).ToCharArray();
                            string series = item.Substring(6);
                            int index;

                            if(id[0] == 'A')
                            {
                                index = 0;
                                series = item.Substring(3);
                            }
                            else if (id[0] != '0')
                                index = int.Parse((id[0] + id[1]).ToString());
                            else
                                index = int.Parse(id[1].ToString());
                            
                            foreach(LibraryManager Series in seriesCatalogue)
                            {
                                if (Series.Title.ToLower().Contains(series.ToLower().Trim()))
                                {
                                    ArrayList season = new ArrayList();
                                    LibraryManager seriesItem;

                                    if (index == 0)
                                        newCart.AddMedia(Series);
                                    else
                                    {
                                        foreach (ArrayList s in Series.SeriesList)
                                            if (GetFileNameWithoutExtension((string)s[0]).Contains(index.ToString()))
                                                season = s;

                                        if (id[2] != 'A' && id[3] != 'E')
                                        {
                                            foreach (string episode in season)
                                            {
                                                if (GetFileNameWithoutExtension(episode).ToLower().Contains("s" + id[0] + id[1]) &&
                                                    GetFileNameWithoutExtension(episode).ToLower().Contains("e" + id[2] + id[3]))
                                                {
                                                    seriesItem = new LibraryManager(episode, MediaType.Series);
                                                    newCart.AddMedia(seriesItem);
                                                    break;
                                                }
                                            }
                                        }
                                        else
                                        {
                                            seriesItem = new LibraryManager((string)season[0], MediaType.Series, true, true);
                                            seriesItem.Title = Series.Title;
                                            newCart.AddMedia(seriesItem);
                                        }
                                    }
                                }
                            }
                        }
                        else
                            foreach(LibraryManager movie in movieCatalogue)
                                if (movie.Title.ToLower().Contains(item.ToLower()))
                                    newCart.AddMedia(movie);
                    }

                    usbStorage = new DriveInfo(deviceList.FocusedItem.Tag.ToString());

                    try
                    {
                        if (!newCart.IsEmpty() && usbStorage.AvailableFreeSpace > newCart.cartSize)
                            progressListView.Add(newCart, usbStorage.VolumeLabel + " " + usbStorage.Name, usbStorage);
                        else throw new Exception();
                    }
                    catch (Exception)
                    {
                        if (newCart.IsEmpty())
                            MessageBox.Show("Cart is currently empty. Go to the library and pick some stuff up.", "Empty Cart", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        else if (usbStorage.AvailableFreeSpace < newCart.cartSize)
                            MessageBox.Show("There is no available space in the storage device.", "Low Available Storage", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }
                }
            }
        }
    }
}
