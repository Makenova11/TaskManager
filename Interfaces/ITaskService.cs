namespace TaskManager.Interfaces
{
    /// <summary>
    /// Сервис по работе с задачами.
    /// </summary>
    public interface ITaskService
    {
        public Task<string> Get(string id);
    }
}
