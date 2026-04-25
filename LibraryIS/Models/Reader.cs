using System;

namespace LibraryIS.Models
{
    public class Reader
    {
        public int Id { get; set; }
        public string FullName { get; set; }
        public DateTime BirthDate { get; set; }
        public string CardNumber { get; set; }
        public string Phone { get; set; }

        public Reader()
        {
            FullName = string.Empty;
            CardNumber = string.Empty;
            Phone = string.Empty;
            BirthDate = DateTime.Now;
        }
    }
}
