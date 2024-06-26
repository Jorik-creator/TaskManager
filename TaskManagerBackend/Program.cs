using TaskManager.Models;

var builder = WebApplication.CreateBuilder(args);
builder.Services.AddDbContext<CalendarDbContext>();
builder.Services.AddCors(options =>
{
    options.AddDefaultPolicy(builder =>
    {
        builder.AllowAnyOrigin()
               .AllowAnyHeader()
               .AllowAnyMethod();
    });
});

builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var app = builder.Build();

using (var scope = app.Services.CreateScope())
{
    var services = scope.ServiceProvider;
    var context = services.GetRequiredService<CalendarDbContext>();

    SeedData(context);
}


if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseAuthorization();
app.UseCors();

app.MapControllers();

app.Run();

void SeedData(CalendarDbContext context)
{
    context.Database.EnsureCreated();

    if (!context.Resources.Any())
    {
        context.Resources.AddRange(
            new Resource { Name = "Meeting Room 1" },
            new Resource { Name = "Conference Room A" },
            new Resource { Name = "Office Space 1" }
        );
        context.SaveChanges();
    }
}
