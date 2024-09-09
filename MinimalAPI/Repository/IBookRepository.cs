using MinimalAPI.Models;

namespace MinimalAPI.Repository
{
    public interface IBookRepository
    {
        Task<IEnumerable<Book>> GetAllAsync();
        Task<Book> GetByIdAsync(int id);
        Task<Book> GetAsync(string bookTitle);
        Task CreateAsync(Book book);
        Task UpdateAsync(Book book);
        Task RemoveAsync(Book book);
        Task SaveAsync();
    }
}
