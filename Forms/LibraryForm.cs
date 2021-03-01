using System;
using System.IO;
using static System.IO.Path;
using static System.IO.Directory;
using static System.Environment;
using static Mobile_Service_Distribution.LibraryManager;
using Mobile_Service_Distribution.Managers;
using System.Collections.Generic;
using System.Drawing;
using System.Collections;
using System.Windows.Forms;
using System.Threading.Tasks;

namespace Mobile_Service_Distribution.Forms
{
    public partial class LibraryForm : Form
    {
        public string moviePath = Combine(GetFolderPath(SpecialFolder.UserProfile), "Media Distro", "Movies");
        public string musicPath = Combine(GetFolderPath(SpecialFolder.UserProfile), "Media Distro", "Music");
        public string seriesPath = Combine(GetFolderPath(SpecialFolder.UserProfile), "Media Distro", "Series");
        private string appendText;

        private Bitmap image;
        public static ListView activeList;
        public Button activeListButton;
        public PictureBox selected;
        private ListViewItem item;
        public LibraryManager libraryManager;
        private mediaDistroFrame reference;
        private RichTextBox currentTextBox;
        public int moiter = 1;
        public int muiter = 1;
        public int siter = 1;

        private bool nameChecked = false;
        private bool ratingChecked = false;
        private bool yearChecked = false;
        private bool durationChecked = false;
        private bool ascendingChecked = false;
        private bool descendingChecked = false;
        private bool newSave = false;

        private byte movieItemSelected = 0;
        private byte seriesItemSelected = 0;
        private byte musicItemSelected = 0;

        public LibraryForm(mediaDistroFrame reference)
        {
            InitializeComponent();

            activeList = this.movieList;
            this.reference = reference;
            
            this.ascendingToolStripMenuItem.Checked = true;
            this.nameToolStripMenuItem.Checked = true;
            ascendingChecked = true;
            nameChecked = true;
            addSTCart.Visible = false;
            activeListButton = moviesTabButton;
            selected = moviesSelected;
        }

        private void moviesTabButton_Click(object sender, EventArgs e)
        {
            activeList.Visible = false;
            if (infoPanel.Visible)
            {
                infoPanel.Visible = false;
                item = null;
                if (libraryPanel.Width != 725) libraryPanel.SetBounds(12, 12, 546, 431);
                else libraryPanel.SetBounds(12, 12, 725, 431);
            }

            moviesSelected.BackColor = Media_Distro.Properties.Settings.Default.Active_Theme_TitleBar;
            moviesTabButton.ForeColor = Media_Distro.Properties.Settings.Default.Active_Theme_TitleBar;
            musicTabButton.ForeColor = Color.DimGray;
            musicSelected.BackColor = Color.Transparent;
            seriesTabButton.ForeColor = Color.DimGray;
            seriesSelected.BackColor = Color.Transparent;

            albumTreeView.Visible = false;
            addSTCart.Visible = false;
            durationLabel.Text = "Duration: ";
            pictureBox1.Visible = false;

            genreToolStripDropDownButton.DropDownItems.Clear();
            genreToolStripDropDownButton.DropDownItems.Add("All").Click += allToolStripMenuItem_Click;
            genreToolStripDropDownButton.DropDownItems.Add("-");
            foreach (string genre in movieGenreCatalogue)
                genreToolStripDropDownButton.DropDownItems.Add(genre).Click += genreSelected_Click;

            activeList = movieList;
            activeListButton = moviesTabButton;
            selected = moviesSelected;
            activeList.Visible = true;
            activeList.Focus();
        }

        private void seriesTabButton_Click(object sender, EventArgs e)
        {
            activeList.Visible = false;
            if(infoPanel.Visible)
            {
                infoPanel.Visible = false;
                item = null;
                if (libraryPanel.Width != 725) libraryPanel.SetBounds(12, 12, 546, 431);
                else libraryPanel.SetBounds(12, 12, 725, 431);
            }


            moviesSelected.BackColor = Color.Transparent;
            moviesTabButton.ForeColor = Color.DimGray;
            musicTabButton.ForeColor = Color.DimGray;
            musicSelected.BackColor = Color.Transparent;
            seriesTabButton.ForeColor = Media_Distro.Properties.Settings.Default.Active_Theme_TitleBar;
            seriesSelected.BackColor = Media_Distro.Properties.Settings.Default.Active_Theme_TitleBar;

            albumTreeView.Visible = true;
            addSTCart.Visible = true;
            durationLabel.Text = "Seasons: ";
            pictureBox1.Visible = true;

            genreToolStripDropDownButton.DropDownItems.Clear();
            genreToolStripDropDownButton.DropDownItems.Add("All").Click += allToolStripMenuItem_Click;
            genreToolStripDropDownButton.DropDownItems.Add("-");
            foreach (string genre in seriesGenreCatalogue)
                genreToolStripDropDownButton.DropDownItems.Add(genre).Click += genreSelected_Click;

            activeList = this.seriesList;
            activeListButton = seriesTabButton;
            selected = seriesSelected;
            activeList.Visible = true;
            activeList.Focus();
        }

        private void musicTabButton_Click(object sender, EventArgs e)
        {
            activeList.Visible = false;
            if (infoPanel.Visible)
            {
                infoPanel.Visible = false;
                item = null;
                if (libraryPanel.Width != 725) libraryPanel.SetBounds(12, 12, 546, 431);
                else libraryPanel.SetBounds(12, 12, 725, 431);
            }

            moviesSelected.BackColor = Color.Transparent;
            moviesTabButton.ForeColor = Color.DimGray;
            musicTabButton.ForeColor = Media_Distro.Properties.Settings.Default.Active_Theme_TitleBar;
            musicSelected.BackColor = Media_Distro.Properties.Settings.Default.Active_Theme_TitleBar;
            seriesTabButton.ForeColor = Color.DimGray;
            seriesSelected.BackColor = Color.Transparent;

            albumTreeView.Visible = true;
            addSTCart.Visible = true;
            durationLabel.Text = "Duration: ";
            pictureBox1.Visible = true;

            genreToolStripDropDownButton.DropDownItems.Clear();
            genreToolStripDropDownButton.DropDownItems.Add("All").Click += allToolStripMenuItem_Click;
            genreToolStripDropDownButton.DropDownItems.Add("-");
            foreach (string genre in musicGenreCatalogue)
                genreToolStripDropDownButton.DropDownItems.Add(genre).Click += genreSelected_Click;

            activeList = this.musicList;
            activeListButton = musicTabButton;
            selected = musicSelected;
            activeList.Visible = true;
            activeList.Focus();
        }

        private void LibraryForm_MouseClick(object sender, MouseEventArgs e)
        {
            infoPanel.Visible = false;
            item = null;
            if (libraryPanel.Width != 725) libraryPanel.SetBounds(12, 12, 546, 431);
            else libraryPanel.SetBounds(12, 12, 725, 431);
        }

        private void movieList_ItemActivate(object sender, EventArgs e)
        {
            LibraryManager activeItem = (LibraryManager)this.movieList.FocusedItem.Tag;

            if (this.libraryPanel.Width == 546) libraryPanel.SetBounds(12, 12, 546, 290);
            else libraryPanel.SetBounds(12, 12, 725, 290);
            
            infoPanel.Visible = true;

            titleTextBox.Text = activeItem.Title;
            durationLabelExt.Text = activeItem.Duration;
            genreTextBox.Text = activeItem.Genre;
            yearTextBox.Text = (activeItem.Year != 0) ? activeItem.Year.ToString() : "";
            ratingTextBox.Text = activeItem.Rating.ToString();
            titleToolTip.SetToolTip(titleTextBox, titleTextBox.Text);

            string file = activeItem.CoverArtDirectory;
            coverPictureBox.Image = null;

            if (file != null)
            {
                image = new Bitmap(Image.FromFile(file));
                coverPictureBox.Image = image;
                coverPictureBox.Tag = this.movieList.FocusedItem.ImageIndex;
            }
            else
                coverPictureBox.Tag = 0;
        }

        private void musicList_ItemActivate(object sender, EventArgs e)
        {
            LibraryManager activeItem = (LibraryManager)this.musicList.FocusedItem.Tag;
            albumTreeView.Nodes.Clear();

            if (this.libraryPanel.Width == 546) libraryPanel.SetBounds(12, 12, 546, 290);
            else libraryPanel.SetBounds(12, 12, 725, 290);

            infoPanel.Visible = true;

            titleTextBox.Text = activeItem.Title;
            durationLabelExt.Text = activeItem.Duration;
            genreTextBox.Text = activeItem.Genre;
            yearTextBox.Text = (activeItem.Year != 0) ? activeItem.Year.ToString() : "";
            ratingTextBox.Text = activeItem.Rating.ToString();
            titleToolTip.SetToolTip(titleTextBox, titleTextBox.Text);

            if(activeItem.AlbumList != null)
            {
                albumTreeView.Visible = true;
                addSTCart.Visible = true;
                pictureBox1.Visible = true;

                foreach (string album in activeItem.AlbumList)
                {
                    libraryManager = new LibraryManager(album, MediaType.Music, false, true);
                    albumTreeView.Nodes.Add(GetFileNameWithoutExtension(album)).Tag = libraryManager;
                }
            }
            else
            {
                albumTreeView.Visible = false;
                addSTCart.Visible = false;
                pictureBox1.Visible = false;
            }

            string file = activeItem.CoverArtDirectory;
            coverPictureBox.Image = null;
            if (file != null)
            {
                image = new Bitmap(Image.FromFile(file));
                coverPictureBox.Image = image;
                coverPictureBox.Tag = this.musicList.FocusedItem.ImageIndex;
            }
            else
                coverPictureBox.Tag = 0;
        }

        private void seriesList_ItemActivate(object sender, EventArgs e)
        {
            LibraryManager activeItem = (LibraryManager)this.seriesList.FocusedItem.Tag;
            albumTreeView.Nodes.Clear();

            if (this.libraryPanel.Width == 546) libraryPanel.SetBounds(12, 12, 546, 290);
            else libraryPanel.SetBounds(12, 12, 725, 290);

            infoPanel.Visible = true;

            titleTextBox.Text = activeItem.Title;
            durationLabelExt.Text = activeItem.SeriesList.Count.ToString();
            genreTextBox.Text = activeItem.Genre;
            yearTextBox.Text = (activeItem.Year != 0) ? activeItem.Year.ToString() : "";
            ratingTextBox.Text = activeItem.Rating.ToString();
            titleToolTip.SetToolTip(titleTextBox, titleTextBox.Text);

            foreach(ArrayList season in activeItem.SeriesList)
            {
                TreeNode seasonNode = new TreeNode
                {
                    Text = GetFileNameWithoutExtension((string)season[0]).Substring(5),
                    Tag = season[0].ToString()
                };
                albumTreeView.Nodes.Add(seasonNode);

                for(int i = 1; i < season.Count; i++)
                {
                    libraryManager = new LibraryManager((string)season[i], MediaType.Series);
                    seasonNode.Nodes.Add(GetFileNameWithoutExtension((string)season[i])).Tag = libraryManager;
                }    
            }

            string file = activeItem.CoverArtDirectory;
            if (file != null)
            {
                image = new Bitmap(Image.FromFile(file));
                coverPictureBox.Image = image;
                coverPictureBox.Tag = this.seriesList.FocusedItem.ImageIndex;
            }
            else
                coverPictureBox.Tag = 0;
        }

        private void List_Leave(object sender, EventArgs e)
        {
            if (infoPanel.ContainsFocus) { }
            else
            {
                infoPanel.Visible = false;
                item = null;
                if (libraryPanel.Width != 725) libraryPanel.SetBounds(12, 12, 546, 431);
                else libraryPanel.SetBounds(12, 12, 725, 431);
            }
        }

        private void coverPictureBox_Click(object sender, EventArgs e)
        {
            OpenFileDialog pictureDialog = new OpenFileDialog
            {
                Title = "Select Cover Art",
                Filter = "JPEG Files (*.jpeg)|*.jpeg |JPG Files (*.jpg)|*.jpg |PNG Files (*.png)|*.png |All Files (*.*)|*.*"
            };

            string newImageDir;
            LibraryManager mediaCover;
            if (pictureDialog.ShowDialog() == DialogResult.OK)
            {
                newImageDir = pictureDialog.FileName;
                try
                {
                    image = new Bitmap(Image.FromFile(newImageDir));
                    coverPictureBox.Image = image;

                    if (movieList.Visible)
                    {
                        mediaCover = (LibraryManager)this.movieList.FocusedItem.Tag;
                        AppendMediaInfo(mediaCover.thisDirectory, newImageDir, MediaProperty.Cover_Art_Dir);
                        mediaCover.CoverArtDirectory = newImageDir;

                        this.movieList.LargeImageList.Images.Add(Image.FromFile(newImageDir));
                        this.movieList.FocusedItem.ImageIndex = moiter++;
                        coverPictureBox.Tag = moiter;
                    }
                    else if (musicList.Visible)
                    {
                        mediaCover = (LibraryManager)this.musicList.FocusedItem.Tag;
                        if(Exists(mediaCover.thisDirectory))
                            AppendMediaInfo(GetFiles(mediaCover.thisDirectory)[0], newImageDir, MediaProperty.Cover_Art_Dir);
                        else
                            AppendMediaInfo(mediaCover.thisDirectory, newImageDir, MediaProperty.Cover_Art_Dir);
                        mediaCover.CoverArtDirectory = newImageDir;

                        this.musicList.LargeImageList.Images.Add(Image.FromFile(newImageDir));
                        this.musicList.FocusedItem.ImageIndex = muiter++;
                        coverPictureBox.Tag = muiter;
                    }
                    else if (seriesList.Visible)
                    {
                        mediaCover = (LibraryManager)this.seriesList.FocusedItem.Tag;
                        AppendMediaInfo(GetFiles(mediaCover.thisDirectory)[0], newImageDir, MediaProperty.Cover_Art_Dir);
                        mediaCover.CoverArtDirectory = newImageDir;

                        this.seriesList.LargeImageList.Images.Add(Image.FromFile(newImageDir));
                        this.seriesList.FocusedItem.ImageIndex = siter++;
                        coverPictureBox.Tag = siter;
                    }
                }
                catch(Exception ex)
                {
                    MessageBox.Show("Unable to load picture: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }   
            }

            pictureDialog.Dispose();
        }

        private void saveInfoButton_Click(object sender, EventArgs e)
        {
            if (movieList.Visible)
            {
                if (this.movieList.FocusedItem != null) item = this.movieList.FocusedItem;

                LibraryManager activeItem = (LibraryManager)item.Tag;
                string directory = activeItem.thisDirectory;

                if (saveInfoButton.Location.Y == 13)
                {
                    appendText = titleTextBox.Text;
                    AppendMediaInfo(directory, appendText, MediaProperty.Title);
                    titleTextBox.ResetText();
                    titleTextBox.Text = appendText;
                    item.Text = appendText;

                    activeItem.Title = appendText;

                    if (nameChecked && ascendingChecked) SortMedia(movieCatalogue, SortType.Name, Order.Ascending);
                    else if (nameChecked && descendingChecked) SortMedia(movieCatalogue, SortType.Name, Order.Descending);
                    else if (durationChecked && ascendingChecked) SortMedia(movieCatalogue, SortType.Duration, Order.Ascending);
                    else if (durationChecked && descendingChecked) SortMedia(movieCatalogue, SortType.Duration, Order.Descending);
                    else if (yearChecked && ascendingChecked) SortMedia(movieCatalogue, SortType.Year, Order.Ascending);
                    else if (yearChecked && descendingChecked) SortMedia(movieCatalogue, SortType.Year, Order.Descending);
                    else if (ratingChecked && ascendingChecked) SortMedia(movieCatalogue, SortType.Rating, Order.Ascending);
                    else if (ratingChecked && descendingChecked) SortMedia(movieCatalogue, SortType.Rating, Order.Descending);

                    titleToolTip.SetToolTip(titleTextBox, appendText);
                }
                else if (saveInfoButton.Location.Y == 59)
                {
                    appendText = genreTextBox.Text;
                    AppendMediaInfo(directory, appendText, MediaProperty.Genre);
                    activeItem.Genre = appendText;

                    if (appendText == "" && movieGenreCatalogue.Contains(genreInfo))
                    {
                        bool Exist = false;

                        foreach (ListViewItem movie in movieList.Items)
                        {
                            LibraryManager movieTag = (LibraryManager)movie.Tag;
                            if (movieTag.Genre == genreInfo)
                            {
                                Exist = true;
                                break;
                            }
                        }

                        if(!Exist)
                            movieGenreCatalogue.Remove(genreInfo);
                    }
                        

                    if (!movieGenreCatalogue.Contains(appendText))
                    {
                        if(appendText != "")
                            movieGenreCatalogue.Add(appendText);
                        
                        genreToolStripDropDownButton.DropDownItems.Clear();
                        genreToolStripDropDownButton.DropDownItems.Add("All").Click += allToolStripMenuItem_Click;
                        genreToolStripDropDownButton.DropDownItems.Add("-");

                        movieGenreCatalogue.Sort();
                        foreach (string genre in movieGenreCatalogue)
                            genreToolStripDropDownButton.DropDownItems.Add(genre).Click += genreSelected_Click;
                    }

                    
                }
                    
                else if (saveInfoButton.Location.Y == 76)
                {
                    appendText = yearTextBox.Text;

                    try
                    {
                        int year = int.Parse(yearTextBox.Text);
                        AppendMediaInfo(directory, yearTextBox.Text, MediaProperty.Year);
                        activeItem.Year = year;
                            
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show("Couldn't save info: " + ex.Message);
                        yearTextBox.Text = yearInfo;
                    }
                    
                }
                    
                else if (saveInfoButton.Location.Y == 93)
                {
                    appendText = ratingTextBox.Text;

                    try
                    {
                        float rating = float.Parse(ratingTextBox.Text);
                        AppendMediaInfo(directory, ratingTextBox.Text, MediaProperty.Rating);
                        activeItem.Rating = rating;
                        activeItem.PRS = activeItem.Rating;
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show("Couldn't save info: " + ex.Message);
                        ratingTextBox.Text = ratingInfo;
                    }
                }
                    

            }
            else if (musicList.Visible)
            {
                if (this.musicList.FocusedItem != null) item = this.musicList.FocusedItem;

                LibraryManager activeItem = (LibraryManager)item.Tag;
                string appendText, directory = activeItem.thisDirectory;

                if (saveInfoButton.Location.Y == 13)
                {
                    appendText = titleTextBox.Text;
                    AppendMediaInfo(directory, appendText, MediaProperty.Title);
                    titleTextBox.ResetText();
                    titleTextBox.Text = appendText;
                    item.Text = appendText;

                    activeItem.Title = appendText;

                    if (nameChecked && ascendingChecked) SortMedia(musicCatalogue, SortType.Name, Order.Ascending);
                    else if (nameChecked && descendingChecked) SortMedia(musicCatalogue, SortType.Name, Order.Descending);
                    else if (durationChecked && ascendingChecked) SortMedia(musicCatalogue, SortType.Duration, Order.Ascending);
                    else if (durationChecked && descendingChecked) SortMedia(musicCatalogue, SortType.Duration, Order.Descending);
                    else if (yearChecked && ascendingChecked) SortMedia(musicCatalogue, SortType.Year, Order.Ascending);
                    else if (yearChecked && descendingChecked) SortMedia(musicCatalogue, SortType.Year, Order.Descending);
                    else if (ratingChecked && ascendingChecked) SortMedia(musicCatalogue, SortType.Rating, Order.Ascending);
                    else if (ratingChecked && descendingChecked) SortMedia(musicCatalogue, SortType.Rating, Order.Descending);

                    titleToolTip.SetToolTip(titleTextBox, appendText);
                }
                else if (saveInfoButton.Location.Y == 59)
                {
                    appendText = genreTextBox.Text;
                    AppendMediaInfo(directory, appendText, MediaProperty.Genre);
                    activeItem.Genre = appendText;

                    if (appendText == "" && musicGenreCatalogue.Contains(genreInfo))
                    {
                        bool Exist = false;

                        foreach (ListViewItem music in musicList.Items)
                        {
                            LibraryManager musicTag = (LibraryManager)music.Tag;
                            if (musicTag.Genre == genreInfo)
                            {
                                Exist = true;
                                break;
                            }
                        }

                        if (!Exist)
                            musicGenreCatalogue.Remove(genreInfo);
                    }

                    if (!musicGenreCatalogue.Contains(appendText))
                    {
                        musicGenreCatalogue.Add(appendText);
                        musicGenreCatalogue.Sort();

                        genreToolStripDropDownButton.DropDownItems.Clear();
                        genreToolStripDropDownButton.DropDownItems.Add("All").Click += allToolStripMenuItem_Click;
                        genreToolStripDropDownButton.DropDownItems.Add("-");

                        foreach (string genre in musicGenreCatalogue)
                            genreToolStripDropDownButton.DropDownItems.Add(genre).Click += genreSelected_Click;
                    }

                }

                else if (saveInfoButton.Location.Y == 76)
                {
                    appendText = yearTextBox.Text;

                    try
                    {
                        int year = int.Parse(yearTextBox.Text);
                        AppendMediaInfo(directory, yearTextBox.Text, MediaProperty.Year);
                        activeItem.Year = year;

                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show("Couldn't save info: " + ex.Message);
                        yearTextBox.Text = yearInfo;
                    }
                }

                else if (saveInfoButton.Location.Y == 93)
                {
                    appendText = ratingTextBox.Text;

                    try
                    {
                        float rating = float.Parse(ratingTextBox.Text);
                        AppendMediaInfo(directory, ratingTextBox.Text, MediaProperty.Rating);
                        activeItem.Rating = rating;
                        activeItem.PRS = activeItem.Rating;
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show("Couldn't save info: " + ex.Message);
                        ratingTextBox.Text = ratingInfo;
                    }
                }
            }
            else if (seriesList.Visible)
            {
                if (this.seriesList.FocusedItem != null) item = this.seriesList.FocusedItem;

                LibraryManager activeItem = (LibraryManager)item.Tag;
                string appendText, directory = activeItem.thisDirectory;

                if (saveInfoButton.Location.Y == 13)
                {
                    appendText = titleTextBox.Text;
                    AppendMediaInfo(directory, appendText, MediaProperty.Title);
                    titleTextBox.ResetText();
                    titleTextBox.Text = appendText;
                    item.Text = appendText;

                    activeItem.Title = appendText;

                    if (nameChecked && ascendingChecked) SortMedia(seriesCatalogue, SortType.Name, Order.Ascending);
                    else if (nameChecked && descendingChecked) SortMedia(seriesCatalogue, SortType.Name, Order.Descending);
                    else if (durationChecked && ascendingChecked) SortMedia(seriesCatalogue, SortType.Duration, Order.Ascending);
                    else if (durationChecked && descendingChecked) SortMedia(seriesCatalogue, SortType.Duration, Order.Descending);
                    else if (yearChecked && ascendingChecked) SortMedia(seriesCatalogue, SortType.Year, Order.Ascending);
                    else if (yearChecked && descendingChecked) SortMedia(seriesCatalogue, SortType.Year, Order.Descending);
                    else if (ratingChecked && ascendingChecked) SortMedia(seriesCatalogue, SortType.Rating, Order.Ascending);
                    else if (ratingChecked && descendingChecked) SortMedia(seriesCatalogue, SortType.Rating, Order.Descending);

                    titleToolTip.SetToolTip(titleTextBox, appendText);
                }
                else if (saveInfoButton.Location.Y == 59)
                {
                    appendText = genreTextBox.Text;
                    AppendMediaInfo(directory, appendText, MediaProperty.Genre);
                    activeItem.Genre = appendText;

                    if (appendText == "" && seriesGenreCatalogue.Contains(genreInfo))
                    {
                        bool Exist = false;

                        foreach (ListViewItem series in seriesList.Items)
                        {
                            LibraryManager seriesTag = (LibraryManager)series.Tag;
                            if (seriesTag.Genre == genreInfo)
                            {
                                Exist = true;
                                break;
                            }
                        }

                        if (!Exist)
                            seriesGenreCatalogue.Remove(genreInfo);
                    }

                    if (!seriesGenreCatalogue.Contains(appendText))
                    {
                        seriesGenreCatalogue.Add(appendText);
                        seriesGenreCatalogue.Sort();

                        genreToolStripDropDownButton.DropDownItems.Clear();
                        genreToolStripDropDownButton.DropDownItems.Add("All").Click += allToolStripMenuItem_Click;
                        genreToolStripDropDownButton.DropDownItems.Add("-");

                        foreach (string genre in seriesGenreCatalogue)
                            genreToolStripDropDownButton.DropDownItems.Add(genre).Click += genreSelected_Click;
                    }
                }

                else if (saveInfoButton.Location.Y == 76)
                {
                    appendText = yearTextBox.Text;

                    try
                    {
                        int year = int.Parse(yearTextBox.Text);
                        AppendMediaInfo(directory, yearTextBox.Text, MediaProperty.Year);
                        activeItem.Year = year;

                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show("Couldn't save info: " + ex.Message);
                        yearTextBox.Text = yearInfo;
                    }
                }

                else if (saveInfoButton.Location.Y == 93)
                {
                    appendText = ratingTextBox.Text;

                    try
                    {
                        float rating = float.Parse(ratingTextBox.Text);
                        AppendMediaInfo(directory, ratingTextBox.Text, MediaProperty.Rating);
                        activeItem.Rating = rating;
                        activeItem.PRS = activeItem.Rating;
                    }
                    catch(Exception ex)
                    {
                        MessageBox.Show("Couldn't save info: " + ex.Message);
                        ratingTextBox.Text = ratingInfo;
                    }
                    
                }
            }

            saveInfoButton.Visible = false;
            titleInfo = null;
            genreInfo = null;
            yearInfo = null;
            ratingInfo = null;
            newSave = true;
        }

        private void moreInfoLinkLabel_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            LibraryManager activeItem;
            if (this.movieList.Visible) activeItem = (LibraryManager)this.movieList.FocusedItem.Tag;
            else if (this.musicList.Visible) activeItem = (LibraryManager)this.musicList.FocusedItem.Tag;
            else if (this.seriesList.Visible) activeItem = (LibraryManager)this.seriesList.FocusedItem.Tag;
            else activeItem = null;

            MoreInfoForm form = new MoreInfoForm(activeItem, this);
            form.ShowDialog();
        }

        private void TextBoxLoseFocus_MouseClick(object sender, MouseEventArgs e)
        {
            infoPanel.Focus();
        }
        
        #region Title Text Box
        
        string titleInfo;
        private void titleTextBox_Click(object sender, EventArgs e)
        {
            if(titleInfo == null) titleInfo = titleTextBox.Text;

            if (this.infoPanel.Size.Width == 567) saveInfoButton.Location = new Point(518, 13);
            else saveInfoButton.Location = new Point(700, 13);

            currentTextBox = titleTextBox;
            infoPanel.Refresh();
        }

        private void titleTextBox_TextChanged(object sender, EventArgs e)
        {
            if (titleTextBox.Text != titleInfo && titleInfo != null) saveInfoButton.Visible = true;
            else saveInfoButton.Visible = false;
        }

        private void titleTextBox_Leave(object sender, EventArgs e)
        {
            if(!saveInfoButton.Focused)
            {
                titleTextBox.ResetText();
                titleTextBox.Text = titleInfo;
                titleInfo = null;
            }

            currentTextBox = null;
            infoPanel.Refresh();
        }

        #endregion

        #region Genre Text Box

        string genreInfo;
        private void genreTextBox_Click(object sender, EventArgs e)
        {
            if (genreInfo == null) genreInfo = genreTextBox.Text;

            saveInfoButton.Location = new Point(genreTextBox.Location.X + genreTextBox.Width + 10, 59);

            currentTextBox = genreTextBox;
            infoPanel.Refresh();
        }

        private void genreTextBox_TextChanged(object sender, EventArgs e)
        {
            if (genreTextBox.Text != genreInfo && genreInfo != null) saveInfoButton.Visible = true;
            else saveInfoButton.Visible = false;
        }

        private void genreTextBox_Leave(object sender, EventArgs e)
        {
            if (!saveInfoButton.Focused)
            {
                genreTextBox.ResetText();
                genreTextBox.Text = genreInfo;
                genreInfo = null;
            }

            currentTextBox = null;
            infoPanel.Refresh();
        }

        #endregion

        #region Year Text Box

        string yearInfo;
        private void yearTextBox_Click(object sender, EventArgs e)
        {
            if (yearInfo == null) yearInfo = yearTextBox.Text;

            saveInfoButton.Location = new Point(yearTextBox.Location.X + yearTextBox.Width + 10, 76);

            currentTextBox = yearTextBox;
            infoPanel.Refresh();
        }

        private void yearTextBox_TextChanged(object sender, EventArgs e)
        {
            if (yearTextBox.Text != yearInfo && yearInfo != null) saveInfoButton.Visible = true;
            else saveInfoButton.Visible = false;
        }

        private void yearTextBox_Leave(object sender, EventArgs e)
        {
            if (!saveInfoButton.Focused)
            {
                yearTextBox.ResetText();
                yearTextBox.Text = yearInfo;
                yearInfo = null;
            }

            currentTextBox = null;
            infoPanel.Refresh();
        }

        #endregion

        #region Rating Text Box

        string ratingInfo;
        private void ratingTextBox_Click(object sender, EventArgs e)
        {
            if (ratingInfo == null) ratingInfo = ratingTextBox.Text;

            saveInfoButton.Location = new Point(ratingTextBox.Location.X + ratingTextBox.Width + 10, 93);

            currentTextBox = ratingTextBox;
            infoPanel.Refresh();
        }

        private void ratingTextBox_TextChanged(object sender, EventArgs e)
        {
            if (ratingTextBox.Text != ratingInfo && ratingInfo != null) saveInfoButton.Visible = true;
            else saveInfoButton.Visible = false;
        }

        private void ratingTextBox_Leave(object sender, EventArgs e)
        {
            if (!saveInfoButton.Focused)
            {
                ratingTextBox.ResetText();
                ratingTextBox.Text = ratingInfo;
                ratingInfo = null;
            }

            currentTextBox = null;
            infoPanel.Refresh();
        }

        #endregion

        private void movieList_VisibleChanged(object sender, EventArgs e)
        {
            string checkedItems;
            ToolStripMenuItem menuItem;

            if (!movieList.Visible && newSave)
            {
                this.movieList.Items.Clear();
                foreach (LibraryManager movie in movieCatalogue) this.movieList.Items.Add(movie.Title).Tag = movie;
                newSave = false;
            }

            if (movieItemSelected == 0 && movieList.Visible)
            {
                sendMultiButton.Enabled = false;
                selectedItemsLabel.Visible = false;
            }
            else if(movieItemSelected != 0 && movieList.Visible)
            {
                sendMultiButton.Enabled = true;
                selectedItemsLabel.Visible = true;
            }

            if (movieList.Visible)
            {
                checkedItems = movieList.Tag.ToString();
                for (int i = 0; i < 4; i++)
                {
                    menuItem = (ToolStripMenuItem)sortToolStripDropDownButton.DropDownItems[i];
                    if (sortToolStripDropDownButton.DropDownItems[i] == sortToolStripDropDownButton.DropDownItems[int.Parse(checkedItems[0].ToString())])
                        menuItem.Checked = true;
                    else
                        menuItem.Checked = false;
                }

                foreach (ToolStripMenuItem item in orderToolStripMenuItem.DropDownItems)
                {
                    if (item == orderToolStripMenuItem.DropDownItems[int.Parse(checkedItems[1].ToString())])
                        item.Checked = true;
                    else
                        item.Checked = false;
                }
            }
        }

        private void musicList_VisibleChanged(object sender, EventArgs e)
        {
            string checkedItems;
            ToolStripMenuItem menuItem;

            if (!musicList.Visible && newSave)
            {
                this.musicList.Items.Clear();
                foreach (LibraryManager music in musicCatalogue) this.musicList.Items.Add(music.Title).Tag = music;
                newSave = false;
            }

            if (musicItemSelected == 0 && musicList.Visible)
            {
                sendMultiButton.Enabled = false;
                selectedItemsLabel.Visible = false;
            }
            else if(musicItemSelected != 0 && musicList.Visible)
            {
                sendMultiButton.Enabled = true;
                selectedItemsLabel.Visible = false;
            }

            if (musicList.Visible)
            {
                checkedItems = musicList.Tag.ToString();
                for (int i = 0; i < 4; i++)
                {
                    menuItem = (ToolStripMenuItem)sortToolStripDropDownButton.DropDownItems[i];
                    if (sortToolStripDropDownButton.DropDownItems[i] == sortToolStripDropDownButton.DropDownItems[int.Parse(checkedItems[0].ToString())])
                        menuItem.Checked = true;
                    else
                        menuItem.Checked = false;
                }

                foreach (ToolStripMenuItem item in orderToolStripMenuItem.DropDownItems)
                {
                    if (item == orderToolStripMenuItem.DropDownItems[int.Parse(checkedItems[1].ToString())])
                        item.Checked = true;
                    else
                        item.Checked = false;
                }
            }
        }

        private void seriesList_VisibleChanged(object sender, EventArgs e)
        {
            string checkedItems;
            ToolStripMenuItem menuItem;
            
            if (!seriesList.Visible && newSave)
            {
                this.seriesList.Items.Clear();
                foreach (LibraryManager series in seriesCatalogue) this.seriesList.Items.Add(series.Title).Tag = series;
                newSave = false;
            }

            if (seriesItemSelected == 0 && seriesList.Visible)
            {
                sendMultiButton.Enabled = false;
                selectedItemsLabel.Visible = false;
            }
            else if(seriesItemSelected != 0 && seriesList.Visible)
            {
                sendMultiButton.Enabled = true;
                selectedItemsLabel.Visible = true;
            }

            if (seriesList.Visible)
            {
                checkedItems = seriesList.Tag.ToString();
                for (int i = 0; i < 4; i++)
                {
                    menuItem = (ToolStripMenuItem)sortToolStripDropDownButton.DropDownItems[i];
                    if (sortToolStripDropDownButton.DropDownItems[i] == sortToolStripDropDownButton.DropDownItems[int.Parse(checkedItems[0].ToString())])
                        menuItem.Checked = true;
                    else
                        menuItem.Checked = false;
                }

                foreach (ToolStripMenuItem item in orderToolStripMenuItem.DropDownItems)
                {
                    if (item == orderToolStripMenuItem.DropDownItems[int.Parse(checkedItems[1].ToString())])
                        item.Checked = true;
                    else
                        item.Checked = false;
                }
            }
        }

        private void sendMultiButton_Click(object sender, EventArgs e)
        {
            try
            {
                if (reference.customers == 0) throw new Exception();
                else
                {

                    CartManager cart = (CartManager)reference.cartLabel.Tag;
                    LibraryManager aboutMedia;
                    if (movieList.Visible)
                    {
                        foreach (ListViewItem fileName in movieList.CheckedItems)
                        {
                            aboutMedia = (LibraryManager)fileName.Tag;

                            if (!cart.ContainsMedia(aboutMedia))
                                cart.AddMedia(aboutMedia);
                            fileName.Checked = false;
                        }

                        sendMultiButton.Enabled = false;
                        movieItemSelected = 0;
                    }
                    else if (musicList.Visible)
                    {
                        foreach (ListViewItem fileName in musicList.CheckedItems)
                        {
                            aboutMedia = (LibraryManager)fileName.Tag;

                            if (!cart.ContainsMedia(aboutMedia))
                                cart.AddMedia(aboutMedia);
                            fileName.Checked = false;
                        }

                        sendMultiButton.Enabled = false;
                        musicItemSelected = 0;
                    }
                    else if (seriesList.Visible)
                    {
                        foreach (ListViewItem fileName in seriesList.CheckedItems)
                        {
                            aboutMedia = (LibraryManager)fileName.Tag;

                            if (!cart.ContainsMedia(aboutMedia))
                                cart.AddMedia(aboutMedia);
                            fileName.Checked = false;
                        }

                        sendMultiButton.Enabled = false;
                        seriesItemSelected = 0;
                    }
                }
            }
            catch (Exception)
            {
                DialogResult result = MessageBox.Show("There are currently no active carts available. Click OK to add to a cart.", "Empty Slot", MessageBoxButtons.OKCancel);
                if (result == DialogResult.OK)
                {
                    reference.newCartToolStripButton.PerformClick();
                    sendMultiButton.PerformClick();
                }
            }
        }

        private void ratingToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (ratingChecked == false)
            {
                ratingChecked = true;
                nameChecked = false;
                yearChecked = false;
                durationChecked = false;
                yearToolStripMenuItem.Checked = false;
                nameToolStripMenuItem.Checked = false;
                durationToolStripMenuItem.Checked = false;
                if (movieList.Visible && ascendingChecked)
                {
                    SortMedia(movieCatalogue, SortType.Rating, Order.Ascending);
                    this.movieList.Items.Clear();
                    reloadMediaList(MediaType.Movie);
                    movieList.Tag = "30";
                }
                else if (movieList.Visible && descendingChecked)
                {
                    SortMedia(movieCatalogue, SortType.Rating, Order.Descending);
                    this.movieList.Items.Clear();
                    reloadMediaList(MediaType.Movie);
                    movieList.Tag = "31";
                }
                else if (musicList.Visible && ascendingChecked)
                {
                    SortMedia(musicCatalogue, SortType.Rating, Order.Ascending);
                    this.musicList.Items.Clear();
                    reloadMediaList(MediaType.Music);
                    musicList.Tag = "30";
                }
                else if (musicList.Visible && descendingChecked)
                {
                    SortMedia(musicCatalogue, SortType.Rating, Order.Descending);
                    this.musicList.Items.Clear();
                    reloadMediaList(MediaType.Music);
                    musicList.Tag = "31";
                }
                else if (seriesList.Visible && ascendingChecked)
                {
                    SortMedia(seriesCatalogue, SortType.Rating, Order.Ascending);
                    this.seriesList.Items.Clear();
                    reloadMediaList(MediaType.Series);
                    seriesList.Tag = "30";
                }
                else if (seriesList.Visible && descendingChecked)
                {
                    SortMedia(seriesCatalogue, SortType.Rating, Order.Descending);
                    this.seriesList.Items.Clear();
                    reloadMediaList(MediaType.Series);
                    seriesList.Tag = "31";
                }
            }
            else
            {
                ratingToolStripMenuItem.Checked = true;
                yearToolStripMenuItem.Checked = false;
                nameToolStripMenuItem.Checked = false;
                durationToolStripMenuItem.Checked = false;
            }
        }

        private void yearToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (yearChecked == false)
            {
                yearChecked = true;
                ratingChecked = false;
                nameChecked = false;
                durationChecked = false;
                nameToolStripMenuItem.Checked = false;
                ratingToolStripMenuItem.Checked = false;
                durationToolStripMenuItem.Checked = false;
                if (movieList.Visible && ascendingChecked)
                {
                    SortMedia(movieCatalogue, SortType.Year, Order.Ascending);
                    this.movieList.Items.Clear();
                    reloadMediaList(MediaType.Movie);
                    movieList.Tag = "20";
                }
                else if (movieList.Visible && descendingChecked)
                {
                    SortMedia(movieCatalogue, SortType.Year, Order.Descending);
                    this.movieList.Items.Clear();
                    reloadMediaList(MediaType.Movie);
                    movieList.Tag = "21";
                }
                else if (musicList.Visible && ascendingChecked)
                {
                    SortMedia(musicCatalogue, SortType.Year, Order.Ascending);
                    this.musicList.Items.Clear();
                    reloadMediaList(MediaType.Music);
                    musicList.Tag = "20";
                }
                else if (musicList.Visible && descendingChecked)
                {
                    SortMedia(musicCatalogue, SortType.Year, Order.Descending);
                    this.musicList.Items.Clear();
                    reloadMediaList(MediaType.Music);
                    musicList.Tag = "21";
                }
                else if (seriesList.Visible && ascendingChecked)
                {
                    SortMedia(seriesCatalogue, SortType.Year, Order.Ascending);
                    this.seriesList.Items.Clear();
                    reloadMediaList(MediaType.Series);
                    seriesList.Tag = "20";
                }
                else if (seriesList.Visible && descendingChecked)
                {
                    SortMedia(seriesCatalogue, SortType.Year, Order.Descending);
                    this.seriesList.Items.Clear();
                    reloadMediaList(MediaType.Series);
                    seriesList.Tag = "21";
                }
            }
            else
            {
                yearToolStripMenuItem.Checked = true;
                nameToolStripMenuItem.Checked = false;
                ratingToolStripMenuItem.Checked = false;
                durationToolStripMenuItem.Checked = false;
            }
        }

        private void durationToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (durationChecked == false)
            {
                durationChecked = true;
                ratingChecked = false;
                yearChecked = false;
                nameChecked = false;
                yearToolStripMenuItem.Checked = false;
                ratingToolStripMenuItem.Checked = false;
                nameToolStripMenuItem.Checked = false;
                if (movieList.Visible && ascendingChecked)
                {
                    SortMedia(movieCatalogue, SortType.Duration, Order.Ascending);
                    this.movieList.Items.Clear();
                    reloadMediaList(MediaType.Movie);
                    movieList.Tag = "10";
                }
                else if (movieList.Visible && descendingChecked)
                {
                    SortMedia(movieCatalogue, SortType.Duration, Order.Descending);
                    this.movieList.Items.Clear();
                    reloadMediaList(MediaType.Movie);
                    movieList.Tag = "11";
                }
                else if (musicList.Visible && ascendingChecked)
                {
                    SortMedia(musicCatalogue, SortType.Duration, Order.Ascending);
                    this.musicList.Items.Clear();
                    reloadMediaList(MediaType.Music);
                    musicList.Tag = "10";
                }
                else if (musicList.Visible && descendingChecked)
                {
                    SortMedia(musicCatalogue, SortType.Duration, Order.Descending);
                    this.musicList.Items.Clear();
                    reloadMediaList(MediaType.Music);
                    musicList.Tag = "11";
                }
                else if (seriesList.Visible && ascendingChecked)
                {
                    SortMedia(seriesCatalogue, SortType.Duration, Order.Ascending);
                    this.seriesList.Items.Clear();
                    reloadMediaList(MediaType.Series);
                    seriesList.Tag = "10";
                }
                else if (seriesList.Visible && descendingChecked)
                {
                    SortMedia(seriesCatalogue, SortType.Duration, Order.Descending);
                    this.seriesList.Items.Clear();
                    reloadMediaList(MediaType.Series);
                    seriesList.Tag = "11";
                }
            }
            else
            {
                durationToolStripMenuItem.Checked = true;
                yearToolStripMenuItem.Checked = false;
                ratingToolStripMenuItem.Checked = false;
                nameToolStripMenuItem.Checked = false;
            }
        }

        private void nameToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (nameChecked == false)
            {
                nameChecked = true;
                ratingChecked = false;
                yearChecked = false;
                durationChecked = false;
                yearToolStripMenuItem.Checked = false;
                ratingToolStripMenuItem.Checked = false;
                durationToolStripMenuItem.Checked = false;

                if (movieList.Visible && ascendingChecked)
                {
                    SortMedia(movieCatalogue, SortType.Name, Order.Ascending);
                    this.movieList.Items.Clear();
                    reloadMediaList(MediaType.Movie);
                    movieList.Tag = "00";
                }
                else if (movieList.Visible && descendingChecked)
                {
                    SortMedia(movieCatalogue, SortType.Name, Order.Descending);
                    this.movieList.Items.Clear();
                    reloadMediaList(MediaType.Movie);
                    movieList.Tag = "01";
                }
                else if (musicList.Visible && ascendingChecked)
                {
                    SortMedia(musicCatalogue, SortType.Name, Order.Ascending);
                    this.musicList.Items.Clear();
                    reloadMediaList(MediaType.Music);
                    musicList.Tag = "00";
                }
                else if (musicList.Visible && descendingChecked)
                {
                    SortMedia(musicCatalogue, SortType.Name, Order.Descending);
                    this.musicList.Items.Clear();
                    reloadMediaList(MediaType.Music);
                    musicList.Tag = "01";
                }
                else if (seriesList.Visible && ascendingChecked)
                {
                    SortMedia(seriesCatalogue, SortType.Name, Order.Ascending);
                    this.seriesList.Items.Clear();
                    reloadMediaList(MediaType.Series);
                    seriesList.Tag = "00";
                }
                else if (seriesList.Visible && descendingChecked)
                {
                    SortMedia(seriesCatalogue, SortType.Name, Order.Descending);
                    this.seriesList.Items.Clear();
                    reloadMediaList(MediaType.Series);
                    seriesList.Tag = "01";
                }
            }
            else
            {
                nameToolStripMenuItem.Checked = true;
                yearToolStripMenuItem.Checked = false;
                ratingToolStripMenuItem.Checked = false;
                durationToolStripMenuItem.Checked = false;
            }
            
        }

        private void ascendingToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if(ascendingChecked == false)
            {
                descendingChecked = false;
                ascendingChecked = true;
                descendingToolStripMenuItem.Checked = false;

                if (movieList.Visible && nameChecked)
                {
                    SortMedia(movieCatalogue, SortType.Name, Order.Ascending);
                    this.movieList.Items.Clear();
                    reloadMediaList(MediaType.Movie);
                    movieList.Tag = "00";
                }
                else if(movieList.Visible && durationChecked)
                {
                    SortMedia(movieCatalogue, SortType.Duration, Order.Ascending);
                    this.movieList.Items.Clear();
                    reloadMediaList(MediaType.Movie);
                    movieList.Tag = "10";
                }
                else if (movieList.Visible && ratingChecked)
                {
                    SortMedia(movieCatalogue, SortType.Rating, Order.Ascending);
                    this.movieList.Items.Clear();
                    reloadMediaList(MediaType.Movie);
                    movieList.Tag = "30";
                }
                else if (movieList.Visible && yearChecked)
                {
                    SortMedia(movieCatalogue, SortType.Year, Order.Ascending);
                    this.movieList.Items.Clear();
                    reloadMediaList(MediaType.Movie);
                    movieList.Tag = "20";
                }
                else if (musicList.Visible && nameChecked)
                {
                    SortMedia(musicCatalogue, SortType.Name, Order.Ascending);
                    this.musicList.Items.Clear();
                    reloadMediaList(MediaType.Music);
                    musicList.Tag = "00";
                }
                else if (musicList.Visible && durationChecked)
                {
                    SortMedia(musicCatalogue, SortType.Duration, Order.Ascending);
                    this.musicList.Items.Clear();
                    reloadMediaList(MediaType.Music);
                    musicList.Tag = "10";
                }
                else if (musicList.Visible && yearChecked)
                {
                    SortMedia(musicCatalogue, SortType.Year, Order.Ascending);
                    this.musicList.Items.Clear();
                    reloadMediaList(MediaType.Music);
                    musicList.Tag = "20";
                }
                else if (musicList.Visible && ratingChecked)
                {
                    SortMedia(musicCatalogue, SortType.Rating, Order.Ascending);
                    this.musicList.Items.Clear();
                    reloadMediaList(MediaType.Music);
                    musicList.Tag = "30";
                }
                else if(seriesList.Visible && nameChecked)
                {
                    SortMedia(seriesCatalogue, SortType.Name, Order.Ascending);
                    this.seriesList.Items.Clear();
                    reloadMediaList(MediaType.Series);
                    seriesList.Tag = "00";
                }
                else if (seriesList.Visible && durationChecked)
                {
                    SortMedia(seriesCatalogue, SortType.Duration, Order.Ascending);
                    this.seriesList.Items.Clear();
                    reloadMediaList(MediaType.Series);
                    seriesList.Tag = "10";
                }
                else if (seriesList.Visible && yearChecked)
                {
                    SortMedia(seriesCatalogue, SortType.Year, Order.Ascending);
                    this.seriesList.Items.Clear();
                    reloadMediaList(MediaType.Series);
                    seriesList.Tag = "20";
                }
                else if (seriesList.Visible && ratingChecked)
                {
                    SortMedia(seriesCatalogue, SortType.Rating, Order.Ascending);
                    this.seriesList.Items.Clear();
                    reloadMediaList(MediaType.Series);
                    seriesList.Tag = "30";
                }
            }
            else
            {
                ascendingToolStripMenuItem.Checked = true;
                descendingToolStripMenuItem.Checked = false;
            }
        }

        private void descendingToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if(descendingChecked == false)
            {
                ascendingChecked = false;
                descendingChecked = true;
                ascendingToolStripMenuItem.Checked = false;

                if (movieList.Visible && nameChecked)
                {
                    SortMedia(movieCatalogue, SortType.Name, Order.Descending);
                    this.movieList.Items.Clear();
                    reloadMediaList(MediaType.Movie);
                    movieList.Tag = "01";
                }
                else if (movieList.Visible && durationChecked)
                {
                    SortMedia(movieCatalogue, SortType.Duration, Order.Descending);
                    this.movieList.Items.Clear();
                    reloadMediaList(MediaType.Movie);
                    movieList.Tag = "11";
                }
                else if (movieList.Visible && yearChecked)
                {
                    SortMedia(movieCatalogue, SortType.Year, Order.Descending);
                    this.movieList.Items.Clear();
                    reloadMediaList(MediaType.Movie);
                    movieList.Tag = "21";
                }
                else if (movieList.Visible && ratingChecked)
                {
                    SortMedia(movieCatalogue, SortType.Rating, Order.Descending);
                    this.movieList.Items.Clear();
                    reloadMediaList(MediaType.Movie);
                    movieList.Tag = "31";
                }
                else if (musicList.Visible && nameChecked)
                {
                    SortMedia(musicCatalogue, SortType.Name, Order.Descending);
                    this.musicList.Items.Clear();
                    reloadMediaList(MediaType.Music);
                    musicList.Tag = "01";
                }
                else if (musicList.Visible && durationChecked)
                {
                    SortMedia(musicCatalogue, SortType.Duration, Order.Descending);
                    this.musicList.Items.Clear();
                    reloadMediaList(MediaType.Music);
                    musicList.Tag = "11";
                }
                else if (musicList.Visible && yearChecked)
                {
                    SortMedia(musicCatalogue, SortType.Year, Order.Descending);
                    this.musicList.Items.Clear();
                    reloadMediaList(MediaType.Music);
                    musicList.Tag = "21";
                }
                else if (musicList.Visible && ratingChecked)
                {
                    SortMedia(musicCatalogue, SortType.Rating, Order.Descending);
                    this.musicList.Items.Clear();
                    reloadMediaList(MediaType.Music);
                    musicList.Tag = "31";
                }
                else if (seriesList.Visible && nameChecked)
                {
                    SortMedia(seriesCatalogue, SortType.Name, Order.Descending);
                    this.seriesList.Items.Clear();
                    reloadMediaList(MediaType.Series);
                    seriesList.Tag = "01";
                }
                else if (seriesList.Visible && durationChecked)
                {
                    SortMedia(seriesCatalogue, SortType.Duration, Order.Descending);
                    this.seriesList.Items.Clear();
                    reloadMediaList(MediaType.Series);
                    seriesList.Tag = "11";
                }
                else if (seriesList.Visible && yearChecked)
                {
                    SortMedia(seriesCatalogue, SortType.Year, Order.Descending);
                    this.seriesList.Items.Clear();
                    reloadMediaList(MediaType.Series);
                    seriesList.Tag = "21";
                }
                else if (seriesList.Visible && ratingChecked)
                {
                    SortMedia(seriesCatalogue, SortType.Rating, Order.Descending);
                    this.seriesList.Items.Clear();
                    reloadMediaList(MediaType.Series);
                    seriesList.Tag = "31";
                }
            }
            else
            {
                descendingToolStripMenuItem.Checked = true;
                ascendingToolStripMenuItem.Checked = false;
            }
            
        }

        private void cartButton_Click(object sender, EventArgs e)
        {
            CartManager cart;
            LibraryManager media;

            if (!reference.activationPanel.Visible)
            {
                try
                {
                    if (reference.customers == 0) throw new Exception();
                    else
                    {
                        cart = (CartManager)reference.cartLabel.Tag;

                        if (movieList.Visible) media = (LibraryManager)movieList.FocusedItem.Tag;
                        else if (musicList.Visible)
                        {
                            media = (LibraryManager)musicList.FocusedItem.Tag;
                        }

                        else if (seriesList.Visible) media = (LibraryManager)seriesList.FocusedItem.Tag;
                        else media = null;

                        if (!cart.ContainsMedia(media))
                            cart.AddMedia(media);
                    }
                }
                catch (Exception)
                {
                    DialogResult result = MessageBox.Show("There are currently no active carts available. Click OK to add to a cart.", "Empty Slot", MessageBoxButtons.OKCancel);
                    if (result == DialogResult.OK)
                    {
                        reference.newCartToolStripButton.PerformClick();
                        cartButton.PerformClick();
                    }
                }
            }
        }

        public void genreSelected_Click(object sender, EventArgs e)
        {
            ToolStripDropDownItem item = (ToolStripDropDownItem)sender;
            genreListView.Visible = true;
            genreListView.Items.Clear();

            if (movieList.Visible)
            {
                foreach (LibraryManager movie in movieCatalogue)
                    if (movie.Genre == item.Text)
                    {
                        genreListView.Items.Add(new ListViewItem
                        {
                            Text = movie.Title,
                            Tag = movie,
                            ImageIndex = 0
                        });
                    }
                        
            }
            else if (musicList.Visible)
            {
                foreach (LibraryManager music in musicCatalogue)
                    if (music.Genre == item.Text)
                    {
                        genreListView.Items.Add(new ListViewItem
                        {
                            Text = music.Title,
                            Tag = music,
                            ImageIndex = 0
                        });
                    }
            }
            else if (seriesList.Visible)
            {
                foreach (LibraryManager series in seriesCatalogue)
                    if (series.Genre == item.Text)
                    {
                        genreListView.Items.Add(new ListViewItem
                        {
                            Text = series.Title,
                            Tag = series,
                            ImageIndex = 0
                        });
                    }
            }

            genreDescriptionLabel.Text = item.Text;
        }

        private void movieList_ItemCheck(object sender, ItemCheckEventArgs e)
        {
            if (e.CurrentValue == CheckState.Checked) movieItemSelected--;
            else movieItemSelected++;

            if (!reference.activationPanel.Visible)
            {
                if (movieItemSelected == 0 && movieList.Visible)
                {
                    sendMultiButton.Enabled = false;
                    selectedItemsLabel.Visible = false;
                }
                else
                {
                    sendMultiButton.Enabled = true;
                    selectedItemsLabel.Visible = true;

                    selectedItemsLabel.Text = movieItemSelected.ToString();
                }
            }
        }

        private void musicList_ItemCheck(object sender, ItemCheckEventArgs e)
        {
            if (e.CurrentValue == CheckState.Checked) musicItemSelected--;
            else musicItemSelected++;

            if (!reference.activationPanel.Visible)
            {
                if (musicItemSelected == 0 && musicList.Visible)
                {
                    sendMultiButton.Enabled = false;
                    selectedItemsLabel.Visible = false;
                }
                else
                {
                    sendMultiButton.Enabled = true;
                    selectedItemsLabel.Visible = true;

                    selectedItemsLabel.Text = musicItemSelected.ToString();
                }
            }
        }

        private void seriesList_ItemCheck(object sender, ItemCheckEventArgs e)
        {
            if (e.CurrentValue == CheckState.Checked) seriesItemSelected--;
            else seriesItemSelected++;

            if (!reference.activationPanel.Visible)
            {
                if (seriesItemSelected == 0 && seriesList.Visible)
                {
                    sendMultiButton.Enabled = false;
                    selectedItemsLabel.Visible = false;
                }
                else
                {
                    sendMultiButton.Enabled = true;
                    selectedItemsLabel.Visible = true;

                    selectedItemsLabel.Text = seriesItemSelected.ToString();

                }
            }
        }

        private void LibraryForm_Leave(object sender, EventArgs e)
        {
            foreach(ListViewItem ticked in movieList.CheckedItems)
                ticked.Checked = false;
            foreach (ListViewItem ticked in musicList.CheckedItems)
                ticked.Checked = false;
            foreach (ListViewItem ticked in seriesList.CheckedItems)
                ticked.Checked = false;
        }

        private void TextBox_KeyPress(object sender, KeyPressEventArgs e)
        {
            if(e.KeyChar == (char)Keys.Enter)
            {
                saveInfoButton.PerformClick();
                infoPanel.Focus();

                if ((RichTextBox)sender == titleTextBox) titleTextBox.Text = appendText;
                else if ((RichTextBox)sender == genreTextBox) genreTextBox.Text = appendText;
                else if ((RichTextBox)sender == yearTextBox) yearTextBox.Text = appendText;
                else if ((RichTextBox)sender == ratingTextBox) ratingTextBox.Text = appendText;
            }
        }

        private void infoPanel_Paint(object sender, PaintEventArgs e)
        {
            if(currentTextBox == titleTextBox)
            {
                titleTextBox.BackColor = infoPanel.BackColor;
            }
            else if(currentTextBox == genreTextBox)
            {
                genreTextBox.BackColor = infoPanel.BackColor;
            }
            else if(currentTextBox == yearTextBox)
            {
                yearTextBox.BackColor = infoPanel.BackColor;
            }
            else if(currentTextBox == ratingTextBox)
            {
                ratingTextBox.BackColor = infoPanel.BackColor;
            }
            else
            {
                titleTextBox.BackColor = infoPanel.BackColor;
                genreTextBox.BackColor = Media_Distro.Properties.Settings.Default.Active_Theme_InfoPanel;
                yearTextBox.BackColor = Media_Distro.Properties.Settings.Default.Active_Theme_InfoPanel;
                ratingTextBox.BackColor = Media_Distro.Properties.Settings.Default.Active_Theme_InfoPanel;
            }
        }

        private void albumTreeView_AfterCheck(object sender, TreeViewEventArgs e)
        {
            if(e.Action == TreeViewAction.ByMouse)
            {
                TreeNode checkedNode = e.Node;

                if(checkedNode.Parent == null)
                    foreach (TreeNode node in checkedNode.Nodes)
                        node.Checked = checkedNode.Checked;
                else
                {
                    foreach (TreeNode node in checkedNode.Parent.Nodes)
                    {
                        if (node.Checked)
                            node.Parent.Checked = true;
                        else
                        {
                            node.Parent.Checked = false;
                            break;
                        }
                    }   
                }
            }
        }

        private void addSTCart_Click(object sender, EventArgs e)
        {
            if (!reference.activationPanel.Visible)
            {
                List<TreeNode> checkedNodes = new List<TreeNode>();
                foreach (TreeNode node in albumTreeView.Nodes)
                {
                    if (node.Parent == null && node.Checked)
                        checkedNodes.Add(node);
                    else
                        foreach (TreeNode subNode in node.Nodes)
                            if (subNode.Checked)
                                checkedNodes.Add(subNode);
                }

                try
                {
                    if (reference.customers == 0) 
                        throw new Exception();
                    else
                    {

                        CartManager cart = (CartManager)reference.cartLabel.Tag;
                        LibraryManager aboutMedia;

                        foreach (TreeNode node in checkedNodes)
                        {
                            if (node.Tag is string)
                            {
                                aboutMedia = new LibraryManager((string)node.Tag, MediaType.Series, true);
                                node.Checked = false;

                                foreach (TreeNode subNode in node.Nodes)
                                    subNode.Checked = false;
                            }
                            else
                            {
                                aboutMedia = (LibraryManager)node.Tag;
                                node.Checked = false;
                            }


                            if (!cart.ContainsMedia(aboutMedia))
                                cart.AddMedia(aboutMedia);
                        }
                    }
                }
                catch (Exception)
                {
                    DialogResult result = MessageBox.Show("There are currently no active carts available. Click OK to add to a cart.", "Empty Slot", MessageBoxButtons.OKCancel);
                    if (result == DialogResult.OK)
                    {
                        reference.newCartToolStripButton.PerformClick();
                        addSTCart.PerformClick();
                    }
                }
            }
        }

        private void allToolStripMenuItem_Click(object sender, EventArgs e)
        {
            genreListView.Visible = false;
            genreDescriptionLabel.Text = "All";
        }

        private void hideInfoButton_Click(object sender, EventArgs e)
        {
            infoPanel.Visible = false;
            item = null;
            if (libraryPanel.Width != 725) libraryPanel.SetBounds(12, 12, 546, 431);
            else libraryPanel.SetBounds(12, 12, 725, 431);
        }

        private void removeCoverArtToolStripMenuItem_Click(object sender, EventArgs e)
        {
            LibraryManager media;

            if((int)coverPictureBox.Tag != 0)
            {
                if (movieList.Visible)
                {
                    media = (LibraryManager)movieList.FocusedItem.Tag;
                    movieList.FocusedItem.ImageIndex = 0;
                    AppendMediaInfo(media.thisDirectory, "", MediaProperty.Cover_Art_Dir);
                }
                else if (musicList.Visible)
                {
                    media = (LibraryManager)musicList.FocusedItem.Tag;
                    musicList.FocusedItem.ImageIndex = 0;
                    if (Exists(media.thisDirectory))
                        AppendMediaInfo(GetFiles(media.thisDirectory)[0], "", MediaProperty.Cover_Art_Dir);
                    else
                        AppendMediaInfo(media.thisDirectory, "", MediaProperty.Cover_Art_Dir);
                }
                else if (seriesList.Visible)
                {
                    media = (LibraryManager)seriesList.FocusedItem.Tag;
                    seriesList.FocusedItem.ImageIndex = 0;
                    AppendMediaInfo(GetFiles(media.thisDirectory)[0], "", MediaProperty.Cover_Art_Dir);
                }
                else
                    media = null;

                media.CoverArtDirectory = null;
                coverPictureBox.Image = null;    
            }

        }   

        private void reloadMediaList(MediaType type)
        {
            if(type == MediaType.Movie)
            {
                moiter = 1;
                for (int i = movieCoverArtImageList.Images.Count - 1; i > 0; i--)
                    movieCoverArtImageList.Images.RemoveAt(i);

                foreach (LibraryManager movie in movieCatalogue)
                {
                    if (movie.CoverArtDirectory != null && File.Exists(movie.CoverArtDirectory))
                    {
                        movieList.LargeImageList.Images.Add(Image.FromFile(movie.CoverArtDirectory));
                        movieList.Items.Add(new ListViewItem
                        {
                            Text = movie.Title,
                            Tag = movie,
                            ImageIndex = moiter++
                        });
                    }
                    else
                    {
                        movieList.Items.Add(new ListViewItem
                        {
                            Text = movie.Title,
                            Tag = movie,
                            ImageIndex = 0
                        });
                    }
                }
            }
            else if(type == MediaType.Music)
            {
                muiter = 1;
                for (int i = musicCoverArtImageList.Images.Count - 1; i > 0; i--)
                    musicCoverArtImageList.Images.RemoveAt(i);

                foreach (LibraryManager music in musicCatalogue)
                {
                    if (music.CoverArtDirectory != null && File.Exists(music.CoverArtDirectory))
                    {
                        musicList.LargeImageList.Images.Add(Image.FromFile(music.CoverArtDirectory));
                        musicList.Items.Add(new ListViewItem
                        {
                            Text = music.Title,
                            Tag = music,
                            ImageIndex = muiter++
                        });
                    }
                    else
                    {
                        musicList.Items.Add(new ListViewItem
                        {
                            Text = music.Title,
                            Tag = music,
                            ImageIndex = 0
                        });
                    }
                }
            }
            else if(type == MediaType.Series)
            {
                siter = 1;
                for (int i = seriesCoverArtImageList.Images.Count - 1; i > 0; i--)
                    seriesCoverArtImageList.Images.RemoveAt(i);

                foreach (LibraryManager series in seriesCatalogue)
                {
                    if (series.CoverArtDirectory != null && File.Exists(series.CoverArtDirectory))
                    {
                        seriesList.LargeImageList.Images.Add(Image.FromFile(series.CoverArtDirectory));
                        seriesList.Items.Add(new ListViewItem
                        {
                            Text = series.Title,
                            Tag = series,
                            ImageIndex = siter++
                        });
                    }
                    else
                    {
                        seriesList.Items.Add(new ListViewItem
                        {
                            Text = series.Title,
                            Tag = series,
                            ImageIndex = 0
                        });
                    }
                }
            }
        }
    }
}
