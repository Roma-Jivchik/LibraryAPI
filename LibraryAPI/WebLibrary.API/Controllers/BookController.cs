using Microsoft.AspNetCore.Mvc;
using WebLibrary.Domain.Entities;
using WebLibrary.Domain.Requests.Book;
using Microsoft.AspNetCore.Authorization;
using WebLibrary.BLL.Services.BookServices;
using WebLibrary.Domain.Requests.BookRequests;

namespace WebLibrary.API.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class BookController : ControllerBase
    {
        private readonly IBookService _bookService;

        public BookController(IBookService bookService)
        {
            _bookService = bookService;
        }

        [AllowAnonymous]
        [HttpGet]
        public async Task<ActionResult<List<Book>>> GetAllBooksAsync()
        {
            var books = await _bookService.GetAllAsync();

            return Ok(books);
        }

        [AllowAnonymous]
        [HttpGet("{id}")]
        public async Task<ActionResult<Book>> GetBookByIdAsync([FromRoute] Guid id)
        {
            var book = await _bookService.GetBookAsync(id);

            if(book is null)
            {
                return NoContent();
            }

            return Ok(book);
        }

        [AllowAnonymous]
        [HttpGet("byISBN/{isbn}")]
        public async Task<ActionResult<Book?>> GetBookByIsbnAsync([FromRoute] string isbn)
        {
            var book = await _bookService.GetBookByIsbnAsync(isbn);

            if(book is null)
            {
                return NoContent();
            }

            return Ok(book);
        }

        [Authorize]
        [HttpPost]
        public async Task<ActionResult> AddBookAsync([FromBody] CreateBookRequest request)
        {
            var createdBook = await _bookService.CreateAsync(request);

            return Ok(createdBook);
        }

        [Authorize]
        [HttpPut]
        public async Task<ActionResult> UpdateBookAsync([FromBody] UpdateBookRequest request)
        {
            var isUpdate = await _bookService.UpdateAsync(request);

            if (isUpdate is false)
            {
                return BadRequest();
            }

            return Ok(isUpdate);
        }

        [Authorize]
        [HttpDelete("{id}")]
        public async Task<ActionResult> DeleteBookAsync([FromRoute] Guid id)
        {
            var isDelete = await _bookService.DeleteAsync(id);

            if (isDelete is false)
            {
                return BadRequest();
            }

            return Ok(isDelete);
        }
    }
}
