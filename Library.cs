using OAKTOWN_ASSIGNMENT;
using System;
using System.Collections.Generic;

namespace OAKTOWN_ASSIGNMENT
{
    public class Library
    {
        private List<LibraryItem> items;
        private List<Member> members;

        public List<LibraryItem> Items { get => items; set => items = value; }
        public List<Member> Members { get => members; set => members = value; }

        public Library()
        {
            items = new List<LibraryItem>();
            members = new List<Member>();
        }

        public void AddItem(LibraryItem item)
        {
            items.Add(item);
        }
        public void AddMember(Member member)
        {
            members.Add(member);
        }
        public void DisplayMembers()
        {
            if (members.Count == 0)
            {
                Console.WriteLine("No member has registered yet");
                return;
            }

            Console.WriteLine("Library Members:");
            foreach (Member member in members)
            {
                Console.WriteLine("Member ID: " + member.MemberID);
            }
        }
        public Member GetMemberById(string memberId)
        {
            foreach (Member m in members)
            {
                if (m.MemberID == memberId)
                {
                    return m; 
                }
            }
            return null;
        }

        public void ListAllItems()
        {
            foreach (LibraryItem item in items)
            {
                item.DisplayInfo();
                Console.WriteLine("-------------------");
            }
        }

        public List<LibraryItem> SearchByTitle(string keyword)
        {
            List<LibraryItem> results = new List<LibraryItem>();

            foreach (LibraryItem item in items)
            {
                if (item.Title.ToLower().Contains(keyword.ToLower()) && item.IsAvailable())
                {
                    results.Add(item);
                    
                }
            }

            foreach (LibraryItem item in results)
            {
                item.DisplayInfo();
                Console.WriteLine("-------------------");

            }
            return results;
        }

        public void BorrowItem(string isbn, Member member)
        {
            LibraryItem item = null;

            foreach (LibraryItem i in items)
            {
                if (i.ISBN == isbn)
                {
                    item = i;
                    break;
                }
            }

            if (item == null)
            {
                Console.WriteLine("Item not found.");
                return;
            }

            if (!item.IsAvailable())
            {
                Console.WriteLine("Item is already borrowed.");
                return;
            }

            if (item is ReferenceBook)
            {
                ReferenceBook refBook = (ReferenceBook)item;
                if (refBook.Restricted)
                {
                    Console.WriteLine("Reference books cannot be borrowed.");
                    return;
                }
            }

            item.BorrowedBy = member.MemberID;
            member.CurrentBorrowed.Add(item);
            Console.WriteLine("Borrowed: " + item.Title);
        }

        public void ReturnItem(string isbn, Member member)
        {
            LibraryItem item = null;

            foreach (LibraryItem i in member.CurrentBorrowed)
            {
                if (i.ISBN == isbn)
                {
                    item = i;
                    break;
                }
            }

            if (item == null)
            {
                Console.WriteLine("This member did not borrow that item.");
                return;
            }

            item.BorrowedBy = "";
            member.CurrentBorrowed.Remove(item);
            member.PreviousBorrowed.Add(item);

            Console.WriteLine("Returned: " + item.Title);
        }


        public double CalculateBorrowingCost(string isbn, int days)
        {
            LibraryItem item = null;

            foreach (LibraryItem i in items)
            {
                if (i.ISBN == isbn)
                {
                    item = i;
                    break;
                }
            }

            if (item == null)
            {
                Console.WriteLine("Item not found.");
                return 0;
            }
            if (days <= 0)
            {
                Console.WriteLine(" Number of days should be greater than 0.");
                return 0;
            }

            double totalCost = days * 100;

            Console.WriteLine("Cost of borrowing " + item.Title + " for " + days + " days: LKR." + totalCost);
            return totalCost;
        }
    }
}
