namespace TaskManager.Controllers
{
    using Microsoft.AspNetCore.Http;
    using Microsoft.AspNetCore.Mvc;
    using TaskManager.Interfaces;

    /// <summary>
    /// Контроллер действий с пользователем.
    /// </summary>
    [Route("user")]
    [ApiController]
    public class UserController : ControllerBase
    {
        /// <summary>
        /// Репозиторий действий с пользователем.
        /// </summary>
        private readonly IUserRepository _userRepository;

        public UserController(IUserRepository userRepository)
        {
            _userRepository = userRepository;
        }


    }
}
