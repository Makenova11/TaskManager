namespace TaskManager.Controllers
{
    using Microsoft.AspNetCore.Mvc;
    using TaskManager.Dto;
    using TaskManager.Interfaces;
    using TaskManager.Models;

    /// <summary>
    /// Контроллер действий с задачами.
    /// </summary>
    [Route("tasks")]
    [ApiController]
    public class TaskController : ControllerBase
    {
        /// <summary>
        /// Репозиторий действий с задачами.
        /// </summary>
        private readonly ITaskRepository _repository;

        /// <summary>
        /// Репозиторий действий с пользователем.
        /// </summary>
        private readonly IUserRepository _userRepository;

        public TaskController(ITaskRepository repository, IUserRepository userRepository)
        {
            _userRepository = userRepository;
            _repository = repository;
        }

        /// <summary>
        /// Получить задачи по Id пользователя.
        /// </summary>
        /// <param name="userId"> Id пользователя. </param>
        /// <param name="cancellationToken"> Структура для совместной отмены операций между потоками. </param>
        /// <returns> TasksDto. </returns>
        [HttpGet("/{userId}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<ActionResult<TasksDto>> GetTasks(long userId, CancellationToken cancellationToken)
        {
            var user = await _userRepository.FindByIdAsync(userId, cancellationToken);
            if (user == null)
            {
                return NotFound($"Пользователь с Id {userId} не найден.");
            }
            
            return await _repository.GetAllTaskByUserIdAsync(userId, cancellationToken);
        }

        /// <summary>
        /// Изменяет задачу.
        /// </summary>
        /// <param name="id"></param>
        /// <param name="taskModel"></param>
        /// <returns></returns>
        [HttpPatch("/{id}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<IActionResult> UpdateTaskModel(long taskId, TaskDto dto,
            CancellationToken cancellationToken)
        {
            var task = await _repository.GetTaskById(taskId, cancellationToken);
            if (task == null)
            {
                return NoContent();
            }
            await _repository.UpdateTaskAsync(taskId, dto, cancellationToken);
            return Ok();
        }

        /// <summary>
        /// Добавить задачу.
        /// </summary>
        /// <param name="UserId"> Id пользователя. </param>
        /// <param name="Dto"> Dto добавляемой задачи. </param>
        /// <param name="CancellationToken"> Структура для совместной отмены операций между потоками. </param>
        /// <returns> ActionResult. </returns>
        [HttpPost]
        [ProducesResponseType(StatusCodes.Status201Created)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<ActionResult> AddTaskAsync(long UserId, TaskModelDto Dto,
            CancellationToken CancellationToken)
        {
            var user = await _userRepository.FindByIdAsync(UserId, CancellationToken);
            if ( user == null)
            {
                return NotFound($"Пользователь с Id {UserId} не найден.");
            }
            await _repository.AddTaskAsync(UserId,Dto, CancellationToken);

            return CreatedAtAction("GetTaskModel", new { id = UserId }, Dto);
        }

        /// <summary>
        /// Удаление задачи по её Id.
        /// </summary>
        /// <param name="taskId"> Id задачи. </param>
        /// <returns></returns>
        [HttpDelete("/{id}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        public async Task<IActionResult> DeleteTaskModel(long taskId, CancellationToken cancellationToken)
        {
            var task = await _repository.GetTaskById(taskId, cancellationToken);
            if (task == null)
            {
                return NoContent();
            }
            await _repository.DeleteTaskAsync(task, cancellationToken);
            return Ok();
        }

    }
}
