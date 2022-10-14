
using Microsoft.AspNetCore.Identity;

namespace Models
{
    public class Persoon : IdentityUser
    {
        public string Geslacht { get; set; }
    }
}