// TPT
namespace Atividade.Api.Entities;

public class Consumer : Person
{
    public string CPF { get; set; } = string.Empty;
    public List<Order> Orders { get; set; } = new();
}