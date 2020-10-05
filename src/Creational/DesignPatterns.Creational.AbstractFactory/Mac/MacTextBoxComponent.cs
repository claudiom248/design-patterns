using DesignPatterns.Creational.AbstractFactory.Abstract;

namespace DesignPatterns.Creational.AbstractFactory.Mac
{
    public class MacTextBoxComponent : MacBaseComponent, ITextBoxComponent
    {
        public string Value { get; set; }
    }
}