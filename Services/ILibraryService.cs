namespace Library_Management.Services
{
    public interface ILibraryService
    {
        Task<string> BorrowBook(Guid memberId, Guid bookId);
        Task<string> ReturnBook(Guid memberId, Guid bookId);
    }
}
