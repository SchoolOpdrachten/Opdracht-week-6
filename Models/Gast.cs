
using Microsoft.AspNetCore.Identity;

namespace Models;

public class Gast : Persoon
{
    public List<Attractie> GelikedAttracties { get; set; }

}