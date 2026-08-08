using OAKTOWN_ASSIGNMENT;
using System;
using System.Transactions;

Library library = new Library();

// Sample data
// Books
Book book1 = new Book("Jane Eyre", "Charlotte Bronte", 1960, "2333-0060935467", 324);
library.AddItem(book1);

Book book2 = new Book("A Tale of Two Cities", "Charles Dickens", 1949, "231-0451524935", 328);
library.AddItem(book2);

Book book3 = new Book("Harry Potter and the Philosopher's Stone", "J. K. Rowling", 1925, "230-0743273565", 180);
library.AddItem(book3);

Book book4 = new Book("Lolita ", "Vladimir Nabokov", 1813, "978-1503290563", 279);
library.AddItem(book4);

// Reference Books
ReferenceBook refBook1 = new ReferenceBook("Oxford English Dictionary", "Oxford Press", 2000, "971-0198611868", 1500, true);
library.AddItem(refBook1);

ReferenceBook refBook2 = new ReferenceBook("Encyclopedia Britannica", "Britannica", 2015, "908-1625131711", 3200, true);
library.AddItem(refBook2);

ReferenceBook refBook3 = new ReferenceBook("Bulfinch's Mythology", "Thomas Bulfinch", 2008, "948-0443069529", 1600, false);
library.AddItem(refBook3);

// Magazines
Magazine mag1 = new Magazine("The New Yorker", "Harold Ross", 2021, "978-1122334455", 30);
library.AddItem(mag1);

Magazine mag2 = new Magazine("The Paris Review", "Harold L. Humes", 2022, "978-1426217780", 50);
library.AddItem(mag2);

Magazine mag3 = new Magazine("One Story", "Springer Nature", 2023, "978-1586937893", 45);
library.AddItem(mag3);

Magazine mag4 = new Magazine("Forbes", "Hannah Tinti ", 2020, "978-0525573621", 35);
library.AddItem(mag4);

// Members
Member member1 = new Member("M123");
library.AddMember(member1);

Member member2 = new Member("M124");
library.AddMember(member2);

Member member3 = new Member("M125");
library.AddMember(member3);



int choice = 0;
while (choice != -1)
{
    Console.WriteLine("\n--- OakTown Library Menu ---");
    Console.WriteLine("1. List all items");
    Console.WriteLine("2. Search items by title keyword");
    Console.WriteLine("3. Borrow item");
    Console.WriteLine("4. Return item");
    Console.WriteLine("5. Calculate borrowing cost");
    Console.WriteLine("6. Show member's current borrowed items");
    Console.WriteLine("7. Show member's previous borrowed items");
    Console.WriteLine("8. Show all members");
    Console.WriteLine("-1. Exit");
    Console.Write("Enter choice: ");

    string input = Console.ReadLine();
    if (input == null || input == "")
    {
        Console.WriteLine("Invalid input.Enter a choice from 1-8");
        continue;
    }
    choice = Convert.ToInt32(input);

    switch (choice)
    {
        case 1:
            library.ListAllItems();
            break;

        case 2:
            Console.Write("Enter keyword: ");
            string keyword = Console.ReadLine();
            if (string.IsNullOrWhiteSpace(keyword))
            {
                Console.WriteLine("Keyword cannot be empty.");
            }
            else
            {
                library.SearchByTitle(keyword);
            }
            break;

        case 3:
            Console.WriteLine("Enter the member ID");
            string memberId = Console.ReadLine();
            Member member = library.GetMemberById(memberId);
            if (member == null)
            {
                Console.WriteLine("Member not found.Enter a valid member ID");
                continue;
            }

            Console.Write("Enter ISBN to borrow: ");
            string isbnBorrow = Console.ReadLine();
            if (string.IsNullOrWhiteSpace(isbnBorrow))
            {
                Console.WriteLine("ISBN cannot be empty.");
            }
            else
            {
                library.BorrowItem(isbnBorrow, member);
            }
            break;

        case 4:
            Console.Write("Enter Member ID: ");
            memberId = Console.ReadLine();
            member = library.GetMemberById(memberId);

            if (member == null)
            {
                Console.WriteLine("Member not found.");
                continue;
            }
            Console.Write("Enter ISBN to return: ");
            string isbnReturn = Console.ReadLine();
            if (string.IsNullOrWhiteSpace(isbnReturn))
            {
                Console.WriteLine("ISBN cannot be empty.");
            }
            else
            {
                library.ReturnItem(isbnReturn, member);
            }
            break;

        case 5:
            Console.Write("Enter ISBN: ");
            string isbnCost = Console.ReadLine();
            if (string.IsNullOrWhiteSpace(isbnCost))
            {
                Console.WriteLine("ISBN cannot be empty.");
            }
            else
            {
                Console.Write("Enter number of days: ");
                string daysInput = Console.ReadLine();

                int days;
                if (!int.TryParse(daysInput, out days))  
                {
                    Console.WriteLine("Invalid input for number of days. Please enter a valid number.");
                }
                else if (days <= 0) 
                {
                    Console.WriteLine("Number of days should be greater than 0.");
                }
                else
                {
                    library.CalculateBorrowingCost(isbnCost, days);
                }
            }
            break;


        case 6:
            Console.WriteLine("Enter Member ID:");
            memberId = Console.ReadLine();
            member = library.GetMemberById(memberId);
            if (member != null)
            {
                Console.WriteLine("Currently borrowed:");
                foreach (LibraryItem item in member.CurrentBorrowed)
                {
                    item.DisplayInfo();
                }
            }
            else
            {
                Console.WriteLine("Member not found");
            }
            break;

        case 7:
            Console.WriteLine("Enter Member ID:");
            memberId = Console.ReadLine();
            member = library.GetMemberById(memberId);
            if (member != null)
            {
                Console.WriteLine("Previously  borrowed:");
                foreach (LibraryItem item in member.PreviousBorrowed)
                {
                    item.DisplayInfo();
                }
            }
            else
            {
                Console.WriteLine("Member not found");
            }
            break;

        case 8:
            Console.WriteLine("All Members:");
            library.DisplayMembers();
            break;

        case -1:
            Console.WriteLine("Thank you for choosing us.");
            break;

        default:
            Console.WriteLine("Invalid choice.Enter a choice 1-8");
            break;
    }
}


