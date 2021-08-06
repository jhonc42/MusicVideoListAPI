namespace JAC.MusicVideoList.Infrastructure.Main.Services
{
    public interface IPasswordService
    {
        bool Check(string hash, string password);
        string Hash(string password);
    }
}