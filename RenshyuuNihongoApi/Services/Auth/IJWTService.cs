namespace RenshyuuNihongoApi.Services.Auth;

public interface IJWTService
{
    // Serialize dữ liệu thành JSON.
    string Create(Object payload, string secret);
    // Ký (sign) dữ liệu bằng thuật toán mật mã.
    Task Verify(string jwt, string secret);
    
}