
using Microsoft.AspNetCore.Identity;

public class Gast : IdentityUser
{
    public string Geslacht { get; set; } = default!;
}