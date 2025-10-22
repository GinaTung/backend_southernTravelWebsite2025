using backend_southernTravelWebsite2025.Repositories;
using backend_southernTravelWebsite2025.Services;
using backend_southernTravelWebsite2025.Data;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

// 嘗試從環境變數讀取 Supabase 連線字串（Render 用）
var envConnection = Environment.GetEnvironmentVariable("SUPABASE_DB_CONNECTION");

// 若無環境變數則回到 appsettings.json 的預設連線字串（本地開發用）
var connectionString = !string.IsNullOrEmpty(envConnection)
    ? envConnection
    : builder.Configuration.GetConnectionString("DefaultConnection");

// 註冊資料庫上下文
//builder.Services.AddDbContext<AppDbContext>(options =>
//    options.UseNpgsql(connectionString));

// 註冊資料庫上下文（使用 DbContextPool 節省連線）
builder.Services.AddDbContextPool<AppDbContext>(options =>
    options.UseNpgsql(connectionString, npgsqlOptions =>
    {
        npgsqlOptions.CommandTimeout(120); // 120秒
        npgsqlOptions.EnableRetryOnFailure(3); // 自動重試3次
    })
);


// 加入 Controller 與 Swagger
builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

// 依賴注入 (DI)
builder.Services.AddScoped<IMemberRepository, MemberRepository>();
builder.Services.AddScoped<IMemberService, MemberService>();

var app = builder.Build();

// 啟動 Swagger
app.UseSwagger();
app.UseSwaggerUI(c =>
{
    c.SwaggerEndpoint("/swagger/v1/swagger.json", "backend_southernTravelWebsite2025 API V1");
});

// 暫時不強制 HTTPS（Render 自動處理 HTTPS）
app.UseAuthorization();
app.MapControllers();

// Render 會提供 PORT 環境變數，讓應用在正確 port 運作
var port = Environment.GetEnvironmentVariable("PORT") ?? "5000";
app.Urls.Add($"http://0.0.0.0:{port}");

app.Run();
