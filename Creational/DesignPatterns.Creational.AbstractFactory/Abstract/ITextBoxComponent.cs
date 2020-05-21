using System;

namespace DesignPatterns.Creational.AbstractFactory.Abstract
{
    public interface ITextBoxComponent : IGuiComponent 
    {
        string Value { get; set; }

        event EventHandler TextChanged;
    }
}