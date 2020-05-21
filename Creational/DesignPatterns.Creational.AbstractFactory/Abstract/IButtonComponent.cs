using System;

namespace DesignPatterns.Creational.AbstractFactory.Abstract
{
    public interface IButtonComponent : IGuiComponent
    {
        string Text { get; set; }

        event EventHandler Click;
    }
}
