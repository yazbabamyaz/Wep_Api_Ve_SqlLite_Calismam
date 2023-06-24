using Apis.Models;

namespace Apis.Repositories
{
    public interface IBookRepository
    {        
        //Metotların asenkron olacağına ve Task tipinde dönüş yaptığına dikkat et.
        Task<IEnumerable<Book>> Get();
        Task<Book> GetById(int id);
        Task<Book> Create(Book book);
        Task Update(Book book);
        Task Delete(int id);

    }
}
