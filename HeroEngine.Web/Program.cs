// Program.cs
using HeroEngine.Core.Data;
using HeroEngine.Core.Combat;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddRazorPages();

// Assegurem que la carpeta wwwroot/data existeixi
var env = builder.Environment;
string dataPath = Path.Combine(env.WebRootPath, "data");
if (!Directory.Exists(dataPath))
    Directory.CreateDirectory(dataPath);

// Registrem els serveis de fitxers i combat
builder.Services.AddSingleton(new HeroRepository(Path.Combine(dataPath, "heroes.json")));
builder.Services.AddSingleton(new CsvStatsWriter(Path.Combine(dataPath, "combat_stats.csv")));
builder.Services.AddSingleton(new CombatLogWriter(Path.Combine(dataPath, "combat_log.txt")));
builder.Services.AddSingleton(GameConfig.Load(Path.Combine(dataPath, "game_config.xml")));
builder.Services.AddSingleton<CombatService>();

var app = builder.Build();

if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Error");
    app.UseHsts();
}

app.UseStaticFiles();
app.UseRouting();
app.MapRazorPages();
app.Run();