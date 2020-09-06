using DesignPatterns.Creational.Builder.Builder.Phone;
using DesignPatterns.Creational.Builder.Domain;
using DesignPatterns.Creational.Builder.Tests.Common;
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
                XiaomiBuilder,
                "Model2",
                OsDataProvider.Android_1_0,
                new Domain.Phone
                {
                    Make = "Xiaomi",
                    Model = "Model2",
                    Os = OsDataProvider.Android_1_0
                }
            );

            yield return new TestCaseData(
                XiaomiBuilder,
                "Model3",
                OsDataProvider.Android_2_0,
                new Domain.Phone
                {
                    Make = "Xiaomi",
                    Model = "Model3",
                    Os = OsDataProvider.Android_2_0
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

            yield return new TestCaseData(
                AppleBuilder,
                "Model2",
                OsDataProvider.Ios_2_0,
                new Domain.Phone
                {
                    Make = "Apple",
                    Model = "Model2",
                    Os = OsDataProvider.Ios_2_0
                }
            );
        }

        [TestCaseSource("TestCaseDataSource")]
        public void Build_ReturnsExpectedPhone(PhoneBuilder<Domain.Phone> builder, string model, Os os, Domain.Phone expected)
        {
            builder.Make();
            builder.Model(model);
            builder.Os(os);

            var phone = builder.Build();

            Assert.AreEqual(expected, phone);
        }

        [Test]
        public void Reset_SetPhonePropertiesToDefaultValues()
        {
            var builder = new XiaomiPhoneBuilder<Domain.Phone>();
            var defaultPhone = new Domain.Phone();

            builder.Make();
            builder.Model("model");
            builder.Os(new Os());

            var phone = builder.Build();
            Assert.AreNotEqual(defaultPhone, phone);

            builder.Reset();
            phone = builder.Build();
            Assert.AreEqual(defaultPhone, phone);
        }
    }
}
