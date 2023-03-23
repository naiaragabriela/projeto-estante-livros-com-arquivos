
namespace ListBooks
{
    internal class Author
    {
        public string Name { get; set; }
        public string LastName { get; set; }

        public Author()
        {
        }

        public void EditName(string name)
        {
            Name = name;
        }
        public void EditLastName(string lastName)
        {
            LastName = lastName;
        }
        public override string ToString()
        {
            return $"{Name}|{LastName}";
        }
    }
}
