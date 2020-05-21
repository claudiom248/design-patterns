namespace DesignPatterns.Creational.AbstractFactory.Abstract
{
    public interface IAbstractGuiComponentFactory
    {
        TComponent Create<TComponent>(params object[] args) where TComponent : class, IGuiComponent;

        public IButtonComponent CreateButton(string text = "");

        public ITextBoxComponent CreateTextBox(string value = "");
    }
}
