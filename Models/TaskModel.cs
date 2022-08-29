namespace TaskManager.Models
{
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    /// <summary>
    /// Задача.
    /// </summary>
    [Table("Task")]
    public class TaskModel
    {
        /// <summary>
        /// Id задачи.
        /// </summary>
        [Key]
        [Column(Order = 0)]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public long Id { get; set; }

        /// <summary>
        /// Id пользователя.
        /// </summary>
        [Required]
        [Column(Order = 1)]
        public long UserId { get; set; }
        /// <summary>
        /// Задача.
        /// </summary>
        [Required]
        [Column(Order = 2)]
        public string Text { get; set; } = null!;
        /// <summary>
        /// Дата создания.
        /// </summary>
        [Required]
        [Column(TypeName = "Date", Order = 3)]
        public DateTime Date { get; set; }
        /// <summary>
        /// Выполнена ли задача (перечёркнута).
        /// </summary>
        [Column(Order = 4)]
        public bool IsCompleted { get; set; } = false;

        public User Users { get; set; }


    }
}
