using System;

namespace DesignPatterns.Creational.AbstractFactory.RealWorldExample.Factory.Abstract
{
    internal interface IReport
    {
        public string Name { get; set; }

        public string Extension { get; set; }

        public DateTime CreationDate { get; set; }

        public byte[] Data { get; set; }
    }
}
