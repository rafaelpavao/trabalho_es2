using Microsoft.EntityFrameworkCore;
using Atividade.Api.Entities;

namespace Atividade.Api.DbContexts;

public class CartsyContext : DbContext
{
    public DbSet<Person> Persons { get; set; } = null!;
    public DbSet<LegalCustomer> LegalCustomers { get; set; } = null!;
    public DbSet<NaturalCustomer> NaturalCustomers { get; set; } = null!;
    public DbSet<State> States { get; set; } = null!;
    public DbSet<City> Cities { get; set; } = null!;
    public DbSet<Address> Addresses { get; set; } = null!;
    public DbSet<Consumer> Consumers { get; set; } = null!;
    public DbSet<Store> Stores { get; set; } = null!;
    public DbSet<StoreService> StoreServices { get; set; } = null!;
    public DbSet<OrderStatus> OrderStatuses { get; set; } = null!;
    public DbSet<Order> Orders { get; set; } = null!;
    public DbSet<OrderItem> OrderItems { get; set; } = null!;
    public DbSet<Item> Items { get; set; } = null!;
    public DbSet<ItemType> ItemTypes { get; set; } = null!;
    public DbSet<AdditionalService> AdditionalServices { get; set; } = null!;


    public CartsyContext(DbContextOptions<CartsyContext> options)
    : base(options) { }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        var person = modelBuilder.Entity<Person>();

        person
            .ToTable("Person")
            .HasDiscriminator(c => c.Type)
            .HasValue<Consumer>(1)
            .HasValue<LegalCustomer>(2)
            .HasValue<NaturalCustomer>(3);

        person
            .HasOne(p => p.Address)
            .WithOne(a => a.Person)
            .HasForeignKey<Person>(p => p.IdAddress);

        person
            .Property(p => p.Name)
            .HasMaxLength(100)
            .IsRequired();

        person
            .Property(p => p.Type)
            .IsRequired();

        person
            .Property(p => p.Email)
            .HasMaxLength(100)
            .IsRequired();

        person
            .Property(p => p.CellPhone)
            .HasMaxLength(13)
            .IsFixedLength()
            .IsRequired();

        person.Property(p => p.HomePhone)
            .HasMaxLength(13)
            .IsFixedLength();


        var consumer = modelBuilder.Entity<Consumer>();

        consumer.Property(c => c.CPF)
            .IsFixedLength()
            .HasMaxLength(11)
            .IsRequired();

        var naturalCustomer = modelBuilder.Entity<NaturalCustomer>();

        naturalCustomer.Property(c => c.CPF)
            .IsFixedLength()
            .HasMaxLength(11)
            .IsRequired();

        var legalCustomer = modelBuilder.Entity<LegalCustomer>();

        legalCustomer.Property(c => c.CNPJ)
            .IsFixedLength()
            .HasMaxLength(14)
            .IsRequired();


        var state = modelBuilder.Entity<State>();
        var city = modelBuilder.Entity<City>();
        var address = modelBuilder.Entity<Address>();

        state
            .HasMany(s => s.Cities)
            .WithOne(c => c.State)
            .HasForeignKey(c => c.IdState);

        state
            .Property(s => s.Name)
            .HasMaxLength(50)
            .IsRequired();

        state
            .Property(s => s.UF)
            .HasMaxLength(2)
            .IsFixedLength()
            .IsRequired();

        city
            .HasMany(c => c.Addresses)
            .WithOne(a => a.City)
            .HasForeignKey(a => a.IdCity);

        city
            .Property(c => c.Name)
            .HasMaxLength(100)
            .IsRequired();

        address
            .HasOne(a => a.Store)
            .WithOne(p => p.Address)
            .HasForeignKey<Store>(p => p.IdAddress);

        address
            .Property(a => a.Number)
            .IsRequired();

        address
            .Property(a => a.Street)
            .HasMaxLength(50)
            .IsRequired();

        address
            .Property(a => a.CEP)
            .HasMaxLength(8)
            .IsFixedLength()
            .IsRequired();

        var store = modelBuilder.Entity<Store>();

        // store
        //     .HasOne(s => s.Address)
        //     .WithOne(a => a.Store)
        //     .HasForeignKey<Store>(s => s.IdAddress);

        store
            .HasMany(s => s.Services)
            .WithMany(s => s.Stores)
            .UsingEntity<StoreService>(ss => ss.ToTable("StoreService")
            );

        store
            .Property(s => s.Name)
            .HasMaxLength(100)
            .IsRequired();

        store
            .HasMany(s => s.Items)
            .WithOne(i => i.Store)
            .HasForeignKey(s => s.IdStore);
        
        var order = modelBuilder.Entity<Order>();
        
        order
            .HasMany(o => o.Items)
            .WithMany(i => i.Orders)
            .UsingEntity<OrderItem>(oi => oi.ToTable("OrderItem")
            );
        
        order
            .HasOne(o => o.Store)
            .WithMany(s => s.Orders)
            .HasForeignKey(o => o.IdStore);

        order
            .HasOne(o => o.Consumer)
            .WithMany(c => c.Orders)
            .HasForeignKey(o => o.IdConsumer);

        order
            .HasOne(o => o.Status)
            .WithMany(os => os.Orders)
            .HasForeignKey(o => o.IdStatus);

        order
            .Property(o => o.Price)
            .HasPrecision(2, 10)
            .IsRequired();

        var orderStatus = modelBuilder.Entity<OrderStatus>();
        
        orderStatus.Property(os => os.Status)
            .HasMaxLength(50)
            .IsRequired();
        
        var item = modelBuilder.Entity<Item>();

        item
            .HasOne(i => i.Type)
            .WithMany(it => it.Items)
            .HasForeignKey(i => i.IdType);

        item
            .Property(i => i.Description)
            .HasMaxLength(100);

        item
            .Property(i => i.Name)
            .HasMaxLength(50)
            .IsRequired();

        item
            .Property(i => i.Price)
            .HasPrecision(2, 10)
            .IsRequired();

        item
            .Property(i => i.Stock)
            .IsRequired();

        var additionalServices = modelBuilder.Entity<AdditionalService>();

        additionalServices
            .Property(asvc => asvc.Price)
            .HasPrecision(2, 10)
            .IsRequired();
        
        additionalServices
            .Property(asvc => asvc.Type)
            .HasMaxLength(50)
            .IsRequired();

        var itemType = modelBuilder.Entity<ItemType>();

        itemType
            .Property(it => it.Type)
            .HasMaxLength(50)
            .IsRequired();

        itemType
            .Property(it => it.Tax)
            .IsRequired();
        
        
        modelBuilder.Entity<State>().HasData(
            new State { Id = 1, Name = "California", UF = "CA" },
            new State { Id = 2, Name = "New York", UF = "NY" },
            new State { Id = 3, Name = "Texas", UF = "TX" });

        modelBuilder.Entity<City>().HasData(
            new City { Id = 1, Name = "Los Angeles", IdState = 1 },
            new City { Id = 2, Name = "New York City", IdState = 2 },
            new City { Id = 3, Name = "Houston", IdState = 3 });

        modelBuilder.Entity<Address>().HasData(
            new Address { Id = 1, CEP = "12345678", Number = 123, IdCity = 1, Street = "Main St" },
            new Address { Id = 2, CEP = "87654321", Number = 456, IdCity = 2, Street = "Broadway Ave" },
            new Address { Id = 3, CEP = "98765432", Number = 789, IdCity = 3, Street = "Oak St" });
        
        modelBuilder.Entity<Consumer>().HasData(
            new Consumer
            {
                Id = 1,
                Name = "Linus Torvalds",
                CellPhone = "123-456-7890",
                HomePhone = "987-654-3210",
                Email = "linus@example.com",
                Type = 1, // Consumer's discriminator value
                IdAddress = 1,
                CPF = "73473943096"
            });
        modelBuilder.Entity<LegalCustomer>().HasData(

            new LegalCustomer
            {
                Id = 2,
                Name = "Microsoft Corp",
                CellPhone = "234-567-8901",
                HomePhone = "876-543-2109",
                Email = "info@microsoft.com",
                Type = 2, // LegalCustomer's discriminator value
                IdAddress = 2,
                CNPJ = "12345678901234"
            });
        modelBuilder.Entity<NaturalCustomer>().HasData(

            new NaturalCustomer
            {
                Id = 3,
                Name = "Alice Johnson",
                CellPhone = "345-678-9012",
                HomePhone = "765-432-1098",
                Email = "alice@example.com",
                Type = 3, // NaturalCustomer's discriminator value
                IdAddress = 3,
                CPF = "98765432109"
            });
        
        modelBuilder.Entity<AdditionalService>().HasData(
            new AdditionalService { Id = 1, Price = 10.99, Type = "Express Shipping" },
            new AdditionalService { Id = 2, Price = 5.00, Type = "Gift Wrapping" },
            new AdditionalService { Id = 3, Price = 2.50, Type = "Extended Warranty" });

        modelBuilder.Entity<ItemType>().HasData(
            new ItemType { Id = 1, Type = "Electronics", Tax = 10 },
            new ItemType { Id = 2, Type = "Clothing", Tax = 5 },
            new ItemType { Id = 3, Type = "Books", Tax = 0 });

        modelBuilder.Entity<OrderStatus>().HasData(
            new OrderStatus { Id = 1, Status = "Pending" },
            new OrderStatus { Id = 2, Status = "Processing" },
            new OrderStatus { Id = 3, Status = "Shipped" },
            new OrderStatus { Id = 4, Status = "Delivered" });
        
        modelBuilder.Entity<Store>().HasData(
            new Store { Id = 1, Name = "ElectroMart", IdAddress = 1 },
            new Store { Id = 2, Name = "FashionHub", IdAddress = 2 },
            new Store { Id = 3, Name = "Book Haven", IdAddress = 3 });

        modelBuilder.Entity<Item>().HasData(
            new Item { Id = 1, Name = "Smartphone", Price = 499.99, Description = "High-end smartphone", Stock = 50, IdStore = 1, IdType = 1 },
            new Item { Id = 2, Name = "T-Shirt", Price = 19.99, Description = "Cotton crew-neck t-shirt", Stock = 100, IdStore = 2, IdType = 2 },
            new Item { Id = 3, Name = "Sci-Fi Novel", Price = 12.99, Description = "Bestselling science fiction book", Stock = 30, IdStore = 3, IdType = 3 });

        modelBuilder.Entity<Order>().HasData(
            new Order { Id = 1, Price = 499.99, IdStore = 1, IdStatus = 1, IdConsumer = 1, Date = DateTime.UtcNow },
            new Order { Id = 2, Price = 19.99, IdStore = 2, IdStatus = 2, IdConsumer = 2, Date = DateTime.UtcNow },
            new Order { Id = 3, Price = 12.99, IdStore = 3, IdStatus = 3, IdConsumer = 3, Date = DateTime.UtcNow });

        modelBuilder.Entity<StoreService>().HasData(
            new StoreService {StoreId = 1, ServicesId = 1, CreatedAt = DateTime.UtcNow },
            new StoreService {StoreId = 2, ServicesId = 2, CreatedAt = DateTime.UtcNow },
            new StoreService {StoreId = 3, ServicesId = 3, CreatedAt = DateTime.UtcNow });

        modelBuilder.Entity<OrderItem>().HasData(
            new OrderItem { ItemsId = 1, OrdersId = 1, CreatedAt = DateTime.UtcNow },
            new OrderItem { ItemsId = 2, OrdersId = 2, CreatedAt = DateTime.UtcNow },
            new OrderItem { ItemsId = 3, OrdersId = 3, CreatedAt = DateTime.UtcNow });

        base.OnModelCreating(modelBuilder);
    }

}