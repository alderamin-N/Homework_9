using System;

namespace Homework_9
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Dictionary<string, Task> tasks = new Dictionary<string, Task>();
            ImageDownloader imageDownloader = new ImageDownloader();
            imageDownloader.ImageStarted += ImageDownloader_ImageStarted;
            imageDownloader.ImageCompleted += ImageDownloader_ImageCompleted;

            for (int i=0; i<10;i++)
            {
                string fileName2 = $"number  {i}.jpg";
                //Task task = imageDownloader.DownloadAsync("https://bipbap.ru/wp-content/uploads/2017/04/000f_7290754.jpg", fileName2);
                Task task = imageDownloader.DownloadAsync("https://effigis.com/wp-content/uploads/2015/02/Iunctus_SPOT5_5m_8bit_RGB_DRA_torngat_mountains_national_park_8bits_1.jpg", fileName2);
                tasks.Add (fileName2,task);
            }                      
            while (true) 
            {
                Console.WriteLine("Нажмите клавишу A для выхода или любую другую клавишу для проверки статуса скачивания");
                ConsoleKeyInfo result = Console.ReadKey();
                Console.WriteLine();
                if (result.Key == ConsoleKey.A)
                {
                    return;
                }
                else
                {
                    foreach( var element in tasks)
                    {
                        if (element.Value.IsCompleted)
                        {
                            
                            Console.WriteLine($"Загружено {element.Key}");                            
                        }
                        else
                        {
                            Console.WriteLine($"Нет {element.Key}");
                        }
                    }
                }
            }           
        }
        private static void  ImageDownloader_ImageCompleted(object? sender, EventArgs e)
        {                     
             Console.WriteLine("Скачивание файла закончилось");           
        }        
        private static void ImageDownloader_ImageStarted(object? sender, EventArgs e)
        {          
            Console.WriteLine("Скачивание файла началось");
        }
    }
}