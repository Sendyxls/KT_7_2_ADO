public enum TaskStatus
{
    Новая,
    В_Работе,
    Выполнена
}

public class TaskItem
{
    public int Id { get; set; }
    public string Title { get; set; }
    public string Description { get; set; }
    public TaskStatus Status { get; set; } = TaskStatus.Новая;
    public DateTime CreatedDate { get; set; } = DateTime.Now;
}