namespace TaskManager.Interfaces
{
    using TaskManager.Dto;
    /// <summary>
    /// Репозиторий задач.
    /// </summary>
    public interface ITaskRepository
    {
        /// <summary>
        /// тестовый запрос для фронта.
        /// </summary>
        /// <returns></returns>
        public Task<TaskDto> Test();
        /// <summary>
        /// Получить задачи на день.
        /// </summary>
        /// <param name="Id"> Id пользователя. </param>
        /// <param name="date"> Дата. </param>
        /// <param name="cancellationToken"> Структура для совместной отмены операций между потоками. </param>
        /// <returns> List<TaskModel> </returns>
        public Task<TaskDto> GetTasksByUserIdAsync(long Id, DateTime date, 
            CancellationToken cancellationToken);
        /// <summary>
        /// Возвращает список всех задач пользователя.
        /// </summary>
        /// <param name="Id"> Id пользователя. </param>
        /// <param name="cancellationToken"> Структура для совместной отмены операций между потоками. </param>
        /// <returns> TaskDto. </returns>
        public Task<TaskDto> GetAllTaskByUserIdAsync(long Id, CancellationToken cancellationToken);
        /// <summary>
        /// Возвращает задачи пользователя за 1 месяц.
        /// </summary>
        /// <param name="Id"> Id пользователя. </param>
        /// <param name="date"> Месяц и год. </param>
        /// <param name="cancellationToken"> Структура для совместной отмены операций между потоками. </param>
        /// <returns> TaskDto. </returns>
        public Task<TaskDto> GetAllTasksByMonthAsync(long Id, DateTime date,
            CancellationToken cancellationToken);
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
        public Task UpdateTaskAsync(long Id, TaskDto taskDto, 
            CancellationToken cancellationToken);
        /// <summary>
        /// Удаляет задачу.
        /// </summary>
        /// <param name="TaskId"> Id задачи. </param>
        /// <param name="cancellationToken"> Структура для совместной отмены операций между потоками. </param>
        /// <returns> Task. </returns>
        public Task DeleteTaskAsync(long TaskId, CancellationToken cancellationToken);
    }
}
