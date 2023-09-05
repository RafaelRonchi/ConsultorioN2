global using API_Consultorio.Data;
global using API_Consultorio.Service;
global using API_Consultorio.Model;
global using API_Consultorio.Service.Interfaces;
global using ConsultorioN2.DTO;



var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.AddDbContext<DataContext>(options =>
{
    options.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection"));
});
builder.Services.AddScoped<IConsultaService, ConsultaService>();
builder.Services.AddScoped<IMedicoService, MedicoService>();
builder.Services.AddScoped<IPacienteService, PacienteService>();


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
