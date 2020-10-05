using System.Collections.Generic;
using DesignPatterns.Creational.AbstractFactory.RealWorldExample.Domain;

namespace DesignPatterns.Creational.AbstractFactory.RealWorldExample.Service
{
    public class BookService : IBookService
    {
        public IEnumerable<Book> GetAll()
            => new List<Book>
            {
                new Book
                {
                    Author = "Author1",
                    CopiesSold = 20,
                    Isbn = "ISBN1",
                    Price = 20.43M,
                    Title = "Title1"
                },
                new Book
                {
                    Author = "Author2",
                    CopiesSold = 56,
                    Isbn = "ISBN2",
                    Price = 43.23M,
                    Title = "Title2"
                },
                new Book
                {
                    Author = "Author3",
                    CopiesSold = 1240,
                    Isbn = "ISBN3",
                    Price = 25.70M,
                    Title = "Title3"
                },
                new Book
                {
                    Author = "Author4",
                    CopiesSold = 632,
                    Isbn = "ISBN4",
                    Price = 47.92M,
                    Title = "Title4"
                }
            };
    }
}