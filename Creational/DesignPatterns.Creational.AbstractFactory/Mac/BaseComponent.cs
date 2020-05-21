using DesignPatterns.Creational.AbstractFactory.Abstract;

namespace DesignPatterns.Creational.AbstractFactory.Mac
{
    public abstract class BaseComponent : SharedBaseComponent
    {
        public override string OperatingSystem => "Mac";
    }
}
