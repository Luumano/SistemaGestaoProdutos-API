using Microsoft.OpenApi.Models;

var builder = WebApplication.CreateBuilder(args);

// Adicona os servi�os do MVC
builder.Services.AddControllers();

var app = builder.Build();

//app.UseHttpsRedirection();
app.UseAuthorization();
app.MapControllers(); // Mapeia os controllers para os endpoints

app.Run();

