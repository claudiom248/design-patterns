using DesignPatterns.Creational.AbstractFactory.Abstract;

namespace DesignPatterns.Creational.AbstractFactory.Windows
{
    public abstract class WindowsBaseComponent : BaseComponent
    {
        public override string OperatingSystem => "Windows";
    }
}