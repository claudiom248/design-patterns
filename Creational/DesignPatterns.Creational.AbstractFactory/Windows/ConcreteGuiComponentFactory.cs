using DesignPatterns.Creational.AbstractFactory.Abstract;
using System;

namespace DesignPatterns.Creational.AbstractFactory.Windows
{
    public class ConcreteGuiComponentFactory : IAbstractGuiComponentFactory
    {
        public TComponent Create<TComponent>(params object[] args) where TComponent : class, IGuiComponent
        {
            Type componentType = typeof(TComponent);

            if (typeof(ButtonComponent).IsAssignableFrom(componentType))
            {
                return (TComponent)CreateButton();
            }

            if (typeof(TextBoxComponent).IsAssignableFrom(componentType))
            {
                return (TComponent)CreateTextBox();
            }

            throw new NotSupportedException($"{typeof(TComponent)} component type cannot be provided.");
        }

        public IButtonComponent CreateButton(int width = 0, int height = 0, string text = "")
        {
            return new ButtonComponent()
            {
                Width = width,
                Height = height,
                Text = text
            };
        }

        public ITextBoxComponent CreateTextBox(int width = 0, int height = 0, string value = "")
        {
            return new TextBoxComponent()
            {
                Width = width,
                Height = height,
                Value = value
            };
        }
    }
}
