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
        /// Задача.
        /// </summary>
        public string Text { get; set; } = null!;
        /// <summary>
        /// Дата создания.
        /// </summary>
        public string Date { get; set; }
        /// <summary>
        /// Выполнена ли задача (перечёркнута).
        /// </summary>
        public bool IsCompleted { get; set; } = false;
    }
}
