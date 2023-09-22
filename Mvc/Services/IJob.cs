namespace Mvc.Services
{
    public interface IJob
    {
        IEnumerable<string> GetDelayFiles();
        IEnumerable<string> GetRecursiveFiles();
        IEnumerable<string> GetFireandForget();
    }
}
