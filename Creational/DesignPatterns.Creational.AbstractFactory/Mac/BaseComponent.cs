using DesignPatterns.Creational.AbstractFactory.Abstract;

namespace DesignPatterns.Creational.AbstractFactory.Mac
{
    public abstract class BaseComponent : SharedBaseComponent
    {
        public string OperatingSystem => "Mac";
    }
}
