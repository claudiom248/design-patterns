using System.Collections.Generic;
using DesignPatterns.Creational.Builder.Domain;

namespace DesignPatterns.Tests.Creational.Builder.Common
{
    public static class OsDataProvider
    {
        public static Os Android10 { get; } = new Os
        {
            Name = "Android", Version = "1.0", Apps = new List<string> {"Google Play", "Mi Store"}
        };

        public static Os Android20 { get; } = new Os
        {
            Name = "Android", Version = "2.0", Apps = new List<string> {"Google Play", "Mi Store", "Mi Fit"}
        };

        public static Os Ios10 { get; } = new Os
        {
            Name = "IOS", Version = "1.0", Apps = new List<string> {"Apple Store", "iTunes"}
        };

        public static Os Ios20 { get; } = new Os
        {
            Name = "IOS", Version = "2.0", Apps = new List<string> {"Apple Store", "iTunes", "Maps"}
        };
    }
}
