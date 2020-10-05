namespace DesignPatterns.Creational.AbstractFactory.RealWorldExample.Domain
{
    public class Book
    {
        public string Isbn { get; set; }

        public string Title { get; set; }

        public string Author { get; set; }

        public decimal Price { get; set; }

        public int CopiesSold { get; set; }
    }
}