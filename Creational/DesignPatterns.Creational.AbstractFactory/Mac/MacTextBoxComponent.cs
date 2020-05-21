using DesignPatterns.Creational.AbstractFactory.Abstract;
using System;

namespace DesignPatterns.Creational.AbstractFactory.Mac
{
    public class MacTextBoxComponent : MacBaseComponent, ITextBoxComponent
    {
        public string Value { get; set; }

        public event EventHandler TextChanged;
    }
}
