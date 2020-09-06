using DesignPatterns.Creational.AbstractFactory.RealWorldExample.Domain;
using System.Collections.Generic;

namespace DesignPatterns.Creational.AbstractFactory.RealWorldExample.Service
{
    public interface IBookService
    {
        IEnumerable<Book> GetAll();
    }
}
