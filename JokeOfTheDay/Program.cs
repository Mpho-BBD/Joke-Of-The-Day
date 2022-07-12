using JokeOfTheDay.Data;
using JokeOfTheDay.Repositories;
using JokeOfTheDay.Services;
using FluentValidation.AspNetCore;
using JokeOfTheDay.Domain.Validation;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddControllers();

// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
ConfigureServices(builder.Services);

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();
app.UseRouting();
app.UseAuthorization();
app.MapControllers();
app.Run();

void ConfigureServices(IServiceCollection services)
{
    services.AddScoped<IJokeRepository, JokeRepository>();
    services.AddScoped<IJokeService, JokeService>();

    services.AddDbContext<JokeContext>();
    services.AddAutoMapper(typeof(Program).Assembly);
    services.AddMvc();
    services.AddControllers().AddNewtonsoftJson();
    services.AddFluentValidation(fv => fv.RegisterValidatorsFromAssemblyContaining<JokeDTOValidator>());

    services.AddControllers();
}