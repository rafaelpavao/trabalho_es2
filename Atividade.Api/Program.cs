using Atividade.Api.DbContexts;
// using Atividade.Api.Repositories;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.WebHost.ConfigureKestrel(options => {
    options.ListenLocalhost(5000);
});

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

// builder.Services.AddScoped<IStudentRepository, StudentRepository>();

builder.Services.AddDbContext<CartsyContext>(options => 
{
    options
        .UseNpgsql("Host=localhost;Database=Cartsy;Username=postgres;Password=123");
});

// builder.Services.AddDbContext<StoreContext>(options => 
// {
//     options
//         .UseNpgsql("Host=localhost;Database=Cartsy;Username=postgres;Password=123");
// });
var app = builder.Build();



// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
