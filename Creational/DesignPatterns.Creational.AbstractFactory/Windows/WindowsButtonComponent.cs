using DesignPatterns.Creational.AbstractFactory.Abstract;

namespace DesignPatterns.Creational.AbstractFactory.Windows
{
    public class WindowsButtonComponent : WindowsBaseComponent, IButtonComponent
    {
        public string Text { get; set; }
    }
}
