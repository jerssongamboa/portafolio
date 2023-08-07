using Microsoft.EntityFrameworkCore;
using Proyecto_Trouble.DataAccess.Models;
using Proyecto_Trouble.Services;
using Proyecto_Trouble.WebApi.Controllers;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

var cadenaConexion = builder.Configuration.GetConnectionString("defaultConnection");

builder.Services.AddDbContext<ModelContext>(x =>
    x.UseOracle(
        cadenaConexion,
        options => options.UseOracleSQLCompatibility("11")
    )
    
);
builder.Services.AddTransient<IComunaService, ComunaService>();
builder.Services.AddTransient<IRegionService, RegionService>();
builder.Services.AddTransient<IClienteService, ClienteService>();
builder.Services.AddTransient<IProfesionalService, ProfesionalService>();
builder.Services.AddTransient<IAdministradorService, AdministradorService>();
builder.Services.AddTransient<IEstadoUsuarioService, EstadousuarioService>();
builder.Services.AddTransient<IPagoService, PagoService>();
builder.Services.AddTransient<IEstadoEstadoPagoService, EstadoPagoService>();
builder.Services.AddTransient<IProfesionalActividadService, ProfesionalactividadService>();
builder.Services.AddTransient<IAccidenteService, AccidenteService>();
builder.Services.AddTransient<IActividadeService, ActividadeService>();
builder.Services.AddTransient<ITipousuarioService, TipousuarioService>();
builder.Services.AddTransient<IReporteService, ReporteService>();
builder.Services.AddTransient<IcontratoService, ContratoService>();





builder.Services.AddCors();
builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var app = builder.Build();

app.UseCors(options =>
{
    options.WithOrigins("http://localhost:4200");
    options.AllowAnyMethod();
    options.AllowAnyHeader();
});

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
