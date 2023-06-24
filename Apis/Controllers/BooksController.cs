using Apis.Models;
using Apis.Repositories;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Apis.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class BooksController : ControllerBase
    {
        private readonly IBookRepository _bookRepository;
        public BooksController(IBookRepository bookRepository)
        {
            _bookRepository = bookRepository;
        }

        //public string Demo()
        //{
        //    return "Hello...";// specific Type:int,boolean,string,class vs.
        //}
        //public IActionResult Demo1()
        //{
        //    return Ok("Hello...");//Ok(), NotFound(), BadRequest(),NoContent(); gibi
            
        //}


        [HttpGet]//api/Books
        public async Task<IEnumerable<Book>> GetBooks() 
        {
            return await _bookRepository.Get();            
        }
        //[Route("Getir/{id}")]//api/Books/Getir/4 gibi
        [HttpGet("{id}")]//api/Books/4 gibi
        //[HttpGet("{id}", Name = "Listele")]//api/Books/4 gibi
        public async Task<ActionResult<Book>> GetBooks(int id) 
        {
            return await _bookRepository.GetById(id); 
        }
        [HttpPost]
        public async Task<ActionResult<Book>> PostBook([FromBody] Book book)
        {
            var newBook= await _bookRepository.Create(book);
            return CreatedAtAction(nameof(GetBooks), new { id=newBook.Id} ,newBook);//201 code
            
        }

        [HttpPut]
        public async Task<ActionResult> PutBooks(int id,[FromBody] Book book) 
        {
            if (id!=book.Id)
            {
                return BadRequest();
            }
            await _bookRepository.Update(book);
            return NoContent();
        }
        [HttpDelete("{id}")]
        public async Task<ActionResult> DeleteBooks(int id)
        {
            var bookToDelete = await _bookRepository.GetById(id);
            if (bookToDelete == null)
                return NotFound("Kayıt bulunamadı");            
           await _bookRepository.Delete(bookToDelete.Id);
            return NoContent();
        }
    }
}
