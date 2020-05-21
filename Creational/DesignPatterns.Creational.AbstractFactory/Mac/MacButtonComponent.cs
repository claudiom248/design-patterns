﻿using DesignPatterns.Creational.AbstractFactory.Abstract;
using System;

namespace DesignPatterns.Creational.AbstractFactory.Mac
{
    public class MacButtonComponent : MacBaseComponent, IButtonComponent
    {
        public string Text { get; set; }

        public event EventHandler Click;
    }
}