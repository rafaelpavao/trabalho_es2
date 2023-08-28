namespace Atividade.Api.Entities;

public class AdditionalService
{
    public int Id { get; set; }
    public string Service = string.Empty;
    public double Price { get; set; }
    public string Type { get; set; }

    public List<Store> Stores {get; set;} = new();

}