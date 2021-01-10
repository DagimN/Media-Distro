using System;
using System.IO;
using static System.IO.Path;
using System.Drawing;
using System.Windows.Forms;
using static Mobile_Service_Distribution.LibraryManager;

namespace Mobile_Service_Distribution.Forms
{
    public partial class MoreInfoForm : Form
    {
        private Label l;
        private LibraryManager mediaInfo;
        private LibraryForm reference;
        private string str;

        public MoreInfoForm(LibraryManager mediaInfo, LibraryForm reference)
        {
            InitializeComponent();

            this.mediaInfo = mediaInfo;
            this.reference = reference;

            nameDescripLabel.Text = mediaInfo.Name;
            if (nameDescripLabel.Height > nameDescripLabel.MaximumSize.Height)
            {
                titleLabel.Location = new Point(titleLabel.Location.X, titleLabel.Location.Y + (nameDescripLabel.Height - 18));
                titleDescripLabel.Location = new Point(titleDescripLabel.Location.X, titleDescripLabel.Location.Y + (nameDescripLabel.Height - 18));
                durationLabel.Location = new Point(durationLabel.Location.X, durationLabel.Location.Y + (nameDescripLabel.Height - 18));
                durationDescripLabel.Location = new Point(durationDescripLabel.Location.X, durationDescripLabel.Location.Y + (nameDescripLabel.Height - 18));
                genreLabel.Location = new Point(genreLabel.Location.X, genreLabel.Location.Y + (nameDescripLabel.Height - 18));
                genreDescripLabel.Location = new Point(genreDescripLabel.Location.X, genreDescripLabel.Location.Y + (nameDescripLabel.Height - 18));
                yearLabel.Location = new Point(yearLabel.Location.X, yearLabel.Location.Y + (nameDescripLabel.Height - 18));
                yearDescripLabel.Location = new Point(yearDescripLabel.Location.X, yearDescripLabel.Location.Y + (nameDescripLabel.Height - 18));
                ratingLabel.Location = new Point(ratingLabel.Location.X, ratingLabel.Location.Y + (nameDescripLabel.Height - 18));
                ratingDescripLabel.Location = new Point(ratingDescripLabel.Location.X, ratingDescripLabel.Location.Y + (nameDescripLabel.Height - 18));
                priceLabel.Location = new Point(priceLabel.Location.X, priceLabel.Location.Y + (nameDescripLabel.Height - 18));
                priceDescripLabel.Location = new Point(priceDescripLabel.Location.X, priceDescripLabel.Location.Y + (nameDescripLabel.Height - 18));
            }

            titleDescripLabel.Text = mediaInfo.Title;
            if (titleDescripLabel.Height > titleDescripLabel.MaximumSize.Height)
            {
                durationLabel.Location = new Point(durationLabel.Location.X, durationLabel.Location.Y + (titleDescripLabel.Height - 18));
                durationDescripLabel.Location = new Point(durationDescripLabel.Location.X, durationDescripLabel.Location.Y + (titleDescripLabel.Height - 18));
                genreLabel.Location = new Point(genreLabel.Location.X, genreLabel.Location.Y + (titleDescripLabel.Height - 18));
                genreDescripLabel.Location = new Point(genreDescripLabel.Location.X, genreDescripLabel.Location.Y + (titleDescripLabel.Height - 18));
                yearLabel.Location = new Point(yearLabel.Location.X, yearLabel.Location.Y + (titleDescripLabel.Height - 18));
                yearDescripLabel.Location = new Point(yearDescripLabel.Location.X, yearDescripLabel.Location.Y + (titleDescripLabel.Height - 18));
                ratingLabel.Location = new Point(ratingLabel.Location.X, ratingLabel.Location.Y + (titleDescripLabel.Height - 18));
                ratingDescripLabel.Location = new Point(ratingDescripLabel.Location.X, ratingDescripLabel.Location.Y + (titleDescripLabel.Height - 18));
                priceLabel.Location = new Point(priceLabel.Location.X, priceLabel.Location.Y + (titleDescripLabel.Height - 18));
                priceDescripLabel.Location = new Point(priceDescripLabel.Location.X, priceDescripLabel.Location.Y + (titleDescripLabel.Height - 18));
            }

            durationDescripLabel.Text = mediaInfo.Duration;
            if (durationDescripLabel.Height > genreDescripLabel.MaximumSize.Height)
            {
                genreLabel.Location = new Point(genreLabel.Location.X, genreLabel.Location.Y + (durationDescripLabel.Height - 18));
                genreDescripLabel.Location = new Point(genreDescripLabel.Location.X, genreDescripLabel.Location.Y + (durationDescripLabel.Height - 18));
                yearLabel.Location = new Point(yearLabel.Location.X, yearLabel.Location.Y + (durationDescripLabel.Height - 18));
                yearDescripLabel.Location = new Point(yearDescripLabel.Location.X, yearDescripLabel.Location.Y + (durationDescripLabel.Height - 18));
                ratingLabel.Location = new Point(ratingLabel.Location.X, ratingLabel.Location.Y + (durationDescripLabel.Height - 18));
                ratingDescripLabel.Location = new Point(ratingDescripLabel.Location.X, ratingDescripLabel.Location.Y + (durationDescripLabel.Height - 18));
                priceLabel.Location = new Point(priceLabel.Location.X, priceLabel.Location.Y + (durationDescripLabel.Height - 18));
                priceDescripLabel.Location = new Point(priceDescripLabel.Location.X, priceDescripLabel.Location.Y + (durationDescripLabel.Height - 18));
            }

            genreDescripLabel.Text = mediaInfo.Genre;
            if (genreDescripLabel.Height > genreDescripLabel.MaximumSize.Height)
            {
                yearLabel.Location = new Point(yearLabel.Location.X, yearLabel.Location.Y + (genreDescripLabel.Height - 18));
                yearDescripLabel.Location = new Point(yearDescripLabel.Location.X, yearDescripLabel.Location.Y + (genreDescripLabel.Height - 18));
                ratingLabel.Location = new Point(ratingLabel.Location.X, ratingLabel.Location.Y + (genreDescripLabel.Height - 18));
                ratingDescripLabel.Location = new Point(ratingDescripLabel.Location.X, ratingDescripLabel.Location.Y + (genreDescripLabel.Height - 18));
                priceLabel.Location = new Point(priceLabel.Location.X, priceLabel.Location.Y + (genreDescripLabel.Height - 18));
                priceDescripLabel.Location = new Point(priceDescripLabel.Location.X, priceDescripLabel.Location.Y + (genreDescripLabel.Height - 18));
            }

            yearDescripLabel.Text = (mediaInfo.Year != 0) ? mediaInfo.Year.ToString() : "";
            if (yearDescripLabel.Height > yearDescripLabel.MaximumSize.Height)
            {
                ratingLabel.Location = new Point(ratingLabel.Location.X, ratingLabel.Location.Y + (yearDescripLabel.Height - 18));
                ratingDescripLabel.Location = new Point(ratingDescripLabel.Location.X, ratingDescripLabel.Location.Y + (yearDescripLabel.Height - 18));
                priceLabel.Location = new Point(priceLabel.Location.X, priceLabel.Location.Y + (yearDescripLabel.Height - 18));
                priceDescripLabel.Location = new Point(priceDescripLabel.Location.X, priceDescripLabel.Location.Y + (yearDescripLabel.Height - 18));
            }

            ratingDescripLabel.Text = mediaInfo.Rating.ToString();
            if (ratingDescripLabel.Height > ratingDescripLabel.MaximumSize.Height)
            {
                priceLabel.Location = new Point(priceLabel.Location.X, priceLabel.Location.Y + (ratingDescripLabel.Height - 18));
                priceDescripLabel.Location = new Point(priceDescripLabel.Location.X, priceDescripLabel.Location.Y + (ratingDescripLabel.Height - 18));
            }

            priceDescripLabel.Text = mediaInfo.Price.ToString();

            if(mediaInfo.CoverArtDirectory.Length > 10) coverArtPictureBox.Image = Image.FromFile(mediaInfo.CoverArtDirectory);

        }

        private void EditInfo()
        {
            editTextBox.Visible = true;
            str = l.Text; 

            editTextBox.Text = l.Text;
            editTextBox.Location = l.Location;
            if (l.Width == 0)
                editTextBox.Size = new Size(50, l.Height + 5);
            else
                editTextBox.Size = new Size(l.Size.Width, l.Size.Height + 2);
         
            editTextBox.Font = l.Font;
            editTextBox.ForeColor = l.ForeColor;
        }

        private void editTextBox_TextChanged(object sender, EventArgs e)
        {
            if (str != editTextBox.Text) saveButton.Visible = true;
            else saveButton.Visible = false;
            
        }

        private void editTextBox_Leave(object sender, EventArgs e)
        {
            editTextBox.Visible = false;
            if (!saveButton.Focused) saveButton.Visible = false;
        }

        private void yearDescripLabel_Click(object sender, EventArgs e)
        {
            l = yearDescripLabel;
            EditInfo();
        }

        private void nameDescripLabel_Click(object sender, EventArgs e)
        {
            l = nameDescripLabel;
            EditInfo();
        }

        private void titleDescripLabel_Click(object sender, EventArgs e)
        {
            l = titleDescripLabel;
            EditInfo();
        }

        private void genreDescripLabel_Click(object sender, EventArgs e)
        {
            l = genreDescripLabel;
            EditInfo();
        }

        private void priceDescripLabel_Click(object sender, EventArgs e)
        {
            l = priceDescripLabel;
            EditInfo();
        }

        private void ratingDescripLabel_Click(object sender, EventArgs e)
        {
            l = ratingDescripLabel;
            EditInfo();
        }

        private void saveButton_Click(object sender, EventArgs e)
        {
            if (editTextBox.Location.Y == nameDescripLabel.Location.Y) 
            {
                try
                {
                    string newFileName = this.mediaInfo.OriginalDirectory.Substring(0, this.mediaInfo.OriginalDirectory.Length - GetFileName(this.mediaInfo.OriginalDirectory).Length);

                    AppendMediaInfo(this.mediaInfo.thisDirectory, editTextBox.Text, LibraryManager.MediaProperty.Name);
                    nameDescripLabel.Text = editTextBox.Text;
                    newFileName += (nameDescripLabel.Text + GetExtension(this.mediaInfo.OriginalDirectory));

                    File.Move(this.mediaInfo.OriginalDirectory, newFileName);
                    this.mediaInfo.Name = nameDescripLabel.Text;
                }
                catch(Exception ex)
                {
                    MessageBox.Show("Couldn't rename file: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            else if (editTextBox.Location.Y == titleDescripLabel.Location.Y) 
            { 
                AppendMediaInfo(this.mediaInfo.thisDirectory, editTextBox.Text, LibraryManager.MediaProperty.Title); 
                titleDescripLabel.Text = editTextBox.Text;
                
                this.mediaInfo.Title = titleDescripLabel.Text;
                reference.titleTextBox.Text = titleDescripLabel.Text;

                if (mediaInfo.Type == MediaType.Movie)
                    reference.movieList.FocusedItem.Text = titleDescripLabel.Text;
                else if (mediaInfo.Type == MediaType.Music)
                    reference.musicList.FocusedItem.Text = titleDescripLabel.Text;
                else if (mediaInfo.Type == MediaType.Series)
                    reference.seriesList.FocusedItem.Text = titleDescripLabel.Text;
            }
            else if (editTextBox.Location.Y == genreDescripLabel.Location.Y) 
            { 
                AppendMediaInfo(this.mediaInfo.thisDirectory, editTextBox.Text, LibraryManager.MediaProperty.Genre); 
                genreDescripLabel.Text = editTextBox.Text;
                this.mediaInfo.Genre = genreDescripLabel.Text;
                reference.genreTextBox.Text = genreDescripLabel.Text;
            }
            else if (editTextBox.Location.Y == yearDescripLabel.Location.Y) 
            {
                try
                {
                    int year = int.Parse(editTextBox.Text);
                    AppendMediaInfo(this.mediaInfo.thisDirectory, editTextBox.Text, LibraryManager.MediaProperty.Year);
                    yearDescripLabel.Text = editTextBox.Text;
                    this.mediaInfo.Year = year;
                    reference.yearTextBox.Text = yearDescripLabel.Text;
                }
                catch(Exception ex)
                {
                    MessageBox.Show("Couldn't save info: " + ex.Message);
                }
                
            }
            else if (editTextBox.Location.Y == ratingDescripLabel.Location.Y) 
            {
                try
                {
                    float rating = float.Parse(editTextBox.Text);
                    AppendMediaInfo(this.mediaInfo.thisDirectory, editTextBox.Text, LibraryManager.MediaProperty.Rating);
                    ratingDescripLabel.Text = editTextBox.Text;
                    this.mediaInfo.Rating = rating;
                    this.mediaInfo.PRS = this.mediaInfo.Rating;
                    reference.ratingTextBox.Text = ratingDescripLabel.Text;
                }
                catch(Exception ex)
                {
                    MessageBox.Show("Couldn't save info: " + ex.Message);
                }
                
            }
            
            saveButton.Visible = false;
        }

        private void EditBoxLoseFocus_MouseClick(object sender, MouseEventArgs e)
        {
            if (editTextBox.Visible) editTextBox.Visible = false;
            else
            {
                if ((e.Y <= yearDescripLabel.Location.Y + 15 || e.Y >= yearDescripLabel.Location.Y) && !(e.Y > yearDescripLabel.Location.Y + 15) && !(e.Y < yearDescripLabel.Location.Y))
                {
                    l = yearDescripLabel;
                    EditInfo();
                } 
                else if ((e.Y <= genreDescripLabel.Location.Y + 15 || e.Y >= genreDescripLabel.Location.Y) && !(e.Y > genreDescripLabel.Location.Y + 15) && !(e.Y < genreDescripLabel.Location.Y))
                {
                    l = genreDescripLabel;
                    EditInfo();
                }
                else if ((e.Y <= ratingDescripLabel.Location.Y + 15 || e.Y >= ratingDescripLabel.Location.Y) && !(e.Y > ratingDescripLabel.Location.Y + 15) && !(e.Y < ratingDescripLabel.Location.Y))
                {
                    l = ratingDescripLabel;
                    EditInfo();
                }
            }
        }

        private void editTextBox_KeyDown(object sender, KeyEventArgs e)
        {
            if(e.KeyCode == Keys.Enter)
            {
                editTextBox.Multiline = false;
                saveButton.Focus();
                saveButton.PerformClick();
            }
        }
    }
}
