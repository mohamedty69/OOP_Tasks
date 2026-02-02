using API_CRUD.Data;
using API_CRUD.MIddlewares;
using API_CRUD.Filter;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
// I can register my filter in AddControllers method it will be applied globally to all controllers and actions
// and it will support dependency injection
// Global action filter (it will be applied to all controllers and actions for any request)
builder.Services.AddControllers(options =>
{
     options.Filters.Add<LogActivityFilter>();
});
// Learn more about configuring OpenAPI at https://aka.ms/aspnet/openapi
builder.Services.AddOpenApi();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.AddDbContext<AppDbContext>(builder =>
    builder.UseSqlServer("Data Source=.;Initial catalog = Products;Integrated Security=True; trust server certificate=true "));
var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.MapOpenApi();
    app.UseSwagger();
    app.UseSwaggerUI();
}
app.UseMiddleware<RateLimitingMiddleware>();
app.UseMiddleware<ProfilingMiddleware>();
app.UseHttpsRedirection();

app.UseAuthorization();
app.MapControllers();

app.Run();
