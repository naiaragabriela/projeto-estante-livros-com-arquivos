using System;

namespace ListBooks
{
    public class Program
    {
        private static void Main(string[] args)
        {
            List<Book> myBooks = new();

            Console.WriteLine("Bem vindo a Estante de Livros");
            Console.WriteLine("Por favor, digite o número da operação que deseja fazer");
            int op;

            do
            {
                myBooks = LoadFile();
                op = Menu();

                switch (op)
                {
                    case 1:
                        var aux = InsertBook();
                        myBooks.Add(aux);
                        WriteFile(aux.ToString());
                        break;
                    case 2:
                        PrintBook(myBooks);
                        break;
                    case 3:
                        myBooks = LoadFile();
                        break;
                    case 4:
                        var auxi = FindBook();
                        EditBook(auxi);
                        int position = myBooks.IndexOf(auxi);
                        myBooks[position] = auxi;
                        break;
                    case 5:
                        var remove = FindBook();
                        int positionRemove = myBooks.IndexOf(remove);
                        myBooks.Remove(remove);
                        break;
                    case 6:
                        SeparatList(myBooks);
                        break;
                    case 7:
                        System.Environment.Exit(0);
                        break;
                    default:
                        Console.WriteLine("Opção Inválida");
                        break;
                }
            } while (true);

            int Menu()
            {
                Console.WriteLine("\n 1-Inserir Livro na Lista de livros" + "\n 2-Mostrar Lista de Livros" + "\n 3-Criar um arquivo da Lista de Livros" + "\n 4-Editar Informações Livro" + "\n 5-Remover Livro" + "\n 6 - Adicionar Livros editados no Arquivo Livros Emprestados e Arquivos de Livros de Leitura" + "\n 7-Sair");
                int op = int.Parse(Console.ReadLine());
                return op;
            }

            Book InsertBook()
            {
                Book book = new();
                Author author = new();

                Console.WriteLine("Digite o nome do Livro:");
                book.NameBook = Console.ReadLine();
                Console.WriteLine("Digite a Editora do Livro:");
                Console.WriteLine("Digite o nome do Autor: ");
                author.Name = Console.ReadLine();
                Console.WriteLine("digite o sobrenome do autor: ");
                author.LastName = Console.ReadLine();
                book.Author = author;
                book.Edition = Console.ReadLine();
                Console.WriteLine("Digite o ano do Livro:");
                book.Year = int.Parse(Console.ReadLine());
                Console.WriteLine("Digite o código ISBN do Livro:");
                book.ISBN = Console.ReadLine();
                return book;
            }

            Book FindBook()
            {
                Console.WriteLine("Digite o nome do Livro: ");
                string? editBook = Console.ReadLine();
                foreach (Book book in myBooks)
                {
                    if (book.NameBook.Equals(editBook))
                    {
                        return book;
                    }
                }
                return null;
            }

            int ChooseEditBook()
            {
                Console.WriteLine("Digite a opção que deseja editar: \n 1- Editar Nome" + "\n 2-Editar Autor" + "\n 3- Editat Edição" + "\n 4-Editar Ano" + "\n 5-Editar ISBN" + "\n 6- Editar se livro foi emprestado ou se estou lendo o livro" + "\n 7- Sair");
                int edit = int.Parse(Console.ReadLine());
                return edit;
            }

            void EditBook(Book book)
            {
                bool sair = false;
                do
                {
                    switch (ChooseEditBook())
                    {
                        case 1:
                            Console.WriteLine("Digite o novo nome do livro: ");
                            string nameBook = Console.ReadLine();
                            book.NameBook = nameBook;
                            break;
                        case 2:
                            Console.WriteLine("Digite o novo nome do autor do livro: ");
                            string name = Console.ReadLine();
                            book.Author.Name = name;
                            Console.WriteLine("Digite o novo nome do autor do livro: ");
                            string lastName = Console.ReadLine();
                            book.Author.Name = lastName;
                            break;
                        case 3:
                            Console.WriteLine("Digite a nova edição do livro: ");
                            string edition = Console.ReadLine();
                            book.Edition = edition;
                            break;
                        case 4:
                            Console.WriteLine("Digite o novo ano do livro: ");
                            int year = int.Parse(Console.ReadLine());
                            book.Year = year;
                            break;
                        case 5:
                            Console.WriteLine("Digite a nova ISBN do livro: ");
                            string isbn = Console.ReadLine();
                            book.ISBN = isbn;
                            break;
                        case 6:
                            Console.WriteLine("O livro está:" + "\n 1- Na estante" + "\n 2- Emprestado" + "\n 3- Estou lendo");
                            int answered = int.Parse(Console.ReadLine());
                            if (answered == 1)
                            {
                                book.Borrewed = false;
                                book.Reading = false;
                            }
                            if (answered == 2)
                            {
                                book.Borrewed = true;
                                book.Reading = false;
                            }
                            if (answered == 3)
                            {
                                book.Borrewed = false;
                                book.Reading = true;
                            }
                            break;
                        case 7:
                            sair = true;
                            break;
                        default:
                            Console.WriteLine("Opção Inválida");
                            break;
                    }
                } while (sair == false);
            }

            void PrintBook(List<Book> l)
            {
                foreach (Book book in l)
                {
                    Console.WriteLine(book);
                }
            }

            void SeparatList(List<Book> l)
            {
                string bookBorrewed = "";
                string bookReading = "";
                string bookAvaiable = "";

                foreach (Book book in l)
                {
                    if (book.Borrewed == true)
                    {
                        bookBorrewed += book.ToString() +"\n";

                    }
                    if (book.Reading == true)
                    {
                        bookReading += book.ToString() + "\n";
 
                    }

                    bookAvaiable += book.ToString() + "\n";
                }

                WriteFileReading(bookReading);

                WriteFileBorrewed(bookBorrewed);

                WriteFile(bookAvaiable);
            }

            List<Book> LoadFile()
            {
                if (!File.Exists("AvaiableBookList.txt"))
                {
                    StreamWriter sw = new("AvaiableBookList.txt");
                    sw.Close();
                }

                StreamReader sr = new("AvaiableBookList.txt");
                string text = "";

                List<Book> myBooks = new();
              
                while ((text = sr.ReadLine()) != null)
                {
                    var values = text.Split("|");
                    Book newBook = new Book();
                    Author newAuthor = new Author();
                    newBook.NameBook= values[0];
                    newBook.Edition = values[3];
                    newBook.Year = int.Parse(values[4]);
                    newBook.ISBN = values[5];
                    newBook.Reading = bool.Parse(values[6]);
                    newBook.Borrewed = bool.Parse(values[7]);
                    newAuthor.Name = values[1];
                    newAuthor.LastName = values[2];
                    newBook.Author = newAuthor;
                    myBooks.Add(newBook);
                }
                sr.Close();
                return myBooks;
            }

            void WriteFileReading(string bookReading)
            {
                try
                { 
                        StreamWriter sw = new("ReadingBookList.txt");
                        sw.WriteLine(bookReading);
                        sw.Close();
                }
                catch (Exception)
                {
                    throw;
                }
                finally
                {
                    Console.WriteLine("Registro gravado com sucesso!");
                    Thread.Sleep(1000);
                }

            }

            void WriteFile(string bookAvaiable)
            {
                try
                {
                        StreamWriter sw = new("AvaiableBookList.txt");
                        sw.WriteLine(bookAvaiable);
                        sw.Close();
                }

                catch (Exception)
                {
                    throw;
                }
                finally
                {
                    Console.WriteLine("Registro gravado com sucesso!");
                    Thread.Sleep(1000);
                }
            }

            void WriteFileBorrewed(string bookBorrewed)
            {
                try
                {
                        StreamWriter sw = new("BorrewedBookList.txt");
                        sw.WriteLine(bookBorrewed);
                        sw.Close();
                }

                catch (Exception)
                {
                    throw;
                }
                finally
                {
                    Console.WriteLine("Registro gravado com sucesso!");
                    Thread.Sleep(1000);
                }
            }
        }
    }
}
