using DesignPatterns.Creational.AbstractFactory.Abstract;
using System;

namespace DesignPatterns.Creational.AbstractFactory.Mac
{
    public class TextBoxComponent : BaseComponent, ITextBoxComponent
    {
        public string Value { get; set; }

        public event EventHandler TextChanged;
    }
}
