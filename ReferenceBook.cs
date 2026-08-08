using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OAKTOWN_ASSIGNMENT
{
    public class ReferenceBook : Book
    {
        private bool restricted;

        public ReferenceBook(string title, string author, int year, string isbn, int pages, bool restricted)
            : base(title, author, year, isbn, pages)
        {
            this.restricted = restricted;
        }

        public bool Restricted { get => restricted; set => restricted = value; }

        public override void DisplayInfo()
        {
            base.DisplayInfo();
            Console.WriteLine($"Restricted: {restricted}");
        }
    }
}
