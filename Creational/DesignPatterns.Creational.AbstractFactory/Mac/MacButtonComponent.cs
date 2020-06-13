using DesignPatterns.Creational.AbstractFactory.Abstract;

namespace DesignPatterns.Creational.AbstractFactory.Mac
{
    public class MacButtonComponent : MacBaseComponent, IButtonComponent
    {
        public string Text { get; set; }
    }
}
