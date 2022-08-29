namespace TaskManager.Dto
{
    /// <summary>
    /// Task dto. 
    /// </summary>
    public class TaskDto
    {
        /// <summary>
        /// Id пользователя.
        /// </summary>
        public long UserId { get; set; }
        /// <summary>
        /// Дата создания задач.
        /// </summary>
        public string Date { get; set; }
        /// <summary>
        /// Список задач.
        /// </summary>
        public List<TextDto>? TextDtos { get; set; }
    }
}
