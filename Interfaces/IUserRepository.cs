namespace TaskManager.Interfaces
{
    using TaskManager.Models;
    /// <summary>
    /// Репозиторий пользователя.
    /// </summary>
    public interface IUserRepository
    {
        /// <summary>
        /// Найти пользователя по Id.
        /// </summary>
        /// <param name="UserId"> Id пользователя. </param>
        /// <returns> User. </returns>
        public Task<User> FindByIdAsync(long UserId, CancellationToken cancellationToken);

        /// <summary>
        /// Добавить пользователя
        /// </summary>
        /// <param name="user"> Данные для добавления. </param>
        /// <param name="cancellationToken"> Структура для совместной отмены операций между потоками. </param>
        /// <returns> Task. </returns>
        public Task AddUserAsync(User user, CancellationToken cancellationToken);

        /// <summary>
        /// Реадктировать данные пользователя.
        /// </summary>
        /// <param name="UserId"> Id пользователя. </param>
        /// <param name="User"> Данные для изменения. </param>
        /// <param name="cancellationToken"> Структура для совместной отмены операций между потоками. </param>
        /// <returns> Task. </returns>
        public Task UpdateUserAsync(long UserId, User User, CancellationToken cancellationToken);

        /// <summary>
        /// МЯгкое удаление пользователя.
        /// </summary>
        /// <param name="UserId"> Id пользователя. </param>
        /// <param name="cancellationToken"> Структура для совместной отмены операций между потоками. </param>
        /// <returns> Task. </returns>
        public Task DeleteSoftUserAsync(long UserId, CancellationToken cancellationToken);

        /// <summary>
        /// Удалить пользователя.
        /// </summary>
        /// <param name="UserId"> Id пользователя. </param>
        /// <param name="cancellationToken"> Структура для совместной отмены операций между потоками. </param>
        /// <returns> Task. </returns>
        public Task DeleteUserAsync(long UserId, CancellationToken cancellationToken);
    }
}
