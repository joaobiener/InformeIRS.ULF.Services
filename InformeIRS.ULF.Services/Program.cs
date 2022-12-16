using InformeIR.ULF.Services.Context;
using InformeIR.ULF.Services.Repository;
using InformeIR.ULF.Services.Repository.Interface;
using Microsoft.AspNetCore.Hosting;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();

//builder.Services.AddControllers().AddNewtonsoftJson(options => {
//    options.SerializerSettings.ReferenceLoopHandling = Newtonsoft.Json.ReferenceLoopHandling.Ignore;
//});
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

string connString = builder.Configuration.GetSection("ConnectionStrings").GetSection("OracleConnection").Value;

//string connString = builder.Configuration.GetConnectionString("OracleConnection");


builder.Services.AddAutoMapper(typeof(Program).Assembly);

#region [CORS]
builder.Services.AddCors();
#endregion

builder.Services.AddScoped<IBaseRepository, BaseRepository>();

builder.Services.AddScoped<IArquivoRepository, ArquivoRepository>();

builder.Services.AddScoped<IInformeIRRepository, InformeIRRepository>();

builder.Services.AddDbContext<InformeIRSContexto>
    (options => options.UseOracle(connString));



var app = builder.Build();

app.UsePathBase("/api/InformeIR");

app.Use((context, next) =>
{
    context.Request.PathBase = "/api/InformeIR";
    return next();
});

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();



#region [Cors]
app.UseCors(c =>
{
    c.AllowAnyHeader();
    c.AllowAnyMethod();
    c.AllowAnyOrigin();
});
#endregion


app.UseAuthorization();

app.MapControllers();

app.Run();

