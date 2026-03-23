using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.IdentityModel.Tokens;
using Microsoft.OpenApi;
using Navbat.Application;
using Navbat.Infrastructure;
using System.Text;                                      // Encoding ishlashi uchun

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring OpenAPI at https://aka.ms/aspnet/openapi
builder.Services.AddOpenApi();

builder.Services.AddApplication();
builder.Services.AddInfrastructure(builder.Configuration);
builder.Services.AddSwaggerGen();
builder.Services.AddSwaggerGen(options =>       //Swaggerni nastroyka qilish. Swaggerda Authorization qilish uchun quluf iconcasini chiqarish uchun
{
    options.SwaggerDoc("v1", new OpenApiInfo { Title = "Authentication Sample", Version = "v1.0.0", Description = "Authentication Sample Simple" });

    var securityShceme = new OpenApiSecurityScheme
    {
        Description = "Greeting Methodini ishlatish uchun Avtorizatsiya qilishingiz kerak",
        Name = "Authorization",
        In = ParameterLocation.Header,
        Type = SecuritySchemeType.Http,
        Scheme = "bearer",
        //Reference = new OpenApiReference
        //{
        //    Type = ReferenceType.SecurityScheme,
        //    Id = "Bearer"
        //}
    };

    options.AddSecurityDefinition("Bearer", securityShceme);
    //var securityRequirement = new OpenApiSecurityRequirement
    //            {
    //                {securityShceme,new[] {"Bearer"} }
    //            };
    //options.AddSecurityRequirement(securityRequirement);
});




builder.Services.AddAuthentication(JwtBearerDefaults.AuthenticationScheme).AddJwtBearer(  // Token Eskirgan yoki yoqlikga tekshiradi
    options =>
    {
        options.TokenValidationParameters = new TokenValidationParameters()
        {
            ValidateIssuer = true,
            ValidateAudience = true,
            ValidateLifetime = true,
            ValidateIssuerSigningKey = true,
            ValidIssuer = builder.Configuration["JWT:ValidIssuer"],
            ValidAudience = builder.Configuration["JWT:ValidAudence"],
            IssuerSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(builder.Configuration["JWT:Secret"]!)),
            ClockSkew = TimeSpan.Zero
        };

        options.Events = new JwtBearerEvents
        {
            OnAuthenticationFailed = (context) =>
            {
                if (context.Exception.GetType() == typeof(SecurityTokenExpiredException))
                {
                    context.Response.Headers.Add("IsTokenExpired", "true");
                }
                return Task.CompletedTask;
            }
        };
    });

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.MapOpenApi();
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseAuthentication();    // yuqoridagi AddAuthentication ishlatib qoyish -21
app.UseAuthorization();

app.MapControllers();

app.Run();
