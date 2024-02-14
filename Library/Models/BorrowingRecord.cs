namespace Library.Models
{
    public class BorrowingRecord
    {
        public int BorrowingRecordID { get; set; }

        public int StudentID { get; set; }

        public int BookID { get; set; }

        public DateTimeOffset BorrowingDate { get; set; }

        public DateTimeOffset ReturnDate { get; set; }

        public decimal Fine { get; set; }
    }
}
