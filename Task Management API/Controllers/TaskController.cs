using Microsoft.AspNetCore.Mvc;
using UseCases;

namespace Task_Management_API.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class TaskController : Controller
    {
        private readonly ILogger<TaskController> _logger;
        private readonly IAddTask _addTask;
        private readonly IDeleteTask _deleteTask;
        private readonly IRetrieveTask _retrieveTask;
        private readonly IUpdateTask _updateTask;

        public TaskController(ILogger<TaskController> logger, IUpdateTask updateTask, IDeleteTask deleteTask, IRetrieveTask retrieveTask, IAddTask addTask)
        {
            _logger = logger;
            _updateTask = updateTask;
            _deleteTask = deleteTask;
            _retrieveTask = retrieveTask;
            _addTask = addTask;

        }

        [HttpPost]
        public async Task<IActionResult> Add([FromBody] TaskModel model)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            OperationResult result = await _addTask.AddTaskAsync(model);
            return result.Status ==OperationStatus.Success?CreatedAtAction(nameof(GetById), new { Id = result.Data }, model):HandleErrorResult(result);
        }

        [HttpGet("{Id}")]
        public async Task<IActionResult> GetById(int Id)
        {
            OperationResult result = await _retrieveTask.GetTaskByIDAsync(Id);
            return result.Status == OperationStatus.Success ? Ok(result.Data): HandleErrorResult(result);

        }
        [HttpGet]
        public async Task<IActionResult> GetList()
        {
            OperationResult result = await _retrieveTask.GetTasksAsync();
            return result.Status == OperationStatus.Success ? Ok(result.Data) : HandleErrorResult(result);

        }
        [HttpPut]
        public async Task<IActionResult> Update([FromBody] UpdateTaskModel model)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            OperationResult result = await _updateTask.UpdateAsync(model);
            return result.Status == OperationStatus.Success ? Ok() : HandleErrorResult(result);
        }
        [HttpDelete]
        public async Task<IActionResult> Delete(int Id)
        {
            OperationResult result = await _deleteTask.DeleteAsync(Id);
            return result.Status == OperationStatus.Success ? Ok() : HandleErrorResult(result);
        }

        private IActionResult HandleErrorResult(OperationResult result)
        {
            switch (result.Status)
            {

                case OperationStatus.NotFound:
                    return NotFound();
                case OperationStatus.Failure:
                    return StatusCode(500, new { message = result.Message });
                case OperationStatus.Exception:
                    _logger.LogError(result.Message);
                    return StatusCode(500);
                default:
                    return NoContent();
            }
        }
    }
}
