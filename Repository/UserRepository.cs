namespace TaskManager.Repository
{
    using Microsoft.EntityFrameworkCore;
    using System.Threading;
    using TaskManager.Interfaces;
    using TaskManager.Models;

    /// <summary>
    /// Репозиторий действий пользователя.
    /// </summary>
    public class UserRepository : IUserRepository
    {
        /// <summary>
        /// Контекст данных.
        /// </summary>
        private readonly TaskManagerContext _context;

        public UserRepository(TaskManagerContext context)
        {
            _context = context;
        }

        //<inheritdoc/>
        public async Task AddUserAsync(User user, CancellationToken cancellationToken)
        {
             _context.Users.Add(user);
            await _context.SaveChangesAsync(cancellationToken);
        }

        //<inheritdoc/>
        public Task DeleteSoftUserAsync(long UserId, CancellationToken cancellationToken)
        {
            throw new NotImplementedException();
        }

        //<inheritdoc/>
        public Task DeleteUserAsync(long UserId, CancellationToken cancellationToken)
        {
            throw new NotImplementedException();
        }

        //<inheritdoc/>
        public async Task<User> FindByIdAsync(long UserId, CancellationToken cancellationToken)
        {
            return await _context.Users.SingleOrDefaultAsync(opt => opt.Id == UserId, cancellationToken);
        }

        //<inheritdoc/>
        public Task UpdateUserAsync(long UserId, User User, CancellationToken cancellationToken)
        {
            throw new NotImplementedException();
        }
    }
}