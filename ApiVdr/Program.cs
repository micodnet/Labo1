using Dal.Vdr.Entities;
using Dal.Vdr.Interfaces;
using Dal.Vdr.Repositories;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.AddScoped<IRepository<AdministrateurEntity, int>, AdministrateurRepository>();
builder.Services.AddScoped<IRepository<UtilisateursEntity, int>, UtilisateursRepository>();
builder.Services.AddScoped<IRepository<ArticlesEntity, int>, ArticlesRepository>();
builder.Services.AddScoped<IRepository<MediasEntity, int>, MediasRepository>();
builder.Services.AddCors(options => options.AddPolicy("default", builder =>
{
    builder.AllowAnyOrigin();
    builder.AllowAnyMethod();
    builder.AllowAnyHeader();
}));

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
app.UseCors("default");
app.Run();
