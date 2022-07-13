using JokeOfTheDay.Data;
using JokeOfTheDay.Repositories;
using JokeOfTheDay.Services;
using FluentValidation.AspNetCore;
using JokeOfTheDay.Domain.Validation;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using JokeOfTheDay.Middleware;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddControllers();

// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddAuthentication(authOpts => {
    authOpts.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme;
    authOpts.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme;
}).AddJwtBearer(options =>
    {
        options.TokenValidationParameters = TokenValidation.GetCognitoTokenValidationParams();
        options.Events = new JwtBearerEvents() {
            OnAuthenticationFailed = c => {
                Console.WriteLine(c.Exception);
                return Task.CompletedTask;
            },
        };
    });

builder.Services.AddSwaggerGen();
builder.Services.AddAuthorization(options =>
{
    options.AddPolicy("Founders", policy =>
                      policy.RequireClaim("EmployeeNumber", "1", "2", "3", "4", "5"));
});
ConfigureServices(builder.Services);

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseRouting();
app.UseTokenAttachmentMiddleware();
app.UseAuthentication();
app.UseAuthorization();
app.MapControllers();
app.Run();

void ConfigureServices(IServiceCollection services)
{
    services.AddSingleton<ISingletonSecretManagerService, SecretManagerService>();
    services.AddScoped<IJokeRepository, JokeRepository>();
    services.AddScoped<IJokeService, JokeService>();
    services.AddScoped<ICookieService, CookieService>();

    services.AddDbContext<JokeContext>();
    services.AddAutoMapper(typeof(Program).Assembly);
    services.AddMvc();
    services.AddControllers().AddNewtonsoftJson();
    services.AddFluentValidation(fv => fv.RegisterValidatorsFromAssemblyContaining<JokeDTOValidator>());
    services.AddFluentValidation(fv => fv.RegisterValidatorsFromAssemblyContaining<JokeOfTheDayDTOValidator>());

    services.AddControllers();
}