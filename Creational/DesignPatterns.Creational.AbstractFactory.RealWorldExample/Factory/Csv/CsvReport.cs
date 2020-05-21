using DesignPatterns.Creational.AbstractFactory.RealWorldExample.Factory.Abstract;
using System;

namespace DesignPatterns.Creational.AbstractFactory.RealWorldExample.Factory.Csv
{
    public class CsvReport : IReport
    {
        public string Name { get => throw new NotImplementedException(); set => throw new NotImplementedException(); }

        public string Extension { get => throw new NotImplementedException(); set => throw new NotImplementedException(); }

        public DateTime CreationDate { get => throw new NotImplementedException(); set => throw new NotImplementedException(); }

        public byte[] Data { get => throw new NotImplementedException(); set => throw new NotImplementedException(); }
    }
}
