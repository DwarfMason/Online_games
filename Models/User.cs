using System.Security.Claims;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Identity;

namespace WebApplication1.Models
{
    public class User : IdentityUser
    {
        public string Nickname { get; set; }
        
        public string HeroType { get; set; }
    }
}