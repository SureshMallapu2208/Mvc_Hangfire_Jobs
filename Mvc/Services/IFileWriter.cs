using Mvc.Models;

namespace Mvc.Services
{
    public interface IFileWriter
    {
        void Write(List<Request> request, string path);
    }
}
