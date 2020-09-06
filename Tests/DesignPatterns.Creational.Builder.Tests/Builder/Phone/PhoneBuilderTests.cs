using DesignPatterns.Creational.Builder.Builder.Phone;
using DesignPatterns.Creational.Builder.Domain;
using NUnit.Framework;
using System.Collections.Generic;

namespace DesignPatterns.Creational.Builder.Tests.Builder.Phone
{
    [TestFixture]
    public class PhoneBuilderTests
    {

        public static IEnumerable<TestCaseData> TestCaseDataSource()
        {
            var XiaomiBuilder = new XiaomiPhoneBuilder<Domain.Phone>();
            var AppleBuilder = new ApplePhoneBuilder<Domain.Phone>();

            yield return new TestCaseData(
                XiaomiBuilder,
                "Model1",
                OsDataProvider.Android_1_0,
                new Domain.Phone
                {
                    Make = "Xiaomi",
                    Model = "Model1",
                    Os = OsDataProvider.Android_1_0
                }
            );

            yield return new TestCaseData(
                AppleBuilder,
                "Model1",
                OsDataProvider.Ios_1_0,
                new Domain.Phone
                {
                    Make = "Apple",
                    Model = "Model1",
                    Os = OsDataProvider.Ios_1_0
                }
            );
        }

        [TestCaseSource("TestCaseDataSource")]
        public void Build_ReturnsExpectedPhone(PhoneBuilder<Domain.Phone> builder, string model, Os os, Domain.Phone expected)
        {
            builder.Make();
            builder.Model(model);
            builder.Os(os);

            var actual = builder.Build();

            Assert.AreEqual(expected, actual);
        }
    }

    public static class OsDataProvider
    {
        public static Os Android_1_0 = new Os
        {
            Name = "Android",
            Version = "1.0",
            SystemApps = new List<string> { "Google Play", "Mi Store" }
        };

        public static Os Ios_1_0 = new Os
        {
            Name = "IOS",
            Version = "1.0",
            SystemApps = new List<string> { "Apple Store", "iTunes" }
        };
    }
}
