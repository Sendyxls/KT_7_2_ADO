// Controllers/TasksController.cs
using Microsoft.AspNetCore.Mvc;

[ApiController]
[Route("api/[controller]")]
public class TasksController : ControllerBase
{
    private readonly ITaskRepository _repository;

    public TasksController(ITaskRepository repository)
    {
        _repository = repository;
    }

    // GET: api/tasks
    [HttpGet]
    public ActionResult<IEnumerable<TaskItem>> GetTasks([FromQuery] TaskStatus? status)
    {
        return Ok(_repository.GetAllTasks(status));
    }

    // GET: api/tasks/5
    [HttpGet("{id}")]
    public ActionResult<TaskItem> GetTask(int id)
    {
        var task = _repository.GetTaskById(id);
        return task == null ? NotFound() : Ok(task);
    }

    // POST: api/tasks
    [HttpPost]
    public ActionResult<TaskItem> CreateTask([FromBody] TaskItem task)
    {
        if (string.IsNullOrWhiteSpace(task.Title))
        {
            return BadRequest("Название задачи обязательно");
        }

        var createdTask = _repository.AddTask(task);
        return CreatedAtAction(nameof(GetTask), new { id = createdTask.Id }, createdTask);
    }

    // PUT: api/tasks/5
    [HttpPut("{id}")]
    public IActionResult UpdateTask(int id, [FromBody] TaskItem task)
    {
        if (id != task.Id)
        {
            return BadRequest();
        }

        var existingTask = _repository.GetTaskById(id);
        if (existingTask == null)
        {
            return NotFound();
        }

        _repository.UpdateTask(task);
        return NoContent();
    }

    // DELETE: api/tasks/5
    [HttpDelete("{id}")]
    public IActionResult DeleteTask(int id)
    {
        var task = _repository.GetTaskById(id);
        if (task == null)
        {
            return NotFound();
        }

        _repository.DeleteTask(id);
        return NoContent();
    }
}