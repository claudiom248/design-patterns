﻿using DesignPatterns.Creational.AbstractFactory.RealWorldExample.Domain;
using DesignPatterns.Creational.AbstractFactory.RealWorldExample.Domain.Report;
using System.Collections.Generic;

namespace DesignPatterns.Creational.AbstractFactory.RealWorldExample.Factory.Abstract
{
    public interface IAbstractReportFactory
    {
        public IReport CreateBooksReport(IEnumerable<Book> books);
    }
}