using LibraryIS.Models;
using LibraryIS.Repositories;
using LibraryIS.Tests.Helpers;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace LibraryIS.Tests.Tests
{
    [TestClass]
    public class BookRepositoryTests
    {
        private TestDatabase _db;
        private BookRepository _repo;

        [TestInitialize]
        public void Setup()
        {
            _db = new TestDatabase();
            _repo = new BookRepository();
        }

        [TestCleanup]
        public void Cleanup()
        {
            _db.Dispose();
        }

        private static Book MakeBook(string title = "Война и мир", string author = "Лев Толстой",
            string genre = "Классика", int year = 1869, string isbn = "111", int total = 2)
        {
            return new Book
            {
                Title = title,
                Author = author,
                Genre = genre,
                Year = year,
                ISBN = isbn,
                TotalCopies = total,
                AvailableCopies = total
            };
        }

        [TestMethod]
        [Description("Добавление книги с корректными данными должно завершаться успехом")]
        public void AddBook_WithValidData_ReturnsTrue()
        {
            bool result = _repo.AddBook(MakeBook());
            Assert.IsTrue(result);
            Assert.AreEqual(1, _repo.GetAllBooks().Count);
        }

        [TestMethod]
        [Description("Добавление книги с пустым названием должно завершаться неудачей")]
        public void AddBook_WithEmptyTitle_ReturnsFalse()
        {
            bool result = _repo.AddBook(MakeBook(title: ""));
            Assert.IsFalse(result);
            Assert.AreEqual(0, _repo.GetAllBooks().Count);
        }

        [TestMethod]
        [Description("Добавление книги с нулевым количеством экземпляров должно завершаться неудачей")]
        public void AddBook_WithZeroCopies_ReturnsFalse()
        {
            bool result = _repo.AddBook(MakeBook(total: 0));
            Assert.IsFalse(result);
            Assert.AreEqual(0, _repo.GetAllBooks().Count);
        }

        [TestMethod]
        [Description("Поиск книги по существующему названию должен возвращать запись")]
        public void FindBook_ByExistingTitle_ReturnsBook()
        {
            _repo.AddBook(MakeBook(title: "Мастер и Маргарита", author: "Михаил Булгаков"));
            var found = _repo.FindBook("Название", "Мастер");
            Assert.AreEqual(1, found.Count);
            Assert.AreEqual("Мастер и Маргарита", found[0].Title);
        }

        [TestMethod]
        [Description("Поиск книги по несуществующему названию должен возвращать пустой список")]
        public void FindBook_ByNonExistingTitle_ReturnsEmpty()
        {
            _repo.AddBook(MakeBook());
            var found = _repo.FindBook("Название", "Несуществующая книга");
            Assert.AreEqual(0, found.Count);
        }

        [TestMethod]
        [Description("Поиск книги по автору должен возвращать все его произведения")]
        public void FindBook_ByAuthor_ReturnsBooks()
        {
            _repo.AddBook(MakeBook(title: "Война и мир", author: "Лев Толстой"));
            _repo.AddBook(MakeBook(title: "Анна Каренина", author: "Лев Толстой"));
            _repo.AddBook(MakeBook(title: "Идиот", author: "Фёдор Достоевский"));

            var found = _repo.FindBook("Автор", "Толстой");
            Assert.AreEqual(2, found.Count);
        }

        [TestMethod]
        [Description("Уменьшение количества доступных экземпляров на единицу должно сохранять новое значение")]
        public void UpdateAvailableCopies_DecrementByOne_UpdatesValue()
        {
            _repo.AddBook(MakeBook(total: 3));
            int id = _repo.GetAllBooks()[0].Id;

            bool result = _repo.UpdateAvailableCopies(id, 2);

            Assert.IsTrue(result);
            Assert.AreEqual(2, _repo.GetAllBooks()[0].AvailableCopies);
        }

        [TestMethod]
        [Description("Установка количества доступных экземпляров ниже нуля должна отклоняться")]
        public void UpdateAvailableCopies_BelowZero_ReturnsFalse()
        {
            _repo.AddBook(MakeBook(total: 1));
            int id = _repo.GetAllBooks()[0].Id;

            bool result = _repo.UpdateAvailableCopies(id, -1);

            Assert.IsFalse(result);
            Assert.AreEqual(1, _repo.GetAllBooks()[0].AvailableCopies);
        }

        [TestMethod]
        [Description("Удаление существующей книги должно убирать её из каталога")]
        public void DeleteBook_ExistingBook_RemovesFromCatalog()
        {
            _repo.AddBook(MakeBook());
            int id = _repo.GetAllBooks()[0].Id;

            bool result = _repo.DeleteBook(id);

            Assert.IsTrue(result);
            Assert.AreEqual(0, _repo.GetAllBooks().Count);
        }

        [TestMethod]
        [Description("Удаление несуществующей книги не должно вызывать ошибку и не меняет каталог")]
        public void DeleteBook_NonExistingBook_DoesNotThrow()
        {
            _repo.AddBook(MakeBook());

            bool result = _repo.DeleteBook(99999);

            Assert.IsTrue(result);
            Assert.AreEqual(1, _repo.GetAllBooks().Count);
        }
    }
}
