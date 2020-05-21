using DesignPatterns.Creational.AbstractFactory.Abstract;
using System;

namespace DesignPatterns.Creational.AbstractFactory.Windows
{
    public class ConcreteGuiComponentFactory : IAbstractGuiComponentFactory
    {
        public TComponent Create<TComponent>(params object[] args) where TComponent : class, IGuiComponent
        {
            Type componentType = typeof(TComponent);

            if (typeof(ButtonComponent) == componentType)
            {
                return (TComponent)CreateButton();
            }

            if (typeof(TextBoxComponent) == componentType)
            {
                return (TComponent)CreateTextBox();
            }

            throw new NotSupportedException($"{typeof(TComponent)} component type cannot be provided.");
        }

        public IButtonComponent CreateButton(string text = "")
        {
            return new ButtonComponent
            {
                Text = text
            };
        }

        public ITextBoxComponent CreateTextBox(string value = "")
        {
            return new TextBoxComponent
            {
                Value = value
            };
        }
    }
}
