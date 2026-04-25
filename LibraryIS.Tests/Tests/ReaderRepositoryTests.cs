using System;
using LibraryIS.Repositories;
using LibraryIS.Tests.Helpers;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace LibraryIS.Tests.Tests
{
    [TestClass]
    public class ReaderRepositoryTests
    {
        private TestDatabase _db;
        private ReaderRepository _repo;

        [TestInitialize]
        public void Setup()
        {
            _db = new TestDatabase();
            _repo = new ReaderRepository();
        }

        [TestCleanup]
        public void Cleanup()
        {
            _db.Dispose();
        }

        private static LibraryIS.Models.Reader MakeReader(string fullName = "Иванов Иван Иванович",
            string card = "БЧ-00001", string phone = "+7 (900) 000-00-00")
        {
            return new LibraryIS.Models.Reader
            {
                FullName = fullName,
                BirthDate = new DateTime(1990, 1, 1),
                CardNumber = card,
                Phone = phone
            };
        }

        [TestMethod]
        [Description("Регистрация читателя с корректными данными должна завершаться успехом")]
        public void RegisterReader_WithValidData_ReturnsTrue()
        {
            bool result = _repo.RegisterReader(MakeReader());

            Assert.IsTrue(result);
            Assert.AreEqual(1, _repo.GetAllReaders().Count);
        }

        [TestMethod]
        [Description("Регистрация читателя с дублирующимся номером билета должна отклоняться")]
        public void RegisterReader_WithDuplicateCardNumber_ReturnsFalse()
        {
            _repo.RegisterReader(MakeReader(card: "БЧ-00001"));
            bool result = _repo.RegisterReader(MakeReader(
                fullName: "Петров Пётр Петрович", card: "БЧ-00001"));

            Assert.IsFalse(result);
            Assert.AreEqual(1, _repo.GetAllReaders().Count);
        }

        [TestMethod]
        [Description("Регистрация читателя с пустым ФИО должна отклоняться")]
        public void RegisterReader_WithEmptyFullName_ReturnsFalse()
        {
            bool result = _repo.RegisterReader(MakeReader(fullName: ""));

            Assert.IsFalse(result);
            Assert.AreEqual(0, _repo.GetAllReaders().Count);
        }

        [TestMethod]
        [Description("Поиск читателя по существующему номеру билета должен возвращать запись")]
        public void GetReaderByCard_ExistingCard_ReturnsReader()
        {
            _repo.RegisterReader(MakeReader(fullName: "Сидоров Сидор Сидорович", card: "БЧ-00007"));

            var reader = _repo.GetReaderByCard("БЧ-00007");

            Assert.IsNotNull(reader);
            Assert.AreEqual("Сидоров Сидор Сидорович", reader.FullName);
        }

        [TestMethod]
        [Description("Поиск читателя по несуществующему номеру билета должен возвращать null")]
        public void GetReaderByCard_NonExistingCard_ReturnsNull()
        {
            _repo.RegisterReader(MakeReader());

            var reader = _repo.GetReaderByCard("БЧ-99999");

            Assert.IsNull(reader);
        }
    }
}
