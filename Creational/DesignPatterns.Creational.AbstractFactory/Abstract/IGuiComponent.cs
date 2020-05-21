namespace DesignPatterns.Creational.AbstractFactory.Abstract
{
    public interface IGuiComponent
    {
        string OperatingSystem { get; set; }

        int Width { get; set; }

        int Height { get; set; }

    }
}