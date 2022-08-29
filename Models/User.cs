namespace TaskManager.Models
{
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    /// <summary>
    /// Пользователь.
    /// </summary>
    public class User
    {
        /// <summary>
        /// Id пользователя.
        /// </summary> 
        [Key]
        [Column(Order = 0)]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public long Id { get; set; }
        /// <summary>
        /// Фамилия.
        /// </summary>       
        [MaxLength(50)]
        [Column(Order = 2)]
        public string SecondName { get; set; } = null!;
        /// <summary>
        /// Имя.
        /// </summary>
        [Required]
        [MaxLength(50)]
        [Column(Order = 1)]
        public string FirstName { get; set; } = null!;
        /// <summary>
        /// Email.
        /// </summary>
        [Required]
        [MaxLength(50)]
        [Column(Order = 3)]
        public string Email { get; set; } = null!;
        /// <summary>
        /// Пароль.
        /// </summary>
        [Required]
        public string Password { get; set; } = null!;
        /// <summary>
        /// Соль.
        /// </summary>
        public long Salt { get; set; }
        /// <summary>
        /// Удалён ли пользователь.
        /// </summary>
        [Column(Order = 4)]
        public bool IsDeleted { get; set; } = false;

        public virtual List<TaskModel> TaskModels { get; set; } = new List<TaskModel>();
    }
}
