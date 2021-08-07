namespace JAC.MusicVideoList.Domain.Core.Interfaces
{
    public interface IPasswordService
    {
        bool Check(string hash, string password);
        string Hash(string password);
    }
}