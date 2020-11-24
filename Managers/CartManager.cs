using static System.IO.Directory;
using System.Collections;
using System.IO;


namespace Mobile_Service_Distribution.Managers
{
    public class CartManager
    {
        public ArrayList cartList;
        public int customerID;
        public static ArrayList carts = new ArrayList();
        public float cartSize;
        public int movieNum = 0, musicNum = 0, seriesNum = 0;
        public decimal cartPrice = 0;

        public CartManager(int customerID)
        {
            cartList = new ArrayList();
            this.customerID = customerID;
            carts.Add(this);
            cartSize = 0;
        }

        public LibraryManager[] ShowList()
        {
            LibraryManager[] list = new LibraryManager[cartList.Count];
            for(int i = 0; i < cartList.Count; i++)
                list[i] = (LibraryManager)this.cartList[i];

            return list;
        }

        public void AddMedia(LibraryManager fileName)
        {
            FileInfo fileSize;

            this.cartList.Add(fileName);
            
            if (fileName.Type == LibraryManager.MediaType.Movie)
            {
                movieNum++;

                fileSize = new FileInfo(fileName.OriginalDirectory);
                cartSize += fileSize.Length;
            }
            else if (fileName.Type == LibraryManager.MediaType.Music)
            {
                musicNum++;

                if (fileName.AlbumList != null)
                    foreach (string track in fileName.AlbumList)
                    {
                        fileSize = new FileInfo(File.ReadAllLines(track)[6].Substring(11));
                        cartSize += fileSize.Length;
                    }
                else
                {
                    fileSize = new FileInfo(fileName.OriginalDirectory);
                    cartSize += fileSize.Length;
                }
                    
            }   
            else if (fileName.Type == LibraryManager.MediaType.Series)
            {
                seriesNum++;

                if (fileName.SeriesList != null)
                    foreach(ArrayList file in fileName.SeriesList)
                    {
                        for(int i = 1; i < file.Count; i++)
                        {
                            fileSize = new FileInfo(File.ReadAllLines((string)file[i])[6].Substring(11));
                            cartSize += fileSize.Length;
                        }
                    }
                else
                {
                    if(Exists(fileName.OriginalDirectory))
                    {
                        foreach(string episode in GetFiles(fileName.OriginalDirectory))
                        {
                            fileSize = new FileInfo(episode);
                            cartSize += fileSize.Length;
                        }
                    }
                    else
                    {
                        fileSize = new FileInfo(fileName.OriginalDirectory);
                        cartSize += fileSize.Length;
                    }
                }
            }
                
            cartPrice += fileName.Price;
        }

        public bool ContainsMedia(LibraryManager fileName = null)
        {
            return cartList.Contains(fileName);
        }

        public bool IsEmpty()
        {
            if (this.cartList.Count == 0) return true;
            else return false;
        }

        public void Clear()
        {
            this.cartList.Clear();
        }

        public void Remove(LibraryManager media)
        {
            FileInfo fileSize;
            this.cartList.Remove(media);

            if(media.Type == LibraryManager.MediaType.Movie)
            {
                fileSize = new FileInfo(media.OriginalDirectory);
                cartSize -= fileSize.Length;
            }
            else if(media.Type == LibraryManager.MediaType.Music)
            {
                if(media.AlbumList != null)
                {
                    foreach (string file in media.AlbumList)
                    {
                        fileSize = new FileInfo(File.ReadAllLines(file)[6].Substring(11));
                        cartSize -= fileSize.Length;
                    }
                }
                else
                {
                    fileSize = new FileInfo(media.OriginalDirectory);
                    cartSize -= fileSize.Length;
                }
            }
            else
            {
                if(media.SeriesList != null)
                {
                    foreach(ArrayList seasons in media.SeriesList)
                    {
                        for (int i = 1; i < seasons.Count; i++)
                        {
                            fileSize = new FileInfo(File.ReadAllLines((string)seasons[i])[6].Substring(11));
                            cartSize -= fileSize.Length;
                        }
                    }
                }
                else
                {
                    if (Exists(media.OriginalDirectory))
                    {
                        foreach (string episode in GetFiles(media.OriginalDirectory))
                        {
                            fileSize = new FileInfo(episode);
                            cartSize -= fileSize.Length;
                        }
                    }
                    else
                    {
                        fileSize = new FileInfo(media.OriginalDirectory);
                        cartSize -= fileSize.Length;
                    }
                }

            }
            
        }
    }
}
