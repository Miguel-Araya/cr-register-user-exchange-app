using Microsoft.EntityFrameworkCore;
using PracticaExamen.BW.CU;
using PracticaExamen.BW.Interfaces.BW;
using PracticaExamen.BW.Interfaces.DA;
using PracticaExamen.BW.Interfaces.SG;
using PracticaExamen.DA.Acciones;
using PracticaExamen.DA.Contexto;
using PracticaExamen.SG.Acciones;
var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.AddHttpClient();

builder.Services.AddTransient<IGestionarUsuarioBW, GestionarUsuarioBW>();
builder.Services.AddTransient<IGestionarUsuarioDA, GestionarUsuarioDA>();
builder.Services.AddTransient<IGestionarTipoCambioSG, GestionarTipoCambioSG>();
builder.Services.AddTransient<IGestionarTipoCambioBW, GestionarTipoCambioBW>();
builder.Services.AddTransient<IGestionarLogDA, GestionarLogDA>();
builder.Services.AddTransient<IGestionarLogBW, GestionarLogBW>();
builder.Services.AddDbContext<AdmUsuarioContext>(options =>
{
    options.UseSqlServer(builder.Configuration.GetConnectionString("conection"));
});
var app = builder.Build();
app.UseCors("AllowOrigin");
app.UseCors(options =>
{
    options.AllowAnyOrigin();
    options.AllowAnyMethod();
    options.AllowAnyHeader();
});
/*
using (var scope = app.Services.CreateScope()) { 
    var context = scope.ServiceProvider.GetRequiredService<AdmUsuarioContext>();
    context.Database.Migrate();
}*/

// Configure the HTTP request pipeline.
//if (app.Environment.IsDevelopment())
//{
    app.UseSwagger();
    app.UseSwaggerUI();
//}

app.UseAuthorization();

app.MapControllers();

app.Run();
