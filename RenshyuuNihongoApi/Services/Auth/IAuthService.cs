namespace RenshyuuNihongoApi.Services.Auth;

public interface IAuthService
{
    Task RegisterAsync(string username, string password);
    Task LoginAsync(string username, string password);
    Task LogoutAsync();

    Task RecoverPasswordAsync()
    {
        return Task.CompletedTask;
    }

    Task ChangePasswordAsync()
    {
        return Task.CompletedTask;
    }
    Task DeleteAsync(string username);

    Task TwoFactorAuthAsync(string username, string oldPassword, string newPassword)
    {
        return Task.CompletedTask;
    }
}