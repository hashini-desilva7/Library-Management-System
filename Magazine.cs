using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OAKTOWN_ASSIGNMENT
{
    public class Magazine : LibraryItem
    {
        private int issueNumber;

        public Magazine(string title, string author, int year, string isbn, int issueNumber)
            : base(title, author, year, isbn)
        {
            this.issueNumber = issueNumber;
        }

        public int IssueNumber { get => issueNumber; set => issueNumber = value; }

        public override void DisplayInfo ()
        {
            base.DisplayInfo();
            Console.WriteLine($"Issue Number: {issueNumber}");
        }
    }
}
