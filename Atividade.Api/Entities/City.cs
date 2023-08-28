namespace Atividade.Api.Entities;

public class City
{
    public int Id { get; set; }
    public string Name { get; set; } = string.Empty;
    public int IdState { get; set; }
    public State State{ get; set; }
    public List<Address> Addresses { get; set; } = new();
}
