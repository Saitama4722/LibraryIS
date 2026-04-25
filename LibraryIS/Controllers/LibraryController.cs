using System.Collections.Generic;
using LibraryIS.Models;
using LibraryIS.Repositories;

namespace LibraryIS.Controllers
{
    public class LibraryController
    {
        private readonly BookRepository _bookRepo;
        private readonly ReaderRepository _readerRepo;

        public LibraryController()
        {
            _bookRepo = new BookRepository();
            _readerRepo = new ReaderRepository();
        }

        public bool AddBook(Book book) { return _bookRepo.AddBook(book); }
        public List<Book> FindBook(string field, string value) { return _bookRepo.FindBook(field, value); }
        public List<Book> GetAllBooks() { return _bookRepo.GetAllBooks(); }
        public bool EditBook(Book book) { return _bookRepo.EditBook(book); }
        public bool DeleteBook(int id) { return _bookRepo.DeleteBook(id); }

        public bool RegisterReader(Reader reader) { return _readerRepo.RegisterReader(reader); }
        public List<Reader> GetAllReaders() { return _readerRepo.GetAllReaders(); }
        public Reader GetReaderByCard(string card) { return _readerRepo.GetReaderByCard(card); }

        public bool LoanBook(Book book)
        {
            if (book.AvailableCopies <= 0) return false;
            return _bookRepo.UpdateAvailableCopies(book.Id, book.AvailableCopies - 1);
        }
    }
}
