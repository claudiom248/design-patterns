using DesignPatterns.Creational.Builder.Domain;
using System.Collections.Generic;

namespace DesignPatterns.Creational.Builder.Tests.Common
{
    public static class OsDataProvider
    {
        public static Os Android_1_0 = new Os
        {
            Name = "Android",
            Version = "1.0",
            Apps = new List<string> { "Google Play", "Mi Store" }
        };

        public static Os Android_2_0 = new Os
        {
            Name = "Android",
            Version = "2.0",
            Apps = new List<string> { "Google Play", "Mi Store", "Mi Fit" }
        };

        public static Os Ios_1_0 = new Os
        {
            Name = "IOS",
            Version = "1.0",
            Apps = new List<string> { "Apple Store", "iTunes" }
        };

        public static Os Ios_2_0 = new Os
        {
            Name = "IOS",
            Version = "2.0",
            Apps = new List<string> { "Apple Store", "iTunes", "Maps" }
        };
    }
}
