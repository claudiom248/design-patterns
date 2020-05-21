using DesignPatterns.Creational.AbstractFactory.Abstract;
using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Reflection;
using Mac = DesignPatterns.Creational.AbstractFactory.Mac;
using Windows = DesignPatterns.Creational.AbstractFactory.Windows;

namespace DesignPatterns.Tests.Creational.AbstractFactory
{
    [TestFixture]
    public class AbstractFactoryTests
    {
        private const string WindowsOsName = "Windows";
        private const string MacOsName= "Mac";
        private IDictionary<string, IAbstractGuiComponentFactory> factories;

        [SetUp]
        public void Setup()
        {
            factories = new Dictionary<string, IAbstractGuiComponentFactory>
            {
                [WindowsOsName] = new Windows.WindowsConcreteGuiComponentFactory(),
                [MacOsName] = new Mac.MacConcreteGuiComponentFactory()
            };
        }

        [TestCase(WindowsOsName, typeof(Windows.WindowsConcreteGuiComponentFactory))]
        [TestCase(MacOsName, typeof(Mac.MacConcreteGuiComponentFactory))]
        public void Should_Be_Correct_Factory_Type(string os, Type expectedfactoryType)
        {
            IAbstractGuiComponentFactory factory = GetFactory(os);

            Assert.AreEqual(factory.GetType(), expectedfactoryType);
        }

        [TestCase(WindowsOsName, typeof(Windows.WindowsButtonComponent))]
        [TestCase(MacOsName, typeof(Mac.MacButtonComponent))]
        public void Should_Create_Correct_Button_Type_Depending_On_Operating_System(string os, Type expectedButtonType)
        {
            IAbstractGuiComponentFactory factory = GetFactory(os);

            IButtonComponent button = factory.CreateButton();

            Assert.AreEqual(button.GetType(), expectedButtonType);
            Assert.AreEqual(button.OperatingSystem, os);
        }

        [TestCase(WindowsOsName, typeof(Windows.WindowsTextBoxComponent))]
        [TestCase(MacOsName, typeof(Mac.MacTextBoxComponent))]
        public void Should_Create_Correct_TextBox_Type_Depending_On_Operating_System(string os, Type expectedTextBoxType)
        {
            IAbstractGuiComponentFactory factory = GetFactory(os);

            ITextBoxComponent textBox = factory.CreateTextBox();

            Assert.AreEqual(textBox.GetType(), expectedTextBoxType);
            Assert.AreEqual(textBox.OperatingSystem, os);
        }

        [TestCase(WindowsOsName, typeof(Windows.WindowsTextBoxComponent))]
        [TestCase(WindowsOsName, typeof(Windows.WindowsButtonComponent))]
        [TestCase(MacOsName, typeof(Mac.MacTextBoxComponent))]
        [TestCase(MacOsName, typeof(Mac.MacButtonComponent))]
        public void Should_Create_Correct_Component_Type_Depending_On_Operating_System(string os, Type expectedComponentType)
        {
            IAbstractGuiComponentFactory factory = GetFactory(os);
            var methodInfo = GetCreateGenericMethod(factory, expectedComponentType);
            var methodArgs = new object[] { Type.Missing };

            var component = Convert.ChangeType(methodInfo.Invoke(factory, new object[] { methodArgs }), expectedComponentType);

            Assert.AreEqual(component.GetType(), expectedComponentType);
        }

        [TestCase(WindowsOsName, typeof(Mac.MacTextBoxComponent))]
        [TestCase(WindowsOsName, typeof(Mac.MacButtonComponent))]
        [TestCase(MacOsName, typeof(Windows.WindowsTextBoxComponent))]
        [TestCase(MacOsName, typeof(Windows.WindowsButtonComponent))]
        public void Should_Fail_Creating_Component_Type_Of_Another_Operating_System(string os, Type otherOsComponentType)
        {
            IAbstractGuiComponentFactory factory = GetFactory(os);
            var methodInfo = GetCreateGenericMethod(factory, otherOsComponentType);
            var methodArgs = new object[] { Type.Missing };

            var ex = Assert.Throws(typeof(TargetInvocationException), () => Convert.ChangeType(methodInfo.Invoke(factory, new object[] { methodArgs }), otherOsComponentType));
            Assert.That(ex.InnerException, Is.TypeOf<NotSupportedException>());
        }

        private MethodInfo GetCreateGenericMethod(IAbstractGuiComponentFactory factory, Type methodReturnType) => 
            factory.GetType().GetMethod(nameof(factory.Create)).MakeGenericMethod(methodReturnType);

        private IAbstractGuiComponentFactory GetFactory(string os) => factories[os];
    }
}
