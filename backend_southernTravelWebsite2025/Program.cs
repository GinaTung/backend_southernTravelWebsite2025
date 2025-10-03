using backend_southernTravelWebsite2025.Repositories;
using backend_southernTravelWebsite2025.Services;

var builder = WebApplication.CreateBuilder(args);

// 加入 Controller 與 Swagger
builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

// 依賴注入 (DI)
builder.Services.AddScoped<IMemberRepository, MemberRepository>();
builder.Services.AddScoped<IMemberService, MemberService>();

var app = builder.Build();

// 啟動 Swagger，不管環境
app.UseSwagger();
app.UseSwaggerUI(c =>
{
    c.SwaggerEndpoint("/swagger/v1/swagger.json", "backend_southernTravelWebsite2025 API V1");
    c.RoutePrefix = string.Empty; // 直接在根目錄看到 Swagger
});

// 暫時不要用 HTTPS 轉址，避免本地 HTTP 衝突
// app.UseHttpsRedirection();

app.UseAuthorization();
app.MapControllers();
app.Run();
