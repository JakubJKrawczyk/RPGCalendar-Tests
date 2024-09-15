using RpgCalendar.ConfigApi;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.MapGet("/{environment}", ExternalFunctions.GetEnvs)
    .WithName("GetEnvs")
    .WithOpenApi();

app.MapGet("/{environment}/keys", ExternalFunctions.GetEnvsNames).WithName("GetEnvsNames").WithOpenApi();
app.Run();



