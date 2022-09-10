using TechParser.Core.Data;
using TechParser.Models;
using TechParser.Storage;

namespace TechParser.Core.Parser
{
    public class FileDownloader
    {
        private readonly IStorage _storage;
        public FileDownloader(IStorage storage)
        {
            _storage = storage;
        }

        public async void DownloadFilesObrNet()
        {
            byte[] data;
            using var client = new HttpClient();
            var metalloobrabotchikiFiles = CreateDirectory(@"C:\Users\Tema\Desktop\ObrabotkaNetFiles");
            var parseFiles = _storage.GetParseFiles(2);
            foreach (var parseFile in parseFiles)
            {
                using HttpResponseMessage response = await client.GetAsync(parseFile.DownloadUrl);
                using HttpContent content = response.Content;
                data = await content.ReadAsByteArrayAsync();
                using FileStream file = File.Create($@"C:\Users\Tema\Desktop\ObrabotkaNetFiles\{parseFile.NameFile}.zip"); //path = "wwwroot\XML\1.zip"
                file.Write(data, 0, data.Length);
            }
        }

        public async void DownloadFilesMetObr()
        {
            byte[] data;
            using var client = new HttpClient();
            var metalloobrabotchikiFiles = CreateDirectory(@"C:\Users\Tema\Desktop\MetalloobrabotchikiFiles");
            var parseFiles = _storage.GetParseFiles(5);
            foreach (var parseFile in parseFiles)
            {
                using HttpResponseMessage response = await client.GetAsync(parseFile.DownloadUrl);
                using HttpContent content = response.Content;
                data = await content.ReadAsByteArrayAsync();
                using FileStream file = File.Create($@"C:\Users\Tema\Desktop\MetalloobrabotchikiFiles\{parseFile.NameFile}.zip"); //path = "Desktop\папка\архивЗаказов.zip"
                file.Write(data, 0, data.Length);
            }
        }

        public async void DownloadFilesMetallPortal()
        {
            byte[] data;
            using var client = new HttpClient();
            var mettallPortalFiles = CreateDirectory(@"C:\Users\Tema\Desktop\MetallPortalFiles");
            var parseFiles = _storage.GetParseFiles(1);
            foreach (var parseFile in parseFiles)
            {
                using HttpResponseMessage response = await client.GetAsync(parseFile.DownloadUrl);
                using HttpContent content = response.Content;
                data = await content.ReadAsByteArrayAsync();
                using FileStream file = File.Create($@"C:\Users\Tema\Desktop\MetallPortalFiles\{parseFile.NameFile}.zip");
                file.Write(data, 0, data.Length);

            }
        }

        public static DirectoryInfo CreateDirectory(string path) //создание папки под заказы
        {
            DirectoryInfo directory = new(path);
            if (!directory.Exists)
                directory.Create();
            return directory;
        }

    }        
    
}
