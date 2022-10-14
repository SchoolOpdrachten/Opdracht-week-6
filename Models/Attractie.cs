
using System.ComponentModel.DataAnnotations;

namespace Models;

public class Attractie
{
    [Key]
    public int Id { get; set; }
    public string Naam { get; set; }
    public int Engheid { get; set; }
    public DateTime Bouwjaar { get; set; }

    public int AantalLikes { get; set; }
}