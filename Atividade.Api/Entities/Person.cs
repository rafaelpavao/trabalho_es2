namespace Atividade.Api.Entities;

public abstract class Person
{
    public int Id { get; set; }
    public string Name { get; set; } = string.Empty;
    public string CellPhone { get; set; }  = string.Empty;
    public string HomePhone { get; set;}  = string.Empty;
    public string Email { get; set; } = string.Empty;
    public int Type { get; set; }

    public int IdAddress { get; set; }
    public Address Address { get; set; }


}