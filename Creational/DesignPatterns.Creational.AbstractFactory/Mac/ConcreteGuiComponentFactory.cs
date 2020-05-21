using DesignPatterns.Creational.AbstractFactory.Abstract;
using System;
using System.Collections.Generic;
using System.Reflection;

namespace DesignPatterns.Creational.AbstractFactory.Mac
{
    public class ConcreteGuiComponentFactory : IAbstractGuiComponentFactory
    {
        private static readonly Type _type = typeof(ConcreteGuiComponentFactory);
        private readonly IDictionary<Type, MethodBase> _componentResolvers;

        public ConcreteGuiComponentFactory()
        {
            _componentResolvers = new Dictionary<Type, MethodBase>
            {
                [typeof(ButtonComponent)] = _type.GetMethod(nameof(this.CreateButton)),
                [typeof(TextBoxComponent)] = _type.GetMethod(nameof(this.CreateTextBox))
            };
        }

        public TComponent Create<TComponent>(params object[] args) where TComponent : class, IGuiComponent
        {
            if (!_componentResolvers.TryGetValue(typeof(TComponent), out var componentResolver))
            {
                throw new NotSupportedException($"{typeof(TComponent)} component type cannot be provided.");
            }

            return (TComponent)componentResolver.Invoke(this, args);
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
