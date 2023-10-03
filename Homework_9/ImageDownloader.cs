using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;

namespace Homework_9
{
    public class ImageDownloader
    {
        public event EventHandler ImageStarted;
        public event EventHandler ImageCompleted;
       public async Task DownloadAsync(string url, string fileName)
        {

            //Откуда будем качать
           // string remoteUri = "https://bipbap.ru/wp-content/uploads/2017/04/000f_7290754.jpg";
           // Как назовем файл на диске
           //  string fileName = "bigimage.jpg";
            // Качаем картинку в текущую директорию
            var myWebClient = new HttpClient();
            ImageStarted(this, null);
            //Console.WriteLine("Качаю \"{0}\" из \"{1}\" .......\n\n", fileName, url);
            // myWebClient.DownloadFile(url, fileName);
            //await Task.Delay(10000);
            byte[] responce = await myWebClient.GetByteArrayAsync(url);
            File.WriteAllBytes(fileName, responce);                    
            ImageCompleted(this, null);           
           // Console.WriteLine("Успешно скачал \"{0}\" из \"{1}\"", fileName, url);            
        }
    }
}
