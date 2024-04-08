namespace PCCC.API.MinIOs
{
    public interface IMinioService
    {
        Task<string> GetUrl(string fileName, string headerType);
    }
}
