public interface ITaskRepository
{
    IEnumerable<TaskItem> GetAllTasks(TaskStatus? statusFilter);
    TaskItem GetTaskById(int id);
    TaskItem AddTask(TaskItem task);
    void UpdateTask(TaskItem task);
    void DeleteTask(int id);
}

// Services/TaskRepository.cs
public class TaskRepository : ITaskRepository
{
    private readonly List<TaskItem> _tasks = new();
    private int _nextId = 1;

    public IEnumerable<TaskItem> GetAllTasks(TaskStatus? statusFilter)
    {
        return statusFilter == null
            ? _tasks
            : _tasks.Where(t => t.Status == statusFilter);
    }

    public TaskItem GetTaskById(int id) => _tasks.FirstOrDefault(t => t.Id == id);

    public TaskItem AddTask(TaskItem task)
    {
        task.Id = _nextId++;
        _tasks.Add(task);
        return task;
    }

    public void UpdateTask(TaskItem task)
    {
        var index = _tasks.FindIndex(t => t.Id == task.Id);
        if (index != -1)
        {
            _tasks[index] = task;
        }
    }

    public void DeleteTask(int id)
    {
        var task = GetTaskById(id);
        if (task != null)
        {
            _tasks.Remove(task);
        }
    }
}