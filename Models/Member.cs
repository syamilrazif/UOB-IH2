namespace Library_Management.Models
{
    public class Member : BaseEntity
    {
        public string Name { get; set; }
        public string Email { get; set; }

        public ICollection<BorrowRecord> BorrowRecords { get; set; } = new List<BorrowRecord>();
    }
}
