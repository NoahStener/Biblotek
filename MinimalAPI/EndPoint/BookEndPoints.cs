using AutoMapper;
using MinimalAPI.Models;
using MinimalAPI.Models.DTOs;
using MinimalAPI.Repository;

namespace MinimalAPI.EndPoint
{
    public static class BookEndPoints
    {
        public static void ConfigurationBookEndPoints(this WebApplication app)
        {
            app.MapGet("/api/books", GetAllBooks).WithName("GetBooks").Produces<APIResponse>();

            app.MapGet("/api/book/{id:int}", GetBook).WithName("GetBook").Produces<APIResponse>();

            app.MapPost("/api/book", CreateBook).WithName("CreateBook")
                .Accepts<BookCreateDTO>("application/json").Produces(201).Produces(400);

            app.MapPut("/api/book", UpdateBook).WithName("UpdateBook").Accepts<BookUpdateDTO>("application/json")
                .Produces<BookUpdateDTO>(200)
                .Produces(400);

            app.MapDelete("/api/book/{id:int}", DeleteBook).WithName("DeleteBook");

            app.MapGet("/api/book", SearchBook).WithName("SearchBook").Produces<APIResponse>();
        }

        private static async Task<IResult> GetAllBooks(IBookRepository _bookRepo)
        {
            APIResponse response = new APIResponse();

            response.Result = await _bookRepo.GetAllAsync();
            response.IsSuccess = true;
            response.StatusCode = System.Net.HttpStatusCode.OK;

            return Results.Ok(response);
        }

        private static async Task<IResult> GetBook(IBookRepository _bookRepo, int id)
        {
            APIResponse response = new APIResponse();

            response.Result = await _bookRepo.GetByIdAsync(id);
            response.IsSuccess = true;
            response.StatusCode = System.Net.HttpStatusCode.OK;

            return Results.Ok(response);
        }

        private static async Task<IResult>SearchBook(IBookRepository _bookRepo, string title)
        {
            APIResponse response = new APIResponse();

            var book = await _bookRepo.GetAsync(title.ToLower());
            if(book != null)
            {
                response.Result = book;
                response.IsSuccess = true;
                response.StatusCode=System.Net.HttpStatusCode.OK;
            }
            else
            {
                response.ErrorMessages.Add("Book was not found");
                response.StatusCode = System.Net.HttpStatusCode.NotFound;
                
            }
            return Results.Ok(response);
        }

        private static async Task<IResult> CreateBook(IBookRepository _bookRepo, IMapper _mapper, BookCreateDTO book_c_DTO)
        {
            APIResponse response = new() { IsSuccess = false, StatusCode = System.Net.HttpStatusCode.BadRequest };

            if (_bookRepo.GetAsync(book_c_DTO.Title).GetAwaiter().GetResult() != null)
            {
                response.ErrorMessages.Add("Book title already exists in system");
                return Results.BadRequest(response);
            }

            Book book = _mapper.Map<Book>(book_c_DTO);
            await _bookRepo.CreateAsync(book);
            await _bookRepo.SaveAsync();
            BookDTO bookDTO = _mapper.Map<BookDTO>(book);

            response.Result = bookDTO;
            response.IsSuccess = true;
            response.StatusCode = System.Net.HttpStatusCode.OK;

            return Results.Ok(response);

        }

        private static async Task<IResult> UpdateBook(IBookRepository _bookRepo, IMapper _mapper, BookUpdateDTO book_u_DTO)
        {
            APIResponse response = new() { IsSuccess = false, StatusCode = System.Net.HttpStatusCode.BadRequest };

            await _bookRepo.UpdateAsync(_mapper.Map<Book>(book_u_DTO));
            await _bookRepo.SaveAsync();

            response.Result = _mapper.Map<BookUpdateDTO>(await _bookRepo.GetByIdAsync(book_u_DTO.BookID));
            response.IsSuccess = true;
            response.StatusCode = System.Net.HttpStatusCode.OK;
            return Results.Ok(response);
        }

        private static async Task<IResult> DeleteBook(IBookRepository _bookRepo, int id)
        {
            APIResponse response = new() { IsSuccess = false, StatusCode = System.Net.HttpStatusCode.BadRequest };

            Book bookToDelete = await _bookRepo.GetByIdAsync(id);

            if(bookToDelete != null)
            {
                await _bookRepo.RemoveAsync(bookToDelete);
                await _bookRepo.SaveAsync();
                response.IsSuccess = true;
                response.StatusCode = System.Net.HttpStatusCode.NoContent;
                return Results.Ok(response);
            }
            else
            {
                response.ErrorMessages.Add("Invalid ID");
                return Results.BadRequest(response);
            }

        }
    }
}
