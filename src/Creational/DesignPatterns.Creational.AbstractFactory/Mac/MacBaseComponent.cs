using DesignPatterns.Creational.AbstractFactory.Abstract;

namespace DesignPatterns.Creational.AbstractFactory.Mac
{
    public abstract class MacBaseComponent : BaseComponent
    {
        public override string OperatingSystem => "Mac";
    }
}