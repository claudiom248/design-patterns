using DesignPatterns.Creational.AbstractFactory.Abstract;
using System;
using System.Collections.Generic;
using System.Reflection;

namespace DesignPatterns.Creational.AbstractFactory.Mac
{
    public class MacConcreteGuiComponentFactory : IAbstractGuiComponentFactory
    {
        private static readonly Type _type = typeof(MacConcreteGuiComponentFactory);
        private readonly IDictionary<Type, MethodBase> _componentResolvers;

        public MacConcreteGuiComponentFactory()
        {
            _componentResolvers = new Dictionary<Type, MethodBase>
            {
                [typeof(MacButtonComponent)] = _type.GetMethod(nameof(this.CreateButton)),
                [typeof(MacTextBoxComponent)] = _type.GetMethod(nameof(this.CreateTextBox))
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

        public IButtonComponent CreateButton(string text = "")
        {
            return new MacButtonComponent
            {
                Text = text
            };
        }

        public ITextBoxComponent CreateTextBox(string value = "")
        {
            return new MacTextBoxComponent
            {
                Value = value
            };
        }
    }
}
