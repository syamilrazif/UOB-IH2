namespace Library_Management.Models
{
    public class BorrowRecord : BaseEntity
    {
        public Guid BookId { get; set; }
        public Book Book { get; set; }

        public Guid MemberId { get; set; }
        public Member Member { get; set; }

        public DateTime BorrowDate { get; set; }
        public DateTime? ReturnDate { get; set; }

        public bool IsReturned => ReturnDate.HasValue;
    }
}
