﻿using DesignPatterns.Creational.AbstractFactory.Abstract;
using DesignPatterns.Creational.AbstractFactory.Mac;
using DesignPatterns.Creational.AbstractFactory.Windows;
using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Reflection;

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
                [WindowsOsName] = new WindowsConcreteGuiComponentFactory(),
                [MacOsName] = new MacConcreteGuiComponentFactory()
            };
        }

        [TestCase(WindowsOsName, typeof(WindowsConcreteGuiComponentFactory))]
        [TestCase(MacOsName, typeof(MacConcreteGuiComponentFactory))]
        public void Should_Be_Correct_Factory_Type(string os, Type expectedfactoryType)
        {
            IAbstractGuiComponentFactory factory = GetFactory(os);

            Assert.AreEqual(factory.GetType(), expectedfactoryType);
        }

        [TestCase(WindowsOsName, typeof(WindowsButtonComponent))]
        [TestCase(MacOsName, typeof(MacButtonComponent))]
        public void Should_Create_Correct_Button_Type_Depending_On_Operating_System(string os, Type expectedButtonType)
        {
            IAbstractGuiComponentFactory factory = GetFactory(os);

            IButtonComponent button = factory.CreateButton();

            Assert.AreEqual(button.GetType(), expectedButtonType);
            Assert.AreEqual(button.OperatingSystem, os);
        }

        [TestCase(WindowsOsName, typeof(WindowsTextBoxComponent))]
        [TestCase(MacOsName, typeof(MacTextBoxComponent))]
        public void Should_Create_Correct_TextBox_Type_Depending_On_Operating_System(string os, Type expectedTextBoxType)
        {
            IAbstractGuiComponentFactory factory = GetFactory(os);

            ITextBoxComponent textBox = factory.CreateTextBox();

            Assert.AreEqual(textBox.GetType(), expectedTextBoxType);
            Assert.AreEqual(textBox.OperatingSystem, os);
        }

        [TestCase(WindowsOsName, typeof(WindowsTextBoxComponent))]
        [TestCase(WindowsOsName, typeof(WindowsButtonComponent))]
        [TestCase(MacOsName, typeof(MacTextBoxComponent))]
        [TestCase(MacOsName, typeof(MacButtonComponent))]
        public void Should_Create_Correct_Component_Type_Depending_On_Operating_System(string os, Type expectedComponentType)
        {
            IAbstractGuiComponentFactory factory = GetFactory(os);
            var methodInfo = GetCreateGenericMethod(factory, expectedComponentType);
            var methodArgs = new object[] { Type.Missing };

            var component = Convert.ChangeType(methodInfo.Invoke(factory, new object[] { methodArgs }), expectedComponentType);

            Assert.AreEqual(component.GetType(), expectedComponentType);
        }

        [TestCase(WindowsOsName, typeof(MacTextBoxComponent))]
        [TestCase(WindowsOsName, typeof(MacButtonComponent))]
        [TestCase(MacOsName, typeof(WindowsTextBoxComponent))]
        [TestCase(MacOsName, typeof(WindowsButtonComponent))]
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
