using EN.SOAP;
using System.IO;

namespace Lessons.Patterns.Console
{
    class Program
    {
        static void Main(string[] args)
        {
            var client = new HttpClient();

            client.Method = "POST";
            client.URL = "http://demonewarh.novacom.by/client2ws/external/integration?wsdl";

            var xmlDoc = File.ReadAllText("C:\\Users\\i.dorakh\\Desktop\\request_electronic_object.xml");
            client.SoapBody = xmlDoc;

            var sourceDirectory = "C:\\Users\\i.dorakh\\Desktop\\Файлы";
            var files = Directory.EnumerateFiles(sourceDirectory);
            foreach (string file in files)
            {
                var filename = file.Substring(sourceDirectory.Length + 1);
                string[] words = filename.Split('.');
                var guid = words[0];
                var fileType = words[1];
                var content_type = string.Empty;
                switch (fileType)
                {
                    case "TXT":
                        content_type = "text/*";
                        break;
                    case "PDF":
                        content_type = "application/pdf";
                        break;
                    case "JPG":
                        content_type = "image/jpeg";
                        break;
                    case "DOCX":
                        content_type = "application/vnd.openxmlformats-officedocument.wordprocessingml.document";
                        break;
                    case "ZIP":
                        content_type = "application/zip";
                        break;
                }

                client.AddContent(guid, file, "application/octet-stream", "binary");
            }

            var result = client.Send();

            System.Console.WriteLine("Code: " + result.Status);
            System.Console.WriteLine(result.Value);

            System.Console.ReadKey();
        }
    }
}
