using System.Text.Json.Serialization;
using ApplicationLayer.Service;
using InfrastructureLayer.Context;
using InfrastructureLayer.Repository.Implementation;
using InfrastructureLayer.Repository.Interface;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddScoped<IInventoryRepository, InventoryRepository>();
builder.Services.AddScoped<IItemRepository, ItemRepository>();
builder.Services.AddScoped<ISalesRepository, SalesRepository>();
builder.Services.AddScoped<ItemService>();
builder.Services.AddScoped<SalesService>();
builder.Services.AddScoped<InventoryService>();
builder.Services.AddEntityFrameworkNpgsql();
builder.Services.AddDbContext<ApplicationContext>();
/*builder.Services.AddControllers();*/
builder.Services.AddControllers().AddJsonOptions(x =>
    x.JsonSerializerOptions.ReferenceHandler = ReferenceHandler.IgnoreCycles);
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
var app = builder.Build();

app.UseCors(options => options.AllowAnyOrigin().AllowAnyHeader().AllowAnyMethod());

// Configure the HTTP request pipeline.
/*if (!app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI(c => c.SwaggerEndpoint("/swagger/v1/swagger.json", "WebApplication2 v1"));
}*/
app.UseSwagger();
app.UseSwaggerUI(c => c.SwaggerEndpoint("/swagger/v1/swagger.json", "WebApplication2 v1"));

app.UseHttpsRedirection();
app.UseStaticFiles();


app.UseAuthorization();
app.MapControllers();
app.Run();