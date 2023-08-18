using Mvc.Models;

namespace Mvc.Services.Impl
{
    public class FileWriter : IFileWriter
    {
        public void Write(List<Models.Request> requests, string path)
        {
            string fileName = Path.Combine(path, $"{DateTime.UtcNow.ToString("yyyy-MM-ddThhmmss.fffZ")}.txt");

            if (!Directory.Exists(path))
                Directory.CreateDirectory(path);

            string message = GetData(requests);

            StreamWriter file =new StreamWriter(fileName);
            file.Write(message);
            file.Close();

        }

        private string GetData(List<Request> requests)
        {
            string requestData = string.Empty;
            foreach (var request in requests)
            {
                requestData += string.Format("{0}|{1}{2}{3}", request.Name, request.RequestType, request.RequestMessage, Environment.NewLine);

            }
            return requestData;
        }
    }
}
