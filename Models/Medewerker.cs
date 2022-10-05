
using Microsoft.AspNetCore.Identity;

public class Medewerker : IdentityUser
{
    public string Geslacht { get; set; } = default!;
}