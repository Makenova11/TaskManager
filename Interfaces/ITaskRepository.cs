namespace TaskManager.Interfaces
{
    using TaskManager.Dto;
    using TaskManager.Models;

    /// <summary>
    /// Репозиторий задач.
    /// </summary>
    public interface ITaskRepository
    {
        /// <summary>
        /// Возвращает список всех задач пользователя.
        /// </summary>
        /// <param name="Id"> Id пользователя. </param>
        /// <param name="cancellationToken"> Структура для совместной отмены операций между потоками. </param>
        /// <returns> TaskDto. </returns>
        public Task<TasksDto> GetAllTaskByUserIdAsync(long Id, CancellationToken cancellationToken);

        /// <summary>
        /// Добавляет задачу.
        /// </summary>
        /// <param name="userId"> Id пользователя. </param>
        /// <param name="dto"> Dto задачи. </param>
        /// <param name="cancellationToken"> Структура для совместной отмены операций между потоками. </param>
        /// <returns> Task. </returns>
        public Task AddTaskAsync(long userId, TaskModelDto dto,
            CancellationToken cancellationToken);
        /// <summary>
        /// Вносит изменения в задачу.
        /// </summary>
        /// <param name="Id"> Id пользователя. </param>
        /// <param name="taskDto"> Изменения в задаче. </param>
        /// <param name="cancellationToken"> Структура для совместной отмены операций между потоками. </param>
        /// <returns> Task. </returns>
        public Task UpdateTaskAsync(long Id, TaskDto dto, CancellationToken cancellationToken);
        /// <summary>
        /// Удаляет задачу.
        /// </summary>
        /// <param name="dto"> Dto задачи. </param>
        /// <param name="cancellationToken"> Структура для совместной отмены операций между потоками. </param>
        /// <returns> Task. </returns>
        public Task DeleteTaskAsync(TaskModel dto, CancellationToken cancellationToken);
        /// <summary>
        /// Получить информацию о задаче по Id задачи.
        /// </summary>
        /// <param name="taskId"> Id задачи. </param>
        /// <param name="cancellationToken"></param>
        /// <returns></returns>
        public Task<TaskModel> GetTaskById(long taskId, CancellationToken cancellationToken);
    }
}
