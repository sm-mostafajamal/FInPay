namespace FinPay.Infrastructure.Services.Authentication;

public class JwtSetting
{
    public string Issuer {get; init;} = default!;
    public string Audience {get; init;} = default!;
    public string SecretKey {get; init;} = default!;
    public double Expire {get; init;} = default;
    public double RefreshTokenExpire {get; init;} = default;
}