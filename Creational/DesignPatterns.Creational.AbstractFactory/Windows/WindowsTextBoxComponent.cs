using DesignPatterns.Creational.AbstractFactory.Abstract;
using System;

namespace DesignPatterns.Creational.AbstractFactory.Windows
{
    public class WindowsTextBoxComponent : WindowsBaseComponent, ITextBoxComponent
    {
        public string Value { get; set; }

        public event EventHandler TextChanged;
    }
}
