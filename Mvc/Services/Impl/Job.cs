
using Mvc.Models;
using Mvc.Repository;

namespace Mvc.Services.Impl
{
    public class Job : IJob
    {

        private readonly IRepository<Request> _request;
        private readonly IFileWriter _file;
        private readonly IConfiguration _configuration;
        private static List<Request> _requests;
        public Job(IRepository<Request> request, IFileWriter file, IConfiguration configuration)
        {
            _request = request;
            _file = file;
            _configuration = configuration;
            _requests = _request.GetAllAsync().Result;

        }

        public IEnumerable<string> GetDelayFilesData()
        {
            return GetJobs("DelayJob");
        }

        public IEnumerable<string> GetFireandForget()
        {
            return GetJobs("FireandForgotJob");
        }

        public IEnumerable<string> GetRecursiveFiles()
        {
            return GetJobs("RecurringJob");
        }


        public IEnumerable<string> GetJobs(string folderName)
        {
            CreateDirectories();
            string path = _configuration.GetSection(folderName).Value;
            _file.Write(_requests, path);

            return Directory.GetFiles(path).ToList();
        }
        private void CreateDirectories()
        {
            string[] path = _configuration.GetSection("Paths").Get<string[]>();

            foreach (var item in path)
            {
                if (!Directory.Exists(item))
                    Directory.CreateDirectory(item);
            }
        }

    }
}
