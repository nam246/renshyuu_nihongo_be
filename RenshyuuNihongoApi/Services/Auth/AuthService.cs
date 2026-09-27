namespace RenshyuuNihongoApi.Services.Auth;

public class AuthService : IAuthService
{
   public Task LoginAsync(string username, string password)
   {
      throw new NotImplementedException();
   }
   
   public Task LogoutAsync()
   {
      throw new NotImplementedException();
   }

   public Task RegisterAsync(string username, string password)
   {
      throw new NotImplementedException();
   }
   
   public Task DeleteAsync(string username)
   {
      throw new NotImplementedException();
   }

   public Task ChangePasswordAsync(string username, string oldPassword, string newPassword)
   {
      throw new NotImplementedException();
   }
}