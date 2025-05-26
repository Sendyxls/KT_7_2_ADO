var builder = WebApplication.CreateBuilder(args);

// ��������� ������� � ���������
builder.Services.AddSingleton<ITaskRepository, TaskRepository>();
builder.Services.AddControllers();

var app = builder.Build();

// ����������� �������� HTTP-��������
app.UseHttpsRedirection();
app.UseAuthorization();
app.MapControllers();

app.Run();