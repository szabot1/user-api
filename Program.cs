using Microsoft.EntityFrameworkCore;
using Users.Data;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddDbContext<UsersContext>(options =>
{
    options.UseMySql(
        "server=localhost;database=fz_users;user=fz_users;password=asd123",
        MySqlServerVersion.LatestSupportedServerVersion
    );
});

builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var app = builder.Build();

if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

using (var serviceScope = app.Services
            .GetRequiredService<IServiceScopeFactory>()
            .CreateScope())
{
    using var ctx = serviceScope.ServiceProvider.GetService<UsersContext>();
    ctx!.Database.Migrate();
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
