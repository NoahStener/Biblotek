using Book_MVC.Models;
using Book_MVC.Services;
using Microsoft.AspNetCore.Mvc;
using MinimalAPI.Models.DTOs;
using Newtonsoft.Json;

namespace Book_MVC.Controllers
{
    public class BookController : Controller
    {
        private readonly IBookService _bookService;
        public BookController(IBookService bookService)
        {
            _bookService = bookService;
        }

        public async Task <IActionResult> BookIndex()
        {
            List<BookDTO> bookList = new List<BookDTO>();
            
            var response = await _bookService.GetAllBooks<ResponseDTO>();

            if(response != null && response.IsSuccess)
            {
                bookList = JsonConvert.DeserializeObject<List<BookDTO>>(Convert.ToString(response.Result));
            }
            if(bookList.Count == 0)
            {
                Console.WriteLine("Error getting data from API");
            }
            return View(bookList);
        }

        public async Task <IActionResult> BookDetails(int id)
        {
            var response = await _bookService.GetBookById<ResponseDTO>(id);

            if(response != null && response.IsSuccess)
            {
                BookDTO model = JsonConvert.DeserializeObject<BookDTO>(Convert.ToString(response.Result));

                return View(model);
            }
            return View();
        }

        public async Task<IActionResult> BookCreate()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> BookCreate(BookDTO model)
        {
            if (ModelState.IsValid)
            {
                var response = await _bookService.CreateBookAsync<ResponseDTO>(model);
                if(response != null && response.IsSuccess)
                {
                    return RedirectToAction(nameof(BookIndex));
                }
            }
            return View(model);
        }

        public async Task<IActionResult> UpdateBook(int bookId)
        {
            var response = await _bookService.GetBookById<ResponseDTO>(bookId);

            if(response != null && response.IsSuccess)
            {
                BookDTO model = JsonConvert.DeserializeObject<BookDTO>(Convert.ToString(response.Result));
                return View(model);
            }
            return NotFound();
        }

        [HttpPost]
        public async Task<IActionResult> UpdateBook(BookDTO model)
        {
            if(ModelState.IsValid)
            {
                var response = await _bookService.UpdateBookAsync<ResponseDTO>(model);

                if(response != null && response.IsSuccess)
                {
                    return RedirectToAction(nameof(BookIndex));
                }
            }
            return View(model);
        }

        public async Task <IActionResult> DeleteBook(int bookId)
        {
            var response = await _bookService.GetBookById<ResponseDTO>(bookId);

            if(response != null && response.IsSuccess)
            {
                BookDeleteDTO model = JsonConvert.DeserializeObject<BookDeleteDTO>(Convert.ToString(response.Result));

                return View(model);
            }
            return NotFound();
        }

        [HttpPost]
        public async Task<IActionResult> DeleteBook(BookDeleteDTO model)
        {
            if(ModelState.IsValid)
            {
                var response = await _bookService.DeleteBookAsync<ResponseDTO>(model.BookID);

                if(response != null && response.IsSuccess)
                {
                    return RedirectToAction(nameof(BookIndex));
                }
            }
            return RedirectToAction(nameof(BookIndex));
        }

        public async Task<IActionResult>SearchBook(string title)
        {
            if(string.IsNullOrEmpty(title))
            {
                return View();
            }

            var response = await _bookService.SearchBookAsync<ResponseDTO>(title);

            if(response != null && response.IsSuccess)
            {
                BookDTO model = JsonConvert.DeserializeObject<BookDTO>(Convert.ToString(response.Result));
                return View(model);
            }
            ViewBag.Message = "No book was found with given title";
            return View();
        }
    }
}
