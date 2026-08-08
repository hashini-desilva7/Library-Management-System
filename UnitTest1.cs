using OAKTOWN_ASSIGNMENT;

namespace Testing

{
    public class BookTests
    {
        [Test]
        public void BookProperties()
        {
            var book = new Book("Harry Potter and the Philosopher's Stone", "J. K. Rowling", 1925, "230-0743273565", 180);
            Assert.AreEqual("Harry Potter and the Philosopher's Stone", book.Title);
            Assert.AreEqual("J. K. Rowling", book.Author);
            Assert.AreEqual(1925, book.Year);
            Assert.AreEqual("230-0743273565", book.ISBN);
            Assert.AreEqual(180, book.Pages);
        }

    }

    [TestFixture]
    public class ReferenceBookTests
    {
        [Test]
        public void ReferenceBookRestrictedCorrectly()
        {
            var refBook = new ReferenceBook("Oxford English Dictionary", "Oxford Press", 2000, "971-0198611868", 1500, true);
            Assert.IsTrue(refBook.Restricted);
        }


    }

    [TestFixture]
    public class MagazineTests
    {
        [Test]
        public void MagazineSetsIssueNumberCorrectly()
        {
            var mag = new Magazine("The Paris Review", "Harold L. Humes", 2021, "978-1426217780", 50);
            Assert.AreEqual(50, mag.IssueNumber);
            Assert.AreEqual("Harold L. Humes", mag.Author);
        }


    }

    [TestFixture]
    public class LibraryTests
    {
        private Library library;
        private Member member;

        [SetUp]
        public void Setup()
        {
            library = new Library();
            member = new Member("M123");
        }

        [Test]
        public void AddItem_AddsToLibrary()
        {
            var book = new Book("Bulfinch's Mythology", "Thomas Bulfinch", 2008, " 948-0443069529", 1600);
            library.AddItem(book);
            Assert.AreEqual(1, library.Items.Count);
        }

        [Test]
        public void SearchByTitle_FindsAvailableItem()
        {
            var book = new Book("Forbes", "Tinti", 2020, "978-0525573621", 300);
            library.AddItem(book);

            var results = library.SearchByTitle("Forbes");

            Assert.AreEqual(1, results.Count);
            Assert.AreEqual(book, results[0]);
        }


        [Test]
        public void BorrowItem_SuccessfullyBorrows()
        {
            var book = new Book("Jane Eyre", "Charlotte Bronte", 1960, "2333-0060935467", 324);
            library.AddItem(book);
            library.BorrowItem("2333-0060935467", member);
            Assert.AreEqual("M123", book.BorrowedBy);
            Assert.Contains(book, member.CurrentBorrowed);
        }
        [Test]

        public void CalculateBorrowingCost_CheckCostLogic()
        {
            var book = new Book("Harry Potter and the Philosopher's Stone", " J. K. Rowling", 1925, "230-0743273565", 180);
            library.AddItem(book);


            double cost = library.CalculateBorrowingCost("230-0743273565", 4);

            Assert.AreEqual(2.0m, cost);
        }

        [TestFixture]
        public class ProgramTests
        {

            private Library library;
            private Member member;
            [SetUp]
            public void Setup()
            {

                library = new Library();
                member = new Member("M123");
            }

            [Test]
            public void BorrowRestrictedReferenceBook_ShouldShowErrorMessage()
            {

                var refBook = new ReferenceBook("Oxford English Dictionary", " Oxford Press", 2000, "971-0198611868", 1500, true);
                library.BorrowItem("971-0198611868", member);
                Assert.IsFalse(member.CurrentBorrowed.Contains(refBook));
                Assert.IsTrue(string.IsNullOrEmpty(refBook.BorrowedBy));

            }

            [Test]
            public void AddBookAndCheckProperties_ShouldWorkCorrectly()
            {

                var book = new Book("Encyclopedia Britannica", "Britannica", 2015, "908-1625131711", 250);

                Assert.AreEqual("Encyclopedia Britannica", book.Title);
                Assert.AreEqual(250, book.Pages);
            }
        }
    }
}