namespace Mvc.Services
{
    public interface IJob
    {
        IEnumerable<string> GetDelayFilesFiles();
        IEnumerable<string> GetRecursiveFiles();
        IEnumerable<string> GetFireandForget();
    }
}
