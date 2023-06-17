namespace Proj_APBD.Server.Interfaces;

public interface IAccountServices
{
    public Task<int> Register(string username, string password);
    public Task<(int, string, string)> Login(string username, string password);
    public Task<bool> UserExistsAsync(string username);
}