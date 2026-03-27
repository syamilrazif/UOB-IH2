namespace Library_Management.Models
{
    public class Book : BaseEntity
    {
        public string Title { get; set; }
        public string Author { get; set; }
        public string ISBN { get; set; }
        public int TotalCopies { get; set; }
        public int AvailableCopies { get; set; }

        public bool IsAvailable()
        {
            return AvailableCopies > 0;
        }
    }
}
