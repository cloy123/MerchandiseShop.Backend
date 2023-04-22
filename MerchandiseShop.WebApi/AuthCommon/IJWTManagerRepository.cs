namespace MerchandiseShop.WebApi.AuthCommon
{
    public interface IJWTManagerRepository
    {
        Tokens GenerateToken(TokenData tokenData);
        Tokens GenerateRefreshToken(TokenData tokenData);
        TokenData GetPrincipalFromExpiredToken(string token);
    }
}
