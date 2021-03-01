using System;
using System.IO;
using static System.IO.Path;
using static System.IO.Directory;
using static System.Environment;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WMPLib;


namespace Mobile_Service_Distribution
{
    public class LibraryManager
    {
        private static readonly string movieFolder = Combine(GetFolderPath(SpecialFolder.UserProfile), "Media Distro", "Movies");
        private static readonly string musicFolder = Combine(GetFolderPath(SpecialFolder.UserProfile), "Media Distro", "Music");
        private static readonly string seriesFolder = Combine(GetFolderPath(SpecialFolder.UserProfile), "Media Distro", "Series");
        public static ArrayList movieCatalogue = new ArrayList();
        public static ArrayList musicCatalogue = new ArrayList();
        public static ArrayList seriesCatalogue = new ArrayList();
        public static ArrayList seasonFiles;
        public static List<string> movieGenreCatalogue = new List<string>();
        public static List<string> musicGenreCatalogue = new List<string>();
        public static List<string> seriesGenreCatalogue = new List<string>();

        private static WindowsMediaPlayer mediaFile = new WindowsMediaPlayer(); 
        public string Title { get; set; }
        public string Name { get; set; }
        public string Genre { get; set; }
        public int Year { get; set; }
        public decimal Price { get; set; }
        public string OriginalDirectory { get; set; }
        public string thisDirectory { get; set; }
        public string CoverArtDirectory { get; set; }
        public string Duration { get; set; }
        public float Rating { get; set; }
        public float PRS { get; set; }
        public MediaType Type { get; }
        public ArrayList SeriesList { get; set; }
        public ArrayList AlbumList { get; set; }

        public enum MediaType
        {
            Movie = 1,
            Music = 2,
            Series = 3
        }

        public enum MediaProperty
        {
            Name,
            Title,
            Duration,
            Genre,
            Year,
            Rating,
            OriginalDirectory,
            Cover_Art_Dir,
            Price
        }

        public enum SortType
        {
            Name,
            Duration,
            Year,
            Rating,
            PRS
        }

        public enum Order
        {
            Ascending,
            Descending
        }

        public LibraryManager(string dir, MediaType media, bool onTop = false, bool temp = false)
        { 
            if(RetrieveMediaInfo(dir, media, onTop) == 1)
            {
                this.Type = media;
                if (media == MediaType.Movie)
                {
                    movieCatalogue.Add(this);
                    if (this.Genre != null && !movieGenreCatalogue.Contains(this.Genre)) movieGenreCatalogue.Add(this.Genre);
                }

                if (media == MediaType.Music)
                {
                    if (!temp)
                    {
                        musicCatalogue.Add(this);
                        if (this.Genre != null && !musicGenreCatalogue.Contains(this.Genre)) musicGenreCatalogue.Add(this.Genre);
                    }
                }

                if (media == MediaType.Series)
                {
                    if (onTop && !temp)
                        seriesCatalogue.Add(this);

                    if (this.Genre != null && !seriesGenreCatalogue.Contains(this.Genre)) seriesGenreCatalogue.Add(this.Genre);
                }
            }
        }

        private static void ShellSort(ArrayList list, SortType sort, Order o)
        {
            LibraryManager[] A = new LibraryManager[list.Count];
            int num = 0;
            foreach (LibraryManager media in list) { A[num] = media; num++; }

            int inner, numElements = A.Length;
            LibraryManager temp;
            
            int h = 1;
            while (h <= numElements / 3)
                h = h * 3 + 1;
            while (h > 0)
            {
                for (int outer = h; outer <= numElements - 1; outer++)
                {
                    temp = A[outer];
                    inner = outer;
                    if(sort == SortType.Name)
                    {
                        if (o == Order.Ascending)
                        {
                            while ((inner > h - 1) && String.Compare(A[inner - h].Title, temp.Title) == 1)
                            {
                                A[inner] = A[inner - h];
                                inner -= h;
                            }
                        }
                        else
                        {
                            while ((inner > h - 1) && String.Compare(A[inner - h].Title, temp.Title) == -1)
                            {
                                A[inner] = A[inner - h];
                                inner -= h;
                            }
                        }
                    }

                    else if(sort == SortType.Duration)
                    {
                        if (o == Order.Ascending)
                        {
                            while ((inner > h - 1) && 
                                TimeSpan.Compare(TimeSpan.Parse((A[inner - h].Duration.Length < 6) ? "00:" + A[inner - h].Duration : A[inner-h].Duration), 
                                                TimeSpan.Parse((temp.Duration.Length < 6) ? "00:" + temp.Duration : temp.Duration)) == 1)
                            {
                                A[inner] = A[inner - h];
                                inner -= h;
                            }
                        }
                        else
                        {
                            while ((inner > h - 1) && TimeSpan.Compare(TimeSpan.Parse((A[inner - h].Duration.Length < 6) ? "00:" + A[inner - h].Duration : A[inner - h].Duration),
                                                    TimeSpan.Parse((temp.Duration.Length < 6) ? "00:" + temp.Duration : temp.Duration)) == -1)
                            {
                                A[inner] = A[inner - h];
                                inner -= h;
                            }
                        }
                    }
                    else if (sort == SortType.Year)
                    {
                        if (o == Order.Ascending)
                        {
                            while ((inner > h - 1) && A[inner - h].Year > temp.Year)
                            {
                                A[inner] = A[inner - h];
                                inner -= h;
                            }
                        }
                        else
                        {
                            while ((inner > h - 1) && A[inner - h].Year < temp.Year)
                            {
                                A[inner] = A[inner - h];
                                inner -= h;
                            }
                        }
                    }
                    else if (sort == SortType.Rating)
                    {
                        if (o == Order.Ascending)
                        {
                            while ((inner > h - 1) && A[inner - h].Rating > temp.Rating)
                            {
                                A[inner] = A[inner - h];
                                inner -= h;
                            }
                        }
                        else
                        {
                            while ((inner > h - 1) && A[inner - h].Rating < temp.Rating)
                            {
                                A[inner] = A[inner - h];
                                inner -= h;
                            }
                        }
                    }
                    if (sort == SortType.PRS)
                    {
                        if (o == Order.Ascending)
                        {
                            while ((inner > h - 1) && A[inner - h].PRS > temp.PRS)
                            {
                                A[inner] = A[inner - h];
                                inner -= h;
                            }
                        }
                        else
                        {
                            while ((inner > h - 1) && A[inner - h].PRS < temp.PRS)
                            {
                                A[inner] = A[inner - h];
                                inner -= h;
                            }
                        }
                    }


                    A[inner] = temp;
                }
                h = (h - 1) / 3;
            }

            list.Clear();
            foreach (LibraryManager media in A) list.Add(media);
        }

        public static List<LibraryManager> SortPRS()
        {
            ArrayList[] lists = { movieCatalogue, musicCatalogue, seriesCatalogue };
            ArrayList catalogue = new ArrayList();
            List<LibraryManager> prsList = new List<LibraryManager>(10);

            for(int i = 0; i < lists.Length - 1; i++)
                foreach(LibraryManager media in lists[i])
                    catalogue.Add(media);

            ShellSort(catalogue, SortType.PRS, Order.Descending);

            for(int i = 0; i < 11; i++)
                prsList.Add((LibraryManager)catalogue[i]);

            return prsList;
        }
        
        public static void SortMedia(ArrayList List, SortType sort, Order order)
        {
            ArrayList[] lists = { movieCatalogue, musicCatalogue, seriesCatalogue };

            if (List == null)
                foreach (ArrayList list in lists) ShellSort(list, sort, order);
            else
            {
                ArrayList list = List;
                ShellSort(list, sort, order);
            }
        }

        private int RetrieveMediaInfo(string dir, MediaType type, bool onTop)
        {
            if(type == MediaType.Movie)
            {
                string[] info = File.ReadAllLines(dir);
                this.OriginalDirectory = info[6].Substring(11);

                if (File.Exists(this.OriginalDirectory))
                {
                    this.Name = info[0].Substring(6);
                    this.Title = info[1].Substring(7);
                    this.Duration = new DateTime(TimeSpan.Parse(info[2].Substring(10)).Ticks).ToString("HH:mm:ss");
                    this.Genre = (info[3].Substring(7) != "") ? info[3].Substring(7) : "Unknown";
                    this.Year = (info[4].Substring(6) != "") ? int.Parse(info[4].Substring(6)) : 0;
                    this.Rating = (info[5].Substring(8) != "") ? float.Parse(info[5].Substring(8)) : 0;
                    this.PRS = this.Rating;
                    this.CoverArtDirectory = (info[7].Substring(21) != "") ? info[7].Substring(21) : null;
                    this.thisDirectory = dir;
                    this.Price = Media_Distro.Properties.Settings.Default.moviePrice;

                    return 1;
                }
                else
                {
                    File.Delete(dir);
                    return 0;
                }
            }
            else if(type == MediaType.Music)
            {
                ArrayList music = new ArrayList();

                if (onTop)
                {
                    string[] info = File.ReadAllLines(GetFiles(dir)[0]);
                    this.OriginalDirectory = info[6].Substring(11);

                    if (Exists(this.OriginalDirectory))
                    {
                        string[] tracks = GetFiles(dir);

                        this.Name = info[0].Substring(6);
                        this.Title = info[1].Substring(7);
                        this.Duration = (info[2].Substring(10).ElementAt(1) == '0') ? new DateTime(TimeSpan.Parse(info[2].Substring(10)).Ticks).ToString("mm:ss") : new DateTime(TimeSpan.Parse(info[2].Substring(10)).Ticks).ToString("HH:mm:ss"); ; new DateTime(TimeSpan.Parse(info[2].Substring(10)).Ticks).ToString("mm:ss");
                        this.Genre = (info[3].Substring(7) != "") ? info[3].Substring(7) : "Unknown";
                        this.Year = (info[4].Substring(6) != "") ? int.Parse(info[4].Substring(6)) : 0;
                        this.Rating = (info[5].Substring(8) != "") ? float.Parse(info[5].Substring(8)) : 0;
                        this.PRS = this.Rating;
                        this.CoverArtDirectory = (info[7].Substring(21) != "") ? info[7].Substring(21) : null;
                        this.thisDirectory = dir;

                        for(int i = 1; i < tracks.Length; i++)
                        {
                            music.Add(tracks[i]);
                            this.Price += Media_Distro.Properties.Settings.Default.musicPrice;
                        }
                            
                        this.AlbumList = music;

                        return 1;
                    }
                    else
                    {
                        Delete(dir, true);
                        return 0;
                    }
                }
                else
                {
                    string[] info = File.ReadAllLines(dir);
                    this.OriginalDirectory = info[6].Substring(11);

                    if (File.Exists(this.OriginalDirectory))
                    {
                        this.Name = info[0].Substring(6);
                        this.Title = info[1].Substring(7);
                        this.Duration = (info[2].Substring(10).ElementAt(1) == '0') ? new DateTime(TimeSpan.Parse(info[2].Substring(10)).Ticks).ToString("mm:ss") : new DateTime(TimeSpan.Parse(info[2].Substring(10)).Ticks).ToString("HH:mm:ss");;
                        this.Genre = (info[3].Substring(7) != "") ? info[3].Substring(7) : "Unknown";
                        this.Year = (info[4].Substring(6) != "") ? int.Parse(info[4].Substring(6)) : 0;
                        this.Rating = (info[5].Substring(8) != "") ? float.Parse(info[5].Substring(8)) : 0;
                        this.PRS = this.Rating;
                        this.CoverArtDirectory = (info[7].Substring(21) != "") ? info[7].Substring(21) : null;
                        this.thisDirectory = dir;
                        this.Price = Media_Distro.Properties.Settings.Default.musicPrice;

                        return 1;
                    }
                    else
                    {
                        File.Delete(dir);
                        return 0;
                    }
                }                
            }
            else
            {
                if (onTop)
                {
                    string[] info;
                    string[] seasonFolders;

                    if (File.Exists(dir))
                    {
                        info = File.ReadAllLines(dir);

                        this.Price = (GetFiles(GetDirectoryName(dir)).Length - 1) * Media_Distro.Properties.Settings.Default.seriesPrice;
                    }
                        
                    else if (GetDirectories(dir) != null)
                    {
                        decimal price = 0;
                        seasonFolders = GetDirectories(dir);
                        info = File.ReadAllLines(GetFiles(dir)[0]);

                        ArrayList season = new ArrayList();
                        ArrayList seasons = new ArrayList();

                        foreach (string sea in seasonFolders)
                        {
                            season = new ArrayList();
                            string[] episodeFiles = GetFiles(sea);
                            season.Add(episodeFiles[0]);

                            if (episodeFiles.Length < 2 || !Exists(File.ReadAllLines(episodeFiles[0])[6].Substring(11)))
                            {
                                Delete(episodeFiles[0].Remove(episodeFiles[0].LastIndexOf('\\')), true);
                                continue;
                            }
                                
                            for (int i = 1; i < episodeFiles.Length; i++)
                            {
                                season.Add(episodeFiles[i]);
                                price += Media_Distro.Properties.Settings.Default.seriesPrice;
                            }

                            seasons.Add(season);
                        }

                        this.SeriesList = seasons;
                        this.Price = price;
                    }
                        
                    else 
                        info = null;

                    this.OriginalDirectory = info[6].Substring(11);

                    if (Exists(this.OriginalDirectory))
                    {
                        this.Name = info[0].Substring(13);
                        this.Title = info[1].Substring(7).Replace(" -", ":");
                        this.Duration = info[2].Substring(10);
                        this.Genre = (info[4].Substring(7) != "") ? info[3].Substring(7) : "Unknown";
                        this.Year = (info[3].Substring(6) != "") ? int.Parse(info[4].Substring(6)) : 0;
                        this.Rating = (info[5].Substring(8) != "") ? float.Parse(info[5].Substring(8)) : 0;
                        this.PRS = this.Rating;
                        this.CoverArtDirectory = (info[7].Substring(21) != "") ? info[7].Substring(21) : null;
                        this.thisDirectory = dir;

                        return 1;
                    }
                    else
                    {
                        Delete(dir, true);
                        return 0;
                    }
                }
                else
                {
                    string[] info = File.ReadAllLines(dir);
                    this.OriginalDirectory = info[6].Substring(11);

                    if (File.Exists(this.OriginalDirectory))
                    {
                        this.Name = info[0].Substring(6);
                        this.Title = info[1].Substring(7);
                        this.Duration = info[2].Substring(10);
                        this.Genre = (info[4].Substring(7) != "") ? info[3].Substring(7) : "Unknown";
                        this.Year = (info[3].Substring(6) != "") ? int.Parse(info[4].Substring(6)) : 0;
                        this.Rating = (info[5].Substring(8) != "") ? float.Parse(info[5].Substring(8)) : 0;
                        this.PRS = this.Rating;
                        this.thisDirectory = dir;
                        this.Price = Media_Distro.Properties.Settings.Default.seriesPrice;

                        return 1;
                    }
                    else
                    {
                        File.Delete(dir);
                        return 0;
                    }
                }
            }
        }

        public static string RetrieveMediaInfo(string dir, MediaProperty property)
        {
            string[] info = File.ReadAllLines(dir); 
           
            int titleSize = info[1].Length;
           
            if (property == MediaProperty.Title)
            {
                if (titleSize <= 7) return info[0].Substring(6);
                else return info[1].Substring(7);
            }
            else if (property == MediaProperty.Name) return info[0].Substring(6);
            else if (property == MediaProperty.Duration) return info[2].Substring(10);
            else if (property == MediaProperty.Genre) 
            {
                if (info[3].Substring(6) == " ") return "";
                else return info[3].Substring(6);
            } 
            else if (property == MediaProperty.Year) return info[4].Substring(6);
            else if (property == MediaProperty.Rating) return info[5].Substring(8);
            else if (property == MediaProperty.OriginalDirectory) return info[6].Substring(11);
            else if (property == MediaProperty.Cover_Art_Dir)
            {
                if (info[7].Substring(20).Length < 10) return null;
                else return info[7].Substring(20);
            }
                
            else return null;

            //1580
        }

        public static void AppendMediaInfo(string dir, string newInfo, MediaProperty property)
        {
            StringBuilder[] appendLines = new StringBuilder[File.ReadAllLines(dir).Length];
            byte count = 0;

            foreach (String file in File.ReadAllLines(dir))
            {
                appendLines[count] = new StringBuilder(file);
                count++;
            }

            StreamWriter writer = File.CreateText(dir);

            if (property == MediaProperty.Name) appendLines[(int)MediaProperty.Name].Replace(appendLines[(int)MediaProperty.Name].ToString(), "Name: " + newInfo);
            else if (property == MediaProperty.Title) appendLines[(int)MediaProperty.Title].Replace(appendLines[(int)MediaProperty.Title].ToString(), "Title: " + newInfo);
            else if (property == MediaProperty.Duration) appendLines[(int)MediaProperty.Duration].Replace(appendLines[(int)MediaProperty.Duration].ToString(), "Duration: " + newInfo);
            else if (property == MediaProperty.Genre) appendLines[(int)MediaProperty.Genre].Replace(appendLines[(int)MediaProperty.Genre].ToString(), "Genre: " + newInfo);
            else if (property == MediaProperty.Year) appendLines[(int)MediaProperty.Year].Replace(appendLines[(int)MediaProperty.Year].ToString(), "Year: " + newInfo);
            else if (property == MediaProperty.Rating) appendLines[(int)MediaProperty.Rating].Replace(appendLines[(int)MediaProperty.Rating].ToString(), "Rating: " + newInfo);
            else if (property == MediaProperty.Cover_Art_Dir) appendLines[(int)MediaProperty.Cover_Art_Dir].Replace(appendLines[(int)MediaProperty.Cover_Art_Dir].ToString(), "Cover Art Directory: " + newInfo);

            
            foreach (StringBuilder line in appendLines) writer.WriteLine(line.ToString());
            writer.Close();
            writer.Dispose();
        }

        public static void RetrieveMediaDirectories(string dir, ArrayList list, mediaDistroFrame form = null)
        {
            if (GetDirectories(dir) != null)
            {
                if (form == null && list == seasonFiles)
                {
                    ArrayList episodes = new ArrayList();

                    episodes.Add(dir);
                    foreach (string file in GetFiles(dir))
                        if (GetExtension(file) == ".mp4" || GetExtension(file) == ".mkv" || GetExtension(file) == ".avi" ||
                            GetExtension(file) == ".flv" || GetExtension(file) == ".wmv" || GetExtension(file) == ".f4v" ||
                            GetExtension(file) == ".f4p" || GetExtension(file) == ".f4a" || GetExtension(file) == ".f4b" ||
                            GetExtension(file) == ".3gp" || GetExtension(file) == ".m4v" || GetExtension(file) == ".mpeg" ||
                            GetExtension(file) == ".mpg" || GetExtension(file) == ".mov" || GetExtension(file) == ".qt")
                                episodes.Add(file);
                    list.Add(episodes);

                    foreach (string subDir in GetDirectories(dir)) RetrieveMediaDirectories(subDir, list, form);
                }

                else if (form != null && list == form.musicDir)
                {
                    string[] albums = GetFiles(dir);
                    ArrayList album;

                    if (albums.Length > 0)
                    {
                        album = new ArrayList();
                        album.Add(dir);

                        foreach (string file in albums)
                            if (GetExtension(file) == ".mp3" || GetExtension(file) == ".m4a" || GetExtension(file) == ".webm" ||
                             GetExtension(file) == ".wv" || GetExtension(file) == ".wma" || GetExtension(file) == ".wav" ||
                             GetExtension(file) == ".m4b" || GetExtension(file) == ".m4p" || GetExtension(file) == ".aac")
                                album.Add(file);
                        list.Add(album);

                        if (album.Count < 2)
                            list.Remove(album);
                    }
                   
                    foreach (string subDir in GetDirectories(dir)) RetrieveMediaDirectories(subDir, list, form);
                }
                
                else
                {
                    foreach (string file in GetFiles(dir))
                        if (GetExtension(file) == ".mp4" || GetExtension(file) == ".mkv" || GetExtension(file) == ".avi" ||
                            GetExtension(file) == ".flv" || GetExtension(file) == ".wmv" || GetExtension(file) == ".f4v" ||
                            GetExtension(file) == ".f4p" || GetExtension(file) == ".f4a" || GetExtension(file) == ".f4b" ||
                            GetExtension(file) == ".3gp" || GetExtension(file) == ".m4v" || GetExtension(file) == ".mpeg" ||
                            GetExtension(file) == ".mpg" || GetExtension(file) == ".mov" || GetExtension(file) == ".qt")
                                list.Add(file);
                    foreach (string subDir in GetDirectories(dir)) RetrieveMediaDirectories(subDir, list, form);
                }
            }
        }

        public static void ManageMediaReference(ArrayList dir)
        {
            string directory = Combine(musicFolder, GetFileName((string)dir[0]));
            FileInfo file;
            StreamWriter writer;
            TimeSpan albumDuration = new TimeSpan(), videoInfo = new TimeSpan();
           
            CreateDirectory(directory);
            
            for (int i = 1; i < dir.Count; i++)
            {
                string fileName = GetFileName((string)dir[i]);
                string path = Combine(directory, fileName + ".txt");
                file = new FileInfo(path);
                
                if (!file.Exists)
                {
                    videoInfo = TimeSpan.FromSeconds(mediaFile.newMedia((string)dir[i]).duration);

                    writer = File.CreateText(path);
                    writer.WriteLine("Name: " + fileName);
                    writer.WriteLine("Title: " + fileName);
                    writer.WriteLine("Duration: " + videoInfo);
                    writer.WriteLine("Genre: ");
                    writer.WriteLine("Year: ");
                    writer.WriteLine("Rating: ");
                    writer.WriteLine("Directory: " + (string)dir[i]);
                    writer.WriteLine("Cover Art Directory: ");
                    writer.Close();
                    writer.Dispose();
                }

                albumDuration += videoInfo;
            }

            file = new FileInfo(Combine(directory, "(.00)" + GetFileName((string)dir[0])) + ".txt");

            if (!file.Exists)
            {
                writer = File.CreateText(file.FullName);
                writer.WriteLine("Name: " + GetFileName((string)dir[0]));
                writer.WriteLine("Title: " + GetFileName((string)dir[0]));
                writer.WriteLine("Duration: " + albumDuration);
                writer.WriteLine("Genre: ");
                writer.WriteLine("Year: ");
                writer.WriteLine("Rating: ");
                writer.WriteLine("Directory: " + (string)dir[0]);
                writer.WriteLine("Cover Art Directory: ");
                writer.Close();
                writer.Dispose();
            }
        }

        public static void ManageMediaReference(string dir, MediaType type, string fileName)
        {
            string directory;
            FileInfo file, seasonFile, episodeFile;
            StreamWriter writer;
            
            if (type == MediaType.Movie)
            {
                directory = Combine(movieFolder, fileName + ".txt");
                file = new FileInfo(directory);

                if (!file.Exists)
                {
                    TimeSpan videoInfo = TimeSpan.FromSeconds(mediaFile.newMedia(dir).duration);

                    writer = File.CreateText(directory);
                    writer.WriteLine("Name: " + fileName);
                    writer.WriteLine("Title: " + fileName);
                    writer.WriteLine("Duration: " + videoInfo);
                    writer.WriteLine("Genre: ");
                    writer.WriteLine("Year: ");
                    writer.WriteLine("Rating: ");
                    writer.WriteLine("Directory: " + dir);
                    writer.WriteLine("Cover Art Directory: ");
                    writer.Close();
                    writer.Dispose();
                }
            }
            else if (type == MediaType.Series)
            {
                TimeSpan seriesDuration = new TimeSpan();
                seasonFiles = new ArrayList();
                directory = Combine(seriesFolder, fileName);
                CreateDirectory(directory);
                
                RetrieveMediaDirectories(dir, seasonFiles);

                foreach(ArrayList seasons in seasonFiles)
                {
                    if(seasons.Count > 1)
                    {
                        string fileString = GetFileName((string)seasons[0]);
                        TimeSpan seasonDuration = new TimeSpan();
                        CreateDirectory(Combine(directory, fileString));

                        for (int i = 1; i < seasons.Count; i++)
                        {
                            string episodeName = GetFileNameWithoutExtension((string)seasons[i]);
                            episodeFile = new FileInfo(Combine(directory, GetFileName((string)seasons[0]), episodeName + ".txt"));

                            if (!episodeFile.Exists)
                            {
                                TimeSpan videoInfo = TimeSpan.FromSeconds(mediaFile.newMedia((string)seasons[i]).duration);

                                writer = File.CreateText(episodeFile.FullName);
                                writer.WriteLine("Name: " + episodeName);
                                writer.WriteLine("Title: " + episodeName);
                                writer.WriteLine("Duration: " + videoInfo);
                                writer.WriteLine("Year: ");
                                writer.WriteLine("Genre: ");
                                writer.WriteLine("Rating: ");
                                writer.WriteLine("Directory: " + seasons[i]);
                                writer.Close();
                                writer.Dispose();

                                seasonDuration += videoInfo;
                            }
                        }

                        seasonFile = new FileInfo(Combine(directory, fileString, "(.00)" + fileString + ".txt"));

                        if (!seasonFile.Exists)
                        {
                            writer = File.CreateText(seasonFile.FullName);
                            writer.WriteLine("Folder Name: " + fileString);
                            writer.WriteLine("Title: " + fileString);
                            writer.WriteLine("Duration: " + seasonDuration);
                            writer.WriteLine("Year: ");
                            writer.WriteLine("Genre: ");
                            writer.WriteLine("Rating: ");
                            writer.WriteLine("Directory: " + seasons[0]);
                            writer.WriteLine("Cover Art Directory: ");
                            writer.WriteLine(GetFileName(fileName));
                            writer.Close();
                            writer.Dispose();
                        }

                        seriesDuration += seasonDuration;
                    }    
                }

                seasonFile = new FileInfo(Combine(directory, fileName + ".txt"));

                if (!seasonFile.Exists)
                {
                    writer = File.CreateText(seasonFile.FullName);
                    writer.WriteLine("Folder Name: " + fileName);
                    writer.WriteLine("Title: " + fileName);
                    writer.WriteLine("Duration: " + seriesDuration);
                    writer.WriteLine("Year: ");
                    writer.WriteLine("Genre: ");
                    writer.WriteLine("Rating: ");
                    writer.WriteLine("Directory: " + dir);
                    writer.WriteLine("Cover Art Directory: ");
                    writer.Close();
                    writer.Dispose();
                }
            }
            else if (type == MediaType.Music)
            {
                directory = Combine(musicFolder, fileName + ".txt");
                file = new FileInfo(directory);

                if (!file.Exists)
                {
                    TimeSpan videoInfo = TimeSpan.FromSeconds(mediaFile.newMedia(dir).duration);

                    writer = File.CreateText(directory);
                    writer.WriteLine("Name: " + fileName);
                    writer.WriteLine("Title: " + fileName);
                    writer.WriteLine("Duration: " + videoInfo);
                    writer.WriteLine("Genre: ");
                    writer.WriteLine("Year: ");
                    writer.WriteLine("Rating: ");
                    writer.WriteLine("Directory: " + dir);
                    writer.WriteLine("Cover Art Directory: ");
                    writer.Close();
                    writer.Dispose();
                }
            }
        }

        public static List<LibraryManager> Search(string value, ArrayList list)
        {
            List<LibraryManager> searchResults = new List<LibraryManager>();

            if (list.Count == 0) list = new ArrayList() { movieCatalogue, musicCatalogue, seriesCatalogue };

            foreach (ArrayList l in list)
            {
                int left = 0, right = l.Count - 1;

                while (right > left)
                {
                    LibraryManager searchLeft = (LibraryManager)l[left];
                    LibraryManager searchRight = (LibraryManager)l[right];

                    if(searchLeft.Name == searchLeft.Title && searchRight.Name == searchRight.Title)
                    {
                        if (searchLeft.Name.ToLower().Contains(value.ToLower()))
                            searchResults.Add(searchLeft);
                        if (searchRight.Name.ToLower().Contains(value.ToLower()))
                            searchResults.Add(searchRight);

                        left += 1;
                        right -= 1;
                    }
                    else
                    {
                        if (searchLeft.Title.ToLower().Contains(value.ToLower()))
                            searchResults.Add(searchLeft);
                        if (searchRight.Title.ToLower().Contains(value.ToLower()))
                            searchResults.Add(searchRight);

                        left += 1;
                        right -= 1;
                    }
                }
            }

            return searchResults;
        }
    }
}
