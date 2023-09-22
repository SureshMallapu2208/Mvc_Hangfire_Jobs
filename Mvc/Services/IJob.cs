namespace Mvc.Services
{
    public interface IJob
    {
        IEnumerable<string> GetDelayFilesData();
        IEnumerable<string> GetRecursiveFiles();
        IEnumerable<string> GetFireandForget();
    }
}
