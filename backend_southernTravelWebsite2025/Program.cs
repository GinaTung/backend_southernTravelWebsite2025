using backend_southernTravelWebsite2025.Data;
using backend_southernTravelWebsite2025.Repositories;
using backend_southernTravelWebsite2025.Repositories.Interfaces;
using backend_southernTravelWebsite2025.Services;
using backend_southernTravelWebsite2025.Services.Interfaces;
using Microsoft.AspNetCore.HttpLogging;
using Microsoft.EntityFrameworkCore;
using Npgsql;

var builder = WebApplication.CreateBuilder(args);

// 1) 連線字串：環境變數優先（Render / 伺服器）
var envConn = Environment.GetEnvironmentVariable("SUPABASE_DB_CONNECTION");
var connectionString = !string.IsNullOrWhiteSpace(envConn)
    ? envConn
    : builder.Configuration.GetConnectionString("DefaultConnection");

// 建議在 Supabase 連線字串含以下參數：
// SSL Mode=Require; Trust Server Certificate=true; Timeout=5; Command Timeout=15; Pooling=true; Maximum Pool Size=50

// 2) 基本記錄
builder.Logging.ClearProviders();
builder.Logging.AddConsole();
builder.Services.AddHttpLogging(o => o.LoggingFields = HttpLoggingFields.All);

// 3) 只保留「一種」DbContext 註冊（建議使用 Pool 版即可）
builder.Services.AddDbContextPool<AppDbContext>(options =>
{
    options.UseNpgsql(connectionString, npgsql =>
    {
        npgsql.CommandTimeout(10); // 跟連線字串一致
        npgsql.EnableRetryOnFailure(
            maxRetryCount: 5,
            maxRetryDelay: TimeSpan.FromSeconds(2),
            errorCodesToAdd: null
        );
    });

#if DEBUG
    options.EnableSensitiveDataLogging();   // 只在開發開
#endif
    options.LogTo(Console.WriteLine, LogLevel.Information);
});

// 4) DI
builder.Services.AddScoped<IAttractionsRepository, AttractionsRepository>();
builder.Services.AddScoped<IAttractionsService, AttractionsService>();
builder.Services.AddScoped<IMemberRepository, MemberRepository>();
builder.Services.AddScoped<IMemberService, MemberService>();
builder.Services.AddScoped<ITestRepository, TestRepository>();
builder.Services.AddScoped<ITestService, TestService>();

builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var app = builder.Build();

// 5) 診斷：印出實際使用的主機與 DB（啟動時）
var csb = new NpgsqlConnectionStringBuilder(connectionString);
Console.WriteLine($"[DB-CONFIG] Host={csb.Host}, Port={csb.Port}, Database={csb.Database}, User={csb.Username}, SSL={csb.SslMode}");

// 6) 中介層順序
app.UseSwagger();
app.UseSwaggerUI();

app.UseRouting();
app.UseHttpLogging();
app.UseAuthorization();

app.MapControllers();

// 7) Render（或本機）埠設定
var port = Environment.GetEnvironmentVariable("PORT") ?? "5000";
app.Urls.Add($"http://0.0.0.0:{port}");
using (var scope = app.Services.CreateScope())
{
    var db = scope.ServiceProvider.GetRequiredService<AppDbContext>();
    try
    {
        await db.Database.ExecuteSqlRawAsync("select 1;");
        Console.WriteLine("[DB] Warm-up OK");
    }
    catch (Exception ex)
    {
        Console.WriteLine($"[DB] Warm-up failed: {ex.Message}");
    }
}

app.Run();
