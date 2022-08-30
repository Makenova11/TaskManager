namespace TaskManager.Dto
{
    /// <summary>
    /// Dto для листа задач.
    /// </summary>
    public class TasksDto
    {
        /// <summary>
        /// Id пользователя.
        /// </summary>
        public long UserId { get; set; }

        /// <summary>
        /// Список задач.
        /// </summary>
        public List<TextDto>? TextDtos { get; set; }
    }
}
