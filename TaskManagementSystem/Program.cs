var builder = WebApplication.CreateBuilder(args);

// Добавляем сервисы в контейнер
builder.Services.AddSingleton<ITaskRepository, TaskRepository>();
builder.Services.AddControllers();

var app = builder.Build();

// Настраиваем конвейер HTTP-запросов
app.UseHttpsRedirection();
app.UseAuthorization();
app.MapControllers();

app.Run();