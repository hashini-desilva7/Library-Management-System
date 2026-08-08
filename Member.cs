using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OAKTOWN_ASSIGNMENT
{
    public class Member
    {
        private string memberID;
        private List<LibraryItem> currentBorrowed;
        private List<LibraryItem> previousBorrowed;

        public Member(string memberID)
        {
            this.memberID = memberID;
            this.currentBorrowed = new List<LibraryItem>();
            this.previousBorrowed = new List<LibraryItem>();
        }

        public string MemberID { get => memberID; }
        public List<LibraryItem> CurrentBorrowed { get => currentBorrowed; }
        public List<LibraryItem> PreviousBorrowed { get => previousBorrowed; }
    }
}
