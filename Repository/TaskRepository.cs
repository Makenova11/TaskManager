namespace TaskManager.Repository
{
    using Microsoft.EntityFrameworkCore;
    using TaskManager.Dto;
    using TaskManager.Interfaces;
    using TaskManager.Models;

    public class TaskRepository : ITaskRepository
    {
        /// <summary>
        /// Обращение к контексту.
        /// </summary>
        private readonly TaskManagerContext _context;

        public TaskRepository(TaskManagerContext context)
        {
            _context = context;
        }

        //<inheritdoc/>
        public async Task AddTaskAsync(long userId, TaskModelDto dto,
            CancellationToken cancellationToken)
        {
            var task = new TaskModel {
                UserId = userId,
                Date = dto.Date,
                Text = dto.Text,
                IsCompleted = dto.IsCompleted
            };
            _context.Tasks.Add(task);
            await _context.SaveChangesAsync(cancellationToken);
        }
        //<inheritdoc/>
        public async Task DeleteTaskAsync(TaskModel dto, CancellationToken cancellationToken)
        {
            _context.Tasks.Remove(dto);
            await _context.SaveChangesAsync(cancellationToken);
        }

        //<inheritdoc/>
        public async Task<IEnumerable<TaskModel>> GetAllTaskByUserIdAsync(long Id, 
            CancellationToken cancellationToken)
        {
            return await _context.Tasks.Where(x => x.UserId == Id).AsNoTracking().ToListAsync(cancellationToken);
        }

        //<inheritdoc/>
        public async Task<TaskDto> Test()
        {
            return new TaskDto
            {
                UserId = 1,
                Date = new DateTime(2022, 8, 28),
                TextDtos = new List<TextDto> { new TextDto { TaskId = 1, Text = "Подраться с братом", IsCompleted = false},
                new TextDto{ TaskId = 2,Text = "Вкусно покушать", IsCompleted = true },
                new TextDto{ TaskId = 3,Text = "Забрать печенье у брата", IsCompleted = true },
                new TextDto{ TaskId = 4,Text = "Сказать маме, что брат первый начал", IsCompleted = false}}
            };
        }
        //<inheritdoc/>
        public async Task UpdateTaskAsync(long Id, TaskModelDto dto, CancellationToken cancellationToken)
        {
            var task = new TaskModel
            {
                UserId = Id,
                Date = dto.Date,
                Text = dto.Text,
                IsCompleted = dto.IsCompleted
            };
            _context.Tasks.Update(task);
            await _context.SaveChangesAsync(cancellationToken);
        }
    }
}
