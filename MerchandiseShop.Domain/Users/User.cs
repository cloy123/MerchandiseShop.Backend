using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MerchandiseShop.Domain.CurrencyTransactions;

namespace MerchandiseShop.Domain.Users
{
    public class User
    {
        public Guid Id { get; set; }
        public int UserTypeId { get; set; }
        public string FirstName { get; set; }//имя
        public string LastName { get; set; }//фамилия
        public DateTime Birthday { get; set; }
        public string Email { get; set; }
        public int PointBalance { get; set; } = 0;
        public int? ClassNumber { get; set; }
        public string? ClassLetter { get; set; }
        public bool IsAccess { get; set; }
        public int GenderId { get; set; }
        public string PasswordHash { get; set; }
        

        public void SetPassword(string password)
        {
            PasswordHash = GetHashFromString(password);
        }

        public static string CreatePassword()
        {
            //return Guid.NewGuid().ToString("d").Substring(1, 8);
            return "pass";
        }

        public static string GetHashFromString(string s)
        {
            using (System.Security.Cryptography.MD5 md5 = System.Security.Cryptography.MD5.Create())
            {
                byte[] inputBytes = Encoding.ASCII.GetBytes(s);
                byte[] hashBytes = md5.ComputeHash(inputBytes);
                
                return Convert.ToHexString(hashBytes).ToString();
            }
        }
    }
}
