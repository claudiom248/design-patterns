using DesignPatterns.Creational.AbstractFactory.Abstract;
using System;

namespace DesignPatterns.Creational.AbstractFactory.Windows
{
    public class WindowsButtonComponent : WindowsBaseComponent, IButtonComponent
    {
        public string Text { get; set; }

        public event EventHandler Click;
    }
}
