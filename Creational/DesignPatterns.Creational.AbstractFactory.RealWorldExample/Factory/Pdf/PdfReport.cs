using DesignPatterns.Creational.AbstractFactory.RealWorldExample.Factory.Abstract;
using System;

namespace DesignPatterns.Creational.AbstractFactory.RealWorldExample.Factory.Pdf
{
    public class PdfReport : IReport
    {
        public string Name { get => throw new NotImplementedException(); set => throw new NotImplementedException(); }

        public string Extension { get => throw new NotImplementedException(); set => throw new NotImplementedException(); }

        public DateTime CreationDate { get => throw new NotImplementedException(); set => throw new NotImplementedException(); }

        public string Path { get => throw new NotImplementedException(); set => throw new NotImplementedException(); }
    }
}
