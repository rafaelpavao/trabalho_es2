
namespace Atividade.Api.Entities;

public class Order
{
    public int Id { get; set; }
    public double Price { get; set;}
    public DateTime Date { get; set; }
    public int IdStore { get; set; }
    public Store Store { get; set; }
    public List<Item> Items { get; set; } = new();
    public int IdStatus { get; set; }
    public OrderStatus Status { get; set; }

    public int IdConsumer { get; set; }
    public Consumer Consumer { get; set; }

}