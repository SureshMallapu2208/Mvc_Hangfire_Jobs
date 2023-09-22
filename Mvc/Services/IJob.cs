namespace Mvc.Services
{
    public interface IJob
    {
        IEnumerable<string> GetDelayFilesDetails();
        IEnumerable<string> GetRecursiveFiles();
        IEnumerable<string> GetFireandForget();
    }
}
