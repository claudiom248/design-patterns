using DesignPatterns.Creational.AbstractFactory.Abstract;
using DesignPatterns.Creational.AbstractFactory.Mac;
using DesignPatterns.Creational.AbstractFactory.Windows;
using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Reflection;

namespace DesignPatterns.Tests.Creational.AbstractFactory
{
    [TestFixture]
    public class AbstractFactoryTest
    {
        private const string WindowsOsName = "Windows";
        private const string MacOsName= "Mac";

        private readonly IDictionary<string, IAbstractGuiComponentFactory> _factories;

        public AbstractFactoryTest() => _factories = new Dictionary<string, IAbstractGuiComponentFactory>
        {
            [WindowsOsName] = new WindowsConcreteGuiComponentFactory(),
            [MacOsName] = new MacConcreteGuiComponentFactory()
        };

        [TestCase(WindowsOsName, typeof(WindowsTextBoxComponent))]
        [TestCase(WindowsOsName, typeof(WindowsButtonComponent))]
        [TestCase(MacOsName, typeof(MacTextBoxComponent))]
        [TestCase(MacOsName, typeof(MacButtonComponent))]
        public void Create_CompatibleOsFactory_ReturnsCorrectComponentType(string os, Type expectedComponentType)
        {
            var factory = GetFactory(os);
            var methodInfo = GetCreateGenericMethod(factory, expectedComponentType);
            var methodArgs = new object[] { Type.Missing };

            var component = Convert.ChangeType(methodInfo.Invoke(factory, new object[] { methodArgs }), expectedComponentType);

            Assert.AreEqual(expectedComponentType, component.GetType());
        }

        [TestCase(WindowsOsName, typeof(MacTextBoxComponent))]
        [TestCase(WindowsOsName, typeof(MacButtonComponent))]
        [TestCase(MacOsName, typeof(WindowsTextBoxComponent))]
        [TestCase(MacOsName, typeof(WindowsButtonComponent))]
        public void Create_NotCompatibleOsFactory_Throws(string os, Type otherOsComponentType)
        {
            var factory = GetFactory(os);
            var methodInfo = GetCreateGenericMethod(factory, otherOsComponentType);
            var methodArgs = new object[] { Type.Missing };

            var ex = Assert.Throws(
                typeof(TargetInvocationException), 
                () => Convert.ChangeType(methodInfo.Invoke(factory, new object[] { methodArgs }), otherOsComponentType)
            );
            Assert.That(ex.InnerException, Is.TypeOf<NotSupportedException>());
        }

        private MethodInfo GetCreateGenericMethod(IAbstractGuiComponentFactory factory, Type methodReturnType) 
            => factory.GetType().GetMethod(nameof(factory.Create)).MakeGenericMethod(methodReturnType);

        private IAbstractGuiComponentFactory GetFactory(string os) => _factories[os];
    }
}
