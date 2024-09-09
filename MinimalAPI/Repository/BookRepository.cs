using Microsoft.EntityFrameworkCore;
using MinimalAPI.Data;
using MinimalAPI.Models;

namespace MinimalAPI.Repository
{
    public class BookRepository : IBookRepository
    {
        private readonly AppDbContext _dB;
        public BookRepository(AppDbContext dB)
        {
            _dB = dB;
        }
        public async Task CreateAsync(Book book)
        {
            _dB.Books.AddAsync(book);
        }

        public async Task<IEnumerable<Book>> GetAllAsync()
        {
            return await _dB.Books.ToListAsync();
        }

        public async Task<Book> GetAsync(string bookTitle)
        {
            return await _dB.Books.FirstOrDefaultAsync(b => b.Title == bookTitle.ToLower());
        }

        public async Task<Book> GetByIdAsync(int id)
        {
            return await _dB.Books.FirstOrDefaultAsync(b => b.BookID == id);
        }

        public async Task RemoveAsync(Book book)
        {
            _dB.Books.Remove(book);
        }

        public async Task SaveAsync()
        {
            await _dB.SaveChangesAsync();
        }

        public async Task UpdateAsync(Book book)
        {
            _dB.Books.Update(book);
        }
    }
}
