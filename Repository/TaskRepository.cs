namespace TaskManager.Repository
{
    using Microsoft.EntityFrameworkCore;
    using System.Globalization;
    using TaskManager.Dto;
    using TaskManager.Extensions;
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
                Date = dto.Date.ConvertToDateTime(),
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
        public async Task<TasksDto> GetAllTaskByUserIdAsync(long Id, 
            CancellationToken cancellationToken)
        {
            var tasks = await _context.Tasks.Where(x => x.UserId == Id).AsNoTracking().ToListAsync(cancellationToken);
            var textDtoList = new List<TextDto>();
            foreach(var task in tasks)
            {
                textDtoList.Add(new TextDto
                {
                    Text = task.Text,
                    Date = task.Date.ToString("dd.MM.yyyy"),
                    TaskId = task.Id,
                    IsCompleted = task.IsCompleted
                });
            }

            return new TasksDto { UserId = Id, TextDtos = textDtoList };
        }

        //<inheritdoc/>
        public async Task<TaskModel> GetTaskById(long taskId, CancellationToken cancellationToken)
        {
            return await _context.Tasks.SingleOrDefaultAsync(x => x.Id == taskId,
                cancellationToken: cancellationToken);
        }

        //<inheritdoc/>
        public async Task UpdateTaskAsync(long Id, TaskDto dto, CancellationToken cancellationToken)
        {
            var taskModel = _context.Tasks.SingleOrDefaultAsync(x => x.Id == Id);
            var task = new TaskModel
            {
                UserId = dto.UserId,
                Date = dto.Date.ConvertToDateTime(),
                Text = dto.Text,
                IsCompleted = dto.IsCompleted
            };
            _context.Tasks.Update(task);
            await _context.SaveChangesAsync(cancellationToken);
        }
    }
}
