namespace TaskManager.Dto
{
    /// <summary>
    /// Dto текста в задаче.
    /// </summary>
    public class TextDto
    {
        /// <summary>
        /// Id задачи.
        /// </summary>
        public long TaskId {get;set;}

        /// <summary>
        /// Дата создания задач.
        /// </summary>
        public string Date { get; set; }
        /// <summary>
        /// Текст.
        /// </summary>
        public string Text { get; set; }
        /// <summary>
        /// Выполнена ли задача.
        /// </summary>
        public bool IsCompleted { get; set; }
    }
}
