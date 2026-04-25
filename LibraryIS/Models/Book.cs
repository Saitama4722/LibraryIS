namespace LibraryIS.Models
{
    public class Book
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public string Author { get; set; }
        public string Genre { get; set; }
        public int Year { get; set; }
        public string ISBN { get; set; }
        public int TotalCopies { get; set; }
        public int AvailableCopies { get; set; }

        public Book()
        {
            Title = string.Empty;
            Author = string.Empty;
            Genre = string.Empty;
            ISBN = string.Empty;
        }
    }
}
