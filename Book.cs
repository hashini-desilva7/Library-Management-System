using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OAKTOWN_ASSIGNMENT
{
    public class Book : LibraryItem
    {
        private int pages;

        public Book(string title, string author, int year, string isbn, int pages)
            : base(title, author, year, isbn)
        {
            this.pages = pages;
        }

        public int Pages { get => pages; set => pages = value; }

        public override void DisplayInfo()
        {
            base.DisplayInfo();
            Console.WriteLine($"Pages: {pages}");
        }
    }
}

