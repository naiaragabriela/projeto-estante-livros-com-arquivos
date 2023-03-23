
namespace ListBooks
{
    internal class Book
    {
        public string NameBook { get; set; }
        public Author Author { get; set; }
        public string Edition { get; set; }
        public int Year { get; set; }
        public string ISBN { get; set; }
        public bool Reading { get; set; }
        public bool Borrewed { get; set; }

        public Book()
        {
      
        }

        public void EditNameBook(string nameBook)
        {
            NameBook = nameBook;
        }

        public void EditEdition(string edition)
        {
            Edition = edition;
        }

        public void EditYear(int year)
        {
            Year = year;
        }

        public void EditIsbn(string isbn)
        {
            ISBN = isbn;
        }
        public override string ToString()
        {
            return $"{NameBook}|{Author}|{Edition}|{Year}|{ISBN}|{Reading}|{Borrewed}";
        }
    }
}
