namespace DesignPatterns.Creational.AbstractFactory.Abstract
{
    public interface IAbstractGuiComponentFactory
    {
        TComponent Create<TComponent>(params object[] args) where TComponent : class, IGuiComponent;

        public IButtonComponent CreateButton(int width = 0, int height = 0, string text = "");

        public ITextBoxComponent CreateTextBox(int width = 0, int height = 0, string value = "");
    }
}
