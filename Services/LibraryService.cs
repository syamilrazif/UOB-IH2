using Library_Management.Data;
using Library_Management.Models;
using Microsoft.EntityFrameworkCore;

namespace Library_Management.Services
{
    public class LibraryService : ILibraryService
    {
        private readonly LibraryDbContext _context;

        public LibraryService(LibraryDbContext context)
        {
            _context = context;
        }

        public async Task<string> BorrowBook(Guid memberId, Guid bookId)
        {
            var book = await _context.Books.FindAsync(bookId);

            if (book == null)
                return "Book not found";

            if (book.AvailableCopies <= 0)
                return "No available copies";

            var record = new BorrowRecord
            {
                BookId = bookId,
                MemberId = memberId,
                BorrowDate = DateTime.UtcNow
            };

            book.AvailableCopies--;

            _context.BorrowRecords.Add(record);
            await _context.SaveChangesAsync();

            return "Book borrowed successfully";
        }

        public async Task<string> ReturnBook(Guid memberId, Guid bookId)
        {
            var record = await _context.BorrowRecords
                .FirstOrDefaultAsync(x =>
                    x.BookId == bookId &&
                    x.MemberId == memberId &&
                    x.ReturnDate == null);

            if (record == null)
                return "No active borrow record found";

            record.ReturnDate = DateTime.UtcNow;

            var book = await _context.Books.FindAsync(bookId);
            book.AvailableCopies++;

            await _context.SaveChangesAsync();

            return "Book returned successfully";
        }
    }
}
