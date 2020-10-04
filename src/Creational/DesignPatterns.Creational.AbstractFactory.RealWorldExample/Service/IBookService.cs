using System.Collections.Generic;
using DesignPatterns.Creational.AbstractFactory.RealWorldExample.Domain;

namespace DesignPatterns.Creational.AbstractFactory.RealWorldExample.Service
{
    public interface IBookService
    {
        IEnumerable<Book> GetAll();
    }
}
