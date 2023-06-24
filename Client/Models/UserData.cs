namespace Proj_APBD.Client.Models;

public class UserData
{
    public string Token { get; set; }
    public string Id { get; set; } = null!;
    public string Username { get; set; } = null!;
    public string Role { get; set; } = null!;
    public bool NavLock { get; set; }
}