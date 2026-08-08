using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OAKTOWN_ASSIGNMENT
{
    public abstract class LibraryItem
    {
        private string title;
        private string author;
        private int year;
        private string isbn;
        private string borrowedBy; 

        public LibraryItem(string title, string author, int year, string isbn)
        {
            this.title = title;
            this.author = author;
            this.year = year;
            this.isbn = isbn;
            this.borrowedBy = "";
        }

        public string Title { get => title; set => title = value; }
        public string Author { get => author; set => author = value; }
        public int Year { get => year; set => year = value; }
        public string ISBN { get => isbn; set => isbn = value; }
        public string BorrowedBy { get => borrowedBy; set => borrowedBy = value; }

        public bool IsAvailable()
        {
            return string.IsNullOrEmpty(borrowedBy);
        }

        public virtual void DisplayInfo()
        {
            Console.WriteLine($"{title} by {author} ({year}) - ISBN: {isbn} - " +
                $"{(IsAvailable() ? "Available" : "Borrowed by " + borrowedBy)}");
        }
    }
}
