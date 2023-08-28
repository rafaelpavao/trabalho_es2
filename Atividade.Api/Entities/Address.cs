namespace Atividade.Api.Entities;

public class Address
{
    public int Id { get; set; }
    public string Street = string.Empty;
    public string CEP { get; set; } = string.Empty;
    public int Number { get; set; }
    public int IdCity { get; set; }    
    public City City {get; set; }

    public Person? Person { get; set; }
    public Store? Store { get; set; }


}