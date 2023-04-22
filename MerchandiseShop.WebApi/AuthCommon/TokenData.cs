namespace MerchandiseShop.WebApi.AuthCommon
{
    public class TokenData
    {
        public Guid UserId { get; set; }
        public string Email { get; set; }
        public string RoleName { get; set; }
    }
}
