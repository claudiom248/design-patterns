using DesignPatterns.Creational.AbstractFactory.Abstract;
using System;

namespace DesignPatterns.Creational.AbstractFactory.Windows
{
    public class WindowsConcreteGuiComponentFactory : IAbstractGuiComponentFactory
    {
        public TComponent Create<TComponent>(params object[] args) where TComponent : class, IGuiComponent
        {
            Type componentType = typeof(TComponent);

            if (typeof(WindowsButtonComponent) == componentType)
            {
                return (TComponent)CreateButton();
            }

            if (typeof(WindowsTextBoxComponent) == componentType)
            {
                return (TComponent)CreateTextBox();
            }

            throw new NotSupportedException($"{typeof(TComponent)} component type cannot be provided.");
        }

        public IButtonComponent CreateButton(string text = "")
        {
            return new WindowsButtonComponent
            {
                Text = text
            };
        }

        public ITextBoxComponent CreateTextBox(string value = "")
        {
            return new WindowsTextBoxComponent
            {
                Value = value
            };
        }
    }
}
