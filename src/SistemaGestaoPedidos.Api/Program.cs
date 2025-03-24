using Microsoft.OpenApi.Models;

var builder = WebApplication.CreateBuilder(args);

// Adicona os serviços do MVC
builder.Services.AddControllers();

var app = builder.Build();

//app.UseHttpsRedirection();
app.UseAuthorization();
app.MapControllers(); // Mapeia os controllers para os endpoints

app.Run();

