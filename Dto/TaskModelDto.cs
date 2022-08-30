namespace TaskManager.Dto
{
    /// <summary>
    /// Dto для добавления задачи по REST.
    /// </summary>
    public class TaskModelDto
    {
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
