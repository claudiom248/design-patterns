namespace DesignPatterns.Creational.AbstractFactory.Abstract
{
    public abstract class BaseComponent : IGuiComponent
    {
        public virtual string OperatingSystem { get; set; }

        public int Width { get; set; }

        public int Height { get; set; }
    }
}