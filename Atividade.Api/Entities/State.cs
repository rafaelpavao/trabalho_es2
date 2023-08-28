namespace Atividade.Api.Entities;

public class State
{
    public int Id { get; set; }
    public string Name { get; set; } = string.Empty;
    public string UF { get; set; } = string.Empty;
    public List<City> Cities { get; set; } = new();
}