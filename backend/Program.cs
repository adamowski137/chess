var builder = WebApplication.CreateBuilder(args);
var hearderRules = "_headerRules";
// Add services to the container.

builder.Services.AddControllers();
builder.Services.AddCors( options =>
{
    options.AddPolicy(name: hearderRules,
        builder =>
        {
            builder.AllowAnyOrigin();
            builder.AllowAnyMethod();
            builder.AllowAnyHeader();
        }) ;
});

var app = builder.Build();

// Configure the HTTP request pipeline.
app.UseCors(hearderRules);

app.UseHttpsRedirection();



app.UseAuthorization();

app.MapControllers();

app.Run();
