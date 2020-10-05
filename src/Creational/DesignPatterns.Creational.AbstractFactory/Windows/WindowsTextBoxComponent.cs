using DesignPatterns.Creational.AbstractFactory.Abstract;

namespace DesignPatterns.Creational.AbstractFactory.Windows
{
    public class WindowsTextBoxComponent : WindowsBaseComponent, ITextBoxComponent
    {
        public string Value { get; set; }
    }
}