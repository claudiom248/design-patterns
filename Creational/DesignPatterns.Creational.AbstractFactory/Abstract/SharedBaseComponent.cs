namespace DesignPatterns.Creational.AbstractFactory.Abstract
{
    public abstract class SharedBaseComponent : IGuiComponent
    {
        public string OperatingSystem { get; set; }

        public int Width { get; set; }

        public int Height { get; set; }
    }
}
