using DesignPatterns.Creational.AbstractFactory.Abstract;

namespace DesignPatterns.Creational.AbstractFactory.Windows
{
    public abstract class BaseComponent : SharedBaseComponent
    {
        public override string OperatingSystem => "Windows";
    }
}