namespace TaskManager.Models
{
    public partial class Task
    {
        public long TaskCode { get; set; }
        public string Task1 { get; set; } = null!;
        public DateOnly Date { get; set; }
        public bool IsDeleted { get; set; }
        public long Id { get; set; }

        public virtual User IdNavigation { get; set; } = null!;
    }
}
