using System.Collections.Generic;
using DesignPatterns.Creational.Builder.Builder.Phone;
using DesignPatterns.Creational.Builder.Domain;
using DesignPatterns.Tests.Creational.Builder.Common;
using NUnit.Framework;

namespace DesignPatterns.Tests.Creational.Builder.Builder.Phone
{
    [TestFixture]
    public class PhoneBuilderTests
    {
        public static IEnumerable<TestCaseData> TestCaseDataSource()
        {
            var xiaomiBuilder = new XiaomiPhoneBuilder<DesignPatterns.Creational.Builder.Domain.Phone>();
            var appleBuilder = new ApplePhoneBuilder<DesignPatterns.Creational.Builder.Domain.Phone>();

            yield return new TestCaseData(
                xiaomiBuilder,
                "Model1",
                OsDataProvider.Android10,
                new DesignPatterns.Creational.Builder.Domain.Phone
                {
                    Make = "Xiaomi",
                    Model = "Model1",
                    Os = OsDataProvider.Android10
                }
            );

            yield return new TestCaseData(
                xiaomiBuilder,
                "Model2",
                OsDataProvider.Android10,
                new DesignPatterns.Creational.Builder.Domain.Phone
                {
                    Make = "Xiaomi",
                    Model = "Model2",
                    Os = OsDataProvider.Android10
                }
            );

            yield return new TestCaseData(
                xiaomiBuilder,
                "Model3",
                OsDataProvider.Android20,
                new DesignPatterns.Creational.Builder.Domain.Phone
                {
                    Make = "Xiaomi",
                    Model = "Model3",
                    Os = OsDataProvider.Android20
                }
            );

            yield return new TestCaseData(
                appleBuilder,
                "Model1",
                OsDataProvider.Ios10,
                new DesignPatterns.Creational.Builder.Domain.Phone
                {
                    Make = "Apple",
                    Model = "Model1",
                    Os = OsDataProvider.Ios10
                }
            );

            yield return new TestCaseData(
                appleBuilder,
                "Model2",
                OsDataProvider.Ios20,
                new DesignPatterns.Creational.Builder.Domain.Phone
                {
                    Make = "Apple",
                    Model = "Model2",
                    Os = OsDataProvider.Ios20
                }
            );
        }

        [TestCaseSource(nameof(TestCaseDataSource))]
        public void Build_ReturnsExpectedPhone(
            PhoneBuilder<DesignPatterns.Creational.Builder.Domain.Phone> builder,
            string model,
            Os os,
            DesignPatterns.Creational.Builder.Domain.Phone expected)
        {
            builder.WithMake();
            builder.WithModel(model);
            builder.WithOs(os);

            var phone = builder.Build();

            Assert.AreEqual(expected, phone);
        }

        [Test]
        public void Reset_SetPhonePropertiesToDefaultValues()
        {
            var builder = new XiaomiPhoneBuilder<DesignPatterns.Creational.Builder.Domain.Phone>();
            var defaultPhone = new DesignPatterns.Creational.Builder.Domain.Phone();

            builder.WithMake();
            builder.WithModel("model");
            builder.WithOs(new Os());

            var phone = builder.Build();
            Assert.AreNotEqual(defaultPhone, phone);

            builder.Reset();
            phone = builder.Build();
            Assert.AreEqual(defaultPhone, phone);
        }
    }
}